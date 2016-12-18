using UnityEngine;
using System.Collections;

public class CitizenMove : MonoBehaviour
{
    public float speed;
    private CitizenReaction react;
    private Rigidbody2D rb;

	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        react = GetComponent<CitizenReaction>();
    }

    void FixedUpdate()
    {
        if (!react.inPanic)
        {
            rb.velocity = Vector2.up * speed;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
}
