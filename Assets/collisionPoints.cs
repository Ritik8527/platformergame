using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// REAL GAME SCRIPT

public class collisionPoints : MonoBehaviour
{
    public SpriteRenderer sp;
    public BoxCollider2D bc;

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
       
        if(collisionInfo.collider.tag == "Player")
        {
            sp.enabled = false;
            bc.enabled = false;
        }
    }
}
