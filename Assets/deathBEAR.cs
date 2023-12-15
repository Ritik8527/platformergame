using UnityEngine;

public class deathBEAR : MonoBehaviour
{
    public Animator animator;
    public Transform bearPosition;
    GameObject x;

    public void deathREALBEAR()
    {
        animator.SetBool("isDeath",true);
    }    
    public void stopAnimation()
    {
        animator.SetBool("isDeath",false);
    }
    
}
