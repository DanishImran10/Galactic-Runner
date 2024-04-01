using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject enemylaserprefab;
    private float LowerRange = 3, HigherRange = 10;
    private float nextfire;

    private bool inposition;

    // Start is called before the first frame update
    void Start()
    {
        nextfire = Random.Range(LowerRange, HigherRange);
        inposition = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (inposition && EnemySpawner.wave == 1)
            Fire();
        if (EnemySpawner.wave != 1)
            Fire();
    }

    private void Fire()
    {
        if (Time.time >= nextfire)
        {
            Quaternion q = transform.rotation;
            q.x = 0; q.y = 0; q.z = 0;
            GameObject.Instantiate(enemylaserprefab, transform.position, q);
            nextfire = Time.time + Random.Range(LowerRange, HigherRange);
        }
    }

    public void SidewaysMovement(int j, float xpos)
    {
        StartCoroutine(MoveSideways(j, xpos));
    }

    IEnumerator MoveSideways(int j, float xpos)
    {
        Vector2 v = transform.position;
        if (j % 2 == 0)
        {
            while (v.x <= xpos)
            {
                transform.Translate(-5f * Time.deltaTime, 0, 0);    //negative x moves the object to the right due to inverted axes
                v = transform.position;
                yield return null;
            }
        }
        else
        {
            while (v.x >= xpos)
            {
                transform.Translate(5f * Time.deltaTime, 0, 0);    //positive x moves the object to the left due to inverted axes
                v = transform.position;
                yield return null;
            }
        }
        inposition = true;
    }
}

