using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killMethod : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if(collisionInfo.collider.tag == "bearHead")
        {
            FindObjectOfType<score>().print();
        }
    }
}
