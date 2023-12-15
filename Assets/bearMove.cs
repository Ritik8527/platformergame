using UnityEngine;
// REAL GAME SCRIPT

public class bearMove : MonoBehaviour
{
    public CharacterController2D bear;
    GameObject b;

    public float runspeed = 1f;
    float moving;
    int count=0;
    int bearHealth = 100;
    public SpriteRenderer spB;
    public float deathDealy = 5f;
    public Animator animator;
    void Awake()
    {
        b = GameObject.Find("bear");
    }
    void Update()
    {
        if(bearHealth<=0)
        {
            bearDeath();
            bearHealth = 100;
        }
    }
    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if(collisionInfo.collider.tag == "turn")
        {
            count++;
        }
        if(count%2==0)
        {
            moving = -runspeed;
        }
        else if(count%2!=0)
        {
            moving = runspeed;
        }
    }

    void FixedUpdate()
    {
        bear.Move(moving,false,false);
    }
    public void bearLife()
    {
        bearHealth = bearHealth - 100;
    }

    void bearDeath()
    {
        b.SetActive(false);
    }
    
   
}
