using UnityEngine;
using System.Collections;

public class RoadToPool : MonoBehaviour
{
    float height;
    Pool pool;
    Transform tran;


    // Use this for initialization
    void Start ()
    {
        tran = GetComponent<Transform>();
        pool = GetComponent<EnemyInfo>().pool;
        height = pool.obj.GetComponent<SpriteRenderer>().sprite.bounds.size.y *
            pool.obj.transform.localScale.y;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (tran.position.y < Edges.botEdge - height-2.0f)
            pool.Deactivate(gameObject);
	}
}
