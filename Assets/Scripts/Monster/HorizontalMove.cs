using UnityEngine;
using System.Collections;

public class HorizontalMove : MonoBehaviour
{
    public float speed;
    float sprite_width;
    public SpriteRenderer body_sprite;
	
    void Start()
    {
        sprite_width = body_sprite.sprite.bounds.extents.x*
            body_sprite.gameObject.gameObject.transform.localScale.x;
    }

	void Update ()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        if ((transform.position.x + sprite_width >= Edges.rightEdge) ||
            (transform.position.x - sprite_width <= Edges.leftEdge))
        {
            speed *= -1;
        }
    }
}
