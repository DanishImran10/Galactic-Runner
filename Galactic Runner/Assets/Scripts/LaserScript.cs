using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    public GameObject enemyspawner;
    public GameObject spacemanspawner;
    public GameObject explosionprefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 v = transform.position;
        if (v.y > 14f)
            GameObject.Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        transform.Translate(0, 0.5f, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.StartsWith("Enemy"))
        {
            enemyspawner.GetComponent<EnemySpawner>().EnemyKilled(collision);
            GameObject explosion = GameObject.Instantiate(explosionprefab, collision.transform.position, collision.transform.rotation);
            GameObject.Destroy(collision.gameObject);
            GameObject.Destroy(explosion, 0.5f);
            GameObject.Destroy(gameObject);
        }
        if (collision.gameObject.name.StartsWith("Spaceman"))
        {
            spacemanspawner.GetComponent<SpacemanSpawnerScript>().SpacemanKilled(collision);
            GameObject explosion = GameObject.Instantiate(explosionprefab, collision.transform.position, collision.transform.rotation);
            GameObject.Destroy(collision.gameObject);
            GameObject.Destroy(explosion, 0.5f);
            GameObject.Destroy(gameObject);
        }
        if(collision.gameObject.name.StartsWith("Boss"))
        {
            GameObject.Destroy(gameObject);
        }
    }
}
