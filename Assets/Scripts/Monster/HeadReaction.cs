using UnityEngine;
using System.Collections;

public class HeadReaction : MonoBehaviour
{
    Animator anim;
    bool invincible;

	void Start ()
    {
        invincible = false;
        anim = GetComponentInChildren<Animator>();
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Citizen"))
        {
            anim.SetTrigger("Eat");
            VerticalMove.vert_move.Sprint();
        }
        else
            if ((other.gameObject.CompareTag("Slower")) && (!invincible))
            {
                //print(other.gameObject);
                anim.SetTrigger("GetHit");
                VerticalMove.vert_move.SlowDown();
                //invincible = true;
            }
    }
}
