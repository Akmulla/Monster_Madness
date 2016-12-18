using UnityEngine;
using System.Collections;

public class DestroyOnExit : MonoBehaviour
{
    Pool pool;
    Transform tran;

    void Start()
    {
        tran = GetComponent<Transform>();
        pool = GetComponent<EnemyInfo>().pool;
    }

    void Update()
    {
        if ((tran.position.x < Edges.leftEdge) || (tran.position.x > Edges.rightEdge) ||
             (tran.position.y < Edges.botEdge))
        {
            pool.Deactivate(gameObject);
        }
    }
}
