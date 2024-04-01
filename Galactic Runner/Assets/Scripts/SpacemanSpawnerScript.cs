using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpacemanSpawnerScript : MonoBehaviour
{
    public GameObject spaceman;
    private static int spacemancount;
    private int totalspacemen = 100;

    private static int collectible1;
    private static int collectible2;
    public GameObject stoneprefab;

    // Start is called before the first frame update
    void Start()
    {
        spacemancount = 0;

        collectible1 = Random.Range(30, 75);
        collectible2 = Random.Range(75, 100);
        StartCoroutine(SpawnSpacemen());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnSpacemen()
    {
        while (spacemancount <= totalspacemen)
        {
            yield return new WaitForSeconds(Random.Range(1f, 5f));
            Spawn();
        }
        Invoke("LevelComplete", 5f);
    }

    private void LevelComplete()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void Spawn()
    {
        Vector2 v;
        v.x = -13.9f;
        v.y = Random.Range(-1.6f, 2.6f);
        GameObject.Instantiate(spaceman, v, spaceman.transform.rotation);
        spacemancount += 1;
    }

    public void SpacemanKilled(Collider2D collision)
    {
        if (spacemancount == collectible1 || spacemancount == collectible2)
            GameObject.Instantiate(stoneprefab, collision.transform.position, stoneprefab.transform.rotation);
    }
}
