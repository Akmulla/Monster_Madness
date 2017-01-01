using UnityEngine;
using System.Collections;

public class Grab : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector3 movement;
    public float speed;
    public float rotationSpeed;
    Touch myTouch;
    public bool stunned;

    void Start()
    {
        stunned = false;
        movement = Vector2.zero;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
    }

    void FixedUpdate()
    {
        rb.velocity = movement;
    }

    void Move()
    {
#if UNITY_EDITOR
        if (((Input.GetMouseButtonDown(0))||(Input.GetMouseButton(0))) && (!stunned))
        {
            Vector3 mousePos = Input.mousePosition;
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(mousePos);
            touchPosition.z = 0;

            //transform.position = Vector3.Lerp(transform.position, touchPosition, speed);
            Vector3 moveDirection = touchPosition - transform.position;
            movement = moveDirection * speed;

            float angle = Mathf.Atan2(moveDirection.x, -moveDirection.y) * Mathf.Rad2Deg;
            //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Lerp(transform.rotation,
                Quaternion.AngleAxis(angle, Vector3.forward), rotationSpeed);
        }
        else
        {
            movement = Vector2.zero;
        }
#else
        if ((Input.touchCount > 0)&& (!stunned))
        {
            myTouch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(myTouch.position);
            touchPosition.z = 0;
   
            //transform.position = Vector3.Lerp(transform.position, touchPosition, speed);
            Vector3 moveDirection = touchPosition - transform.position;
            movement = moveDirection * speed;

            float angle = Mathf.Atan2(moveDirection.x, -moveDirection.y) * Mathf.Rad2Deg;
            //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Lerp(transform.rotation, 
                Quaternion.AngleAxis(angle, Vector3.forward), rotationSpeed);
        }
        else
        {
            movement = Vector2.zero;
        }
#endif
    }

}
