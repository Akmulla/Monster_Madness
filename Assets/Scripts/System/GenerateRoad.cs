using UnityEngine;
using System.Collections;

public class GenerateRoad : MonoBehaviour
{
    float height;
    Pool pool;
    float edge;
	// Use this for initialization
	void Start ()
    {
        edge = Edges.botEdge;
        pool = GetComponent<Pool>();
        height = pool.obj.GetComponent<SpriteRenderer>().sprite.bounds.size.y * 
            pool.obj.transform.localScale.y;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (Edges.topEdge>edge-height)
        {
            pool.Activate(new Vector2(0.0f, edge), Quaternion.identity);
            edge += height;
        }
	}
}
