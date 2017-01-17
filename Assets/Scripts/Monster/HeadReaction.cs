using UnityEngine;
using System.Collections;

public class HeadReaction : MonoBehaviour
{
    Animator anim;
    bool invincible;
    public static HeadReaction head;

    public enum MonsterState { Run,EatHelicopter};
    public MonsterState currentState;
    delegate void UpdateDelegate();
    UpdateDelegate[] updateDelegates;

    void Awake()
    {
        head = this;
        updateDelegates = new UpdateDelegate[2];
        updateDelegates[(int)MonsterState.Run] = Run;
        updateDelegates[(int)MonsterState.EatHelicopter] = EatHelicopter;
        currentState = MonsterState.Run;
    }

    void Start ()
    {
        invincible = false;
        anim = GetComponentInChildren<Animator>();
	}

    public void Burn()
    {
        anim.SetTrigger("Burn");
    }

    

    void OnTriggerEnter2D(Collider2D other)
    {
        if (currentState == MonsterState.Run)
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

    void Update()
    {
        if (updateDelegates[(int)currentState] != null)
        {
            updateDelegates[(int)currentState]();
        }
        
    }

    void Run()
    {
        if (HelicopterMove.helicopter.position.y - transform.position.y < 1.0f)
        {
            anim.SetTrigger("Victory");
            currentState = MonsterState.EatHelicopter;
        }
    }

    void EatHelicopter()
    {
        //если в процессе поедания вертолета, то нихуя не делает
    }
}
