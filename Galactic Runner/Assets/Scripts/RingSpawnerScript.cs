using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingSpawnerScript : MonoBehaviour
{
    public GameObject ring1;
    public GameObject ring2;
    public GameObject ring3;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRings());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnRings()
    {
        while (EnemySpawner.wave != 7)
        {
            yield return new WaitForSeconds(Random.Range(1f, 5f));
            Spawn();
        }
    }

    private void Spawn()
    {
        Vector2 v;
        v.y = 8.4f;
        v.x = Random.Range(-10.16f, 10.16f);
        int ring = Random.Range(1, 4);

        switch (ring)
        {
            case 1:
                GameObject.Instantiate(ring1, v, ring1.transform.rotation);
                break;
            case 2:
                GameObject.Instantiate(ring2, v, ring2.transform.rotation);
                break;
            case 3:
                GameObject.Instantiate(ring3, v, ring3.transform.rotation);
                break;
        }
    }
}
