using UnityEngine;
using System.Collections;

public class SpawnWaves : MonoBehaviour
{
    //[Header("Pool")]
    //public Pool citizen_pool;
    //public Pool truck_pool;
    //public Pool box_pool;
    //public Pool fire_Pool;
    public Pool[] pool;
    //[Header("Wave Rates")]
    //public float citizenWaveRate;
    //public float truckWaveRate;
    //public float boxWaveRate;
    //public float dangerZoneWaveRate;
    [Space(20)]
    public float startWait;

    float cell_size;
    [SerializeField]
    float obj_count;
    float edge;
    
    void Start ()
    {
        //StartCoroutine(SpawnCitizen());
        //StartCoroutine(SpawnTruck());
        //StartCoroutine(SpawnBox());
        //StartCoroutine(SpawnDangerZone());
        edge = Edges.topEdge;
        cell_size = (Edges.rightEdge+0.5f - Edges.leftEdge-0.5f) / 5.0f;
    }

    void Update()
    {
        if (Edges.topEdge>edge+cell_size)
        {
            SpawnWave();
            edge = edge+2.0f*cell_size;
        }
    }

    void SpawnWave()
    {
        for (int i=0;i<obj_count;i++)
        {
            if ((Random.value > 0.8f) || (i == 0))
            {
                Vector2 spawn_position = new Vector2(Edges.leftEdge + i * cell_size + Random.Range(-0.5f, 0.5f),
                    Edges.topEdge + cell_size+Random.Range(-0.5f,0.5f));
                pool[Random.Range(0, pool.Length)].Activate(spawn_position, Quaternion.identity);
            }
        }
    }


    //IEnumerator SpawnCitizen()
    //{
    //    while (true)
    //    {
    //        yield return new WaitForSeconds(Random.Range(0f, 2f));
    //        Vector2 spawnPosition = new Vector2(Random.Range((float)Edges.leftEdge + 1.0f,
    //            (float)Edges.rightEdge - 1.0f), Edges.topEdge + 1.0f);
    //        citizen_pool.Activate(spawnPosition, Quaternion.identity);
    //        yield return new WaitForSeconds(citizenWaveRate + Random.value);
    //    }
    //}

    //IEnumerator SpawnTruck()
    //{
    //    yield return new WaitForSeconds(Random.Range(0f, 2f));
    //    while (true)
    //    {
    //        Vector2 spawnPosition = new Vector2(Random.Range((float)Edges.leftEdge, 
    //            (float)Edges.rightEdge), Edges.topEdge + 1.0f);
    //        truck_pool.Activate(spawnPosition, Quaternion.Euler(new Vector3(0f,0f,Random.Range(0f,360f))));
    //        yield return new WaitForSeconds(truckWaveRate + Random.value);
    //    }
    //}

    //IEnumerator SpawnBox()
    //{
    //    yield return new WaitForSeconds(Random.Range(0f, 2f));
    //    while (true)
    //    {
    //        Vector2 spawnPosition = new Vector2(Random.Range((float)Edges.leftEdge,
    //            (float)Edges.rightEdge), Edges.topEdge + 1.0f);
    //        box_pool.Activate(spawnPosition, Quaternion.Euler(new Vector3(0f, 0f, Random.Range(0f, 360f))));
    //        yield return new WaitForSeconds(boxWaveRate + Random.value);
    //    }
    //}

    //IEnumerator SpawnDangerZone()
    //{
    //    yield return new WaitForSeconds(Random.Range(0f,2f));
    //    while (true)
    //    {
    //        Vector2 spawnPosition = new Vector2(Random.Range((float)Edges.leftEdge, 
    //            (float)Edges.rightEdge), Edges.topEdge + 1.0f);
    //        fire_Pool.Activate(spawnPosition, Quaternion.identity);
    //        yield return new WaitForSeconds(dangerZoneWaveRate + Random.value);
    //    }
    //}


}
