﻿using UnityEngine;
using System.Collections;

public class DangerZoneReaction : MonoBehaviour
{
    private Animator anim;
    Transform tran;

    void Start ()
    {
        tran = GetComponent<Transform>();
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (tran.position.y < (Edges.botEdge+Edges.topEdge)/3.0f)
        {
            anim.SetTrigger("Boom");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //if (other.gameObject.name == "Hand")
        //{
           // if (!other.gameObject.GetComponent<HandReaction>().invincible)
            {
                anim.SetTrigger("Boom");
            }
        //}
    }

}
