﻿ using UnityEngine;
using System.Collections;

public class VerticalMove : MonoBehaviour
{
    public static VerticalMove vert_move;
    public static Transform monster_head;
    public float maxSpeed;
    [SerializeField]
    float speed;
	
    void Awake()
    {
        vert_move = this;
        monster_head = gameObject.transform;
    }

    public float Speed
    {
        get
        {
            return speed;
        }
        set
        {
            if (value < 0)
                speed = 0;
            else
                if (value > maxSpeed)
                speed = maxSpeed;
            else
                speed = value; 
        }
    }

    void Start()
    {
        StartCoroutine(IncreaseSpeedByTime());
    }

	void Update ()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    public void SlowDown()
    {
        Speed -= 0.5f;
    }

    public void Sprint()
    {
        StartCoroutine(SprintCoroutine());
    }

    IEnumerator SprintCoroutine()
    {
        Speed += 1.5f;
        yield return new WaitForSeconds(1.5f);
        Speed -= 1.5f;
    }

    IEnumerator IncreaseSpeedByTime()
    {
        while (true)
        {
            Speed += 0.1f;
            yield return new WaitForSeconds(1.0f);
        }
    }
}
