using UnityEngine;
using System.Collections;

public class HelicopterMove : MonoBehaviour
{
    public static Transform helicopter;
    private Rigidbody2D rb;
    public float speed;
    public Transform monster;
    // Use this for initialization

    void Awake()
    {
        helicopter = this.gameObject.GetComponent<Transform>();
    }

    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector3.up * speed;

    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = new Vector2(monster.position.x,transform.position.y);
	}
}
