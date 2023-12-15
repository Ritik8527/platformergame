using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class playerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public float runspeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    public Vector2 forceDirection;
    public float thrust = 50f;
    public Rigidbody2D playerRB;
    public int playerHealth = 100;
    public SpriteRenderer sp;
    public float restartDelay = 1f;
    int totalCherry = 0;
    public float deathbearDelay = 2f;
    public GameObject completeLevelUI;
    public float levelCompleteAnimationDelay = 3f;
    public float nextLevelDealy = 3f;

    // CLIMBING LADDER
    bool isClimbing;
    bool isLadder;
    float verticalMove;
    public float climbingSpeed = 4f;
    [SerializeField] private Rigidbody2D playLADDER;
    
    


    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal")*runspeed;
        verticalMove = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Speed",Mathf.Abs(horizontalMove));

       
        if(Input.GetButtonDown("Jump"))
        {
            jump=true;
            animator.SetBool("isJump",true);

        }
        if(Input.GetButtonDown("Crouch")){
            crouch = true;
            
        }
        else if(Input.GetButtonUp("Crouch")){
            crouch = false;
        }
        if(playerHealth<=0)
        {
            death();
            Invoke("restart",restartDelay);
            playerHealth = 100;
        }

        if(isLadder && Mathf.Abs(verticalMove) > 0f)
        {
            isClimbing = true;
        }
        
        
        // Debug.Log(Input.GetAxisRaw("Horizontal"));
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove*Time.fixedDeltaTime,crouch,jump);
        jump=false;   

        if(isClimbing)
        {
            
            playLADDER.gravityScale = 0f;
            playLADDER.velocity = new Vector2(horizontalMove , verticalMove*climbingSpeed);
            animator.SetBool("isClimbing",true);
        }
        else
        {
            playLADDER.gravityScale = 4f;
            animator.SetBool("isClimbing",false);
        }
    }

    // WHEN PLAYER COLLIDING WITH ENEMIES
    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if(collisionInfo.collider.tag == "enemy")
        {
            playerRB.AddForce(forceDirection*thrust,ForceMode2D.Impulse);
            animator.SetBool("isTouch",true);
            health();
        }
        else if(collisionInfo.collider.tag == "points")
        {
            totalCherry = totalCherry+1;
           string TotalCherry = totalCherry.ToString();
            FindObjectOfType<score>().point(TotalCherry);
        }
        //  KILLING ENEMYBEAR
        else if(collisionInfo.collider.tag == "head")
        {
            FindObjectOfType<bearMove>().bearLife();
             FindObjectOfType<deathBEAR>().deathREALBEAR();
            FindObjectOfType<deathBEAR>().Invoke("stopAnimation",deathbearDelay);
        }
        else if(collisionInfo.collider.tag == "door")
        {
            Invoke("levelComplete",levelCompleteAnimationDelay);
            Invoke("nextLevel",nextLevelDealy);
        }
        // LADDER CLIMBING 
        if(collisionInfo.collider.tag == "ladder")
        {
            isLadder = true;
            // Debug.Log("ladderIN!");
        }
        
    }

    void OnCollisionExit2D(Collision2D collisionInfo)
    {
        // LADDER CLIMBING
        if(collisionInfo.collider.tag == "ladder")
        {
            isLadder = false;
            isClimbing = false;
            Debug.Log("ladderOUT!");
        }
    }
    // animation of getting hurt stop once player landed on ground after getting hit by enemy
    public void onHitting()
    {
        animator.SetBool("isTouch",false);
    }

    // ANIMATION FOR LANDING ON GROUND
    public void onLanding()
    {
        animator.SetBool("isJump",false);
    }

    // FOR CROUCHING
    public void onCrouching(bool isC)  // isC  variable is controlled by character controller and that is sent to animator. i.e if we press 's' croucvh abled and isC set to be true by character cintroller.
    {
        animator.SetBool("isCrouch",isC);
    }

    // PLAYER HEALTH

    void health()
    {
        playerHealth = playerHealth - 20;
    }
    
    void death()
    {
        sp.enabled = false;
    }

    void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void levelComplete()
    {
        completeLevelUI.SetActive(true);
    }

    void nextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    // CLIMBING LADDER
    // INSTEAD OF THIS USE ONCOLLISION ENTER AND EXIT 
    // void OnTriggerEnter2D(Collider2D collider)
    // {
    //     if(collider.CompareTag("ladder"))
    //     {
    //         Debug.Log("ladderIN!");
    //     }
    // }

    // void OnTriggerExit2D(Collider2D collider)
    // {
    //     if(collider.CompareTag("ladder"))
    //     {
    //         Debug.Log("laddOUT!");
    //     }
    // }
}
