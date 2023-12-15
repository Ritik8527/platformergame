using UnityEngine;

public class enemyFOLLOWplayer : MonoBehaviour
{
    
   public Transform playerB;
   public CharacterController2D enemyMOVE;
   public float followSpeed = 1f;
   public Rigidbody2D plB;

   void Update()
   {
   
    if(playerB.position.x > transform.position.x)
    {
        enemyMOVE.Move(followSpeed,false,false);
    }
    else{
        enemyMOVE.Move(-followSpeed,false,false);
    }
    
   }
}
