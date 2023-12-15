
using UnityEngine;
// REAL GAME SCRIPT

public class pigMOVE : MonoBehaviour
{
    public CharacterController2D pig;

    public float runspeed = 1f;
    float moving;
    int count=0;
    public SpriteRenderer spB;
    public Animator animator;
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
        pig.Move(moving,false,false);
    }
}
