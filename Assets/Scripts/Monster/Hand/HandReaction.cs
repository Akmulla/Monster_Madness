using UnityEngine;
using System.Collections;

public class HandReaction : MonoBehaviour
{
    Animator anim;
    public bool invincible;
    Grab grab;

	void Start ()
    {
        grab = GetComponent<Grab>();
        anim = GetComponentInChildren<Animator>();
        invincible = false;
	}
	
    void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.gameObject.CompareTag("Fire")) && (!invincible))
        {
            StartCoroutine(Burn());
        }
    }

    IEnumerator Burn()
    {
        anim.SetBool("Burn", true);
        invincible = true;
        grab.stunned = true;
        yield return new WaitForSeconds(2.0f);
        anim.SetBool("Burn", false);
        invincible = false;
        grab.stunned = false;
    }

    //public void GetHit()
    //{
    //    anim.SetBool("Burn", true);
    //    damageEnd = Time.time + damageDuration;
    //    invincibleEnd = Time.time+invincibleDuration;
    //    invincible = true;
    //    head.invincible = true;
    //    head.Burn();
    //}

    //void Update()
    //{
        //if (Time.time > damageEnd)
        //{
        //    anim.SetBool("Burn", false);
        //    anim.SetBool("Invincible", true);
        //}
        //if (Time.time > invincibleEnd)
        //{
        //    anim.SetBool("Invincible", false);
        //    invincible = false;
        //}
    //}

    //public void GetInvincible()
    //{
    //    anim.SetBool("Invincible", true);
    //    invincibleEnd = Time.time + invincibleDuration;
    //    invincible = true;
    //}
}
