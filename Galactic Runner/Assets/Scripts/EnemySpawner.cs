using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    private int sideways_count = 20;
    private int convoy_count = 14;
    public static int enemycount;
    public static int wave;

    public GameObject enemyprefab;
    public GameObject convoyprefab;
    public GameObject stoneprefab;

    private static int collectible;

    public static int level;

    // Start is called before the first frame update
    void Start()
    {
        wave = 1;
        level = 1;

        collectible = UnityEngine.Random.Range(1, 14);
        Sideways();
        enemycount = sideways_count;
    }


    // Update is called once per frame
    void Update()
    {
       
    }

    private void FixedUpdate()
    {
        
    }

    public void EnemyKilled(Collider2D collision)
    {
        EnemyScript[] enemies = FindObjectsOfType<EnemyScript>();
        if (wave == 3 && enemies.Length == collectible)
        {
            GameObject.Instantiate(stoneprefab, collision.transform.position, stoneprefab.transform.rotation);
        }
        if (enemies.Length - 1 == 0)
        {
            HandleWaveCompletion();
        }
    }

    private void HandleWaveCompletion()
    {
        wave++;
        if (level == 1 && wave == 2)
        {
            Sideways();
            enemycount = sideways_count;

        }
        if (level == 1 && (wave == 3 || wave == 4))
        {
            Convoy();
            enemycount = convoy_count;
        }

        if (level == 2 && (wave == 2 || wave == 3 || wave == 6))
        {
            Convoy();
            enemycount = convoy_count;
        }
        if (level == 2 && (wave == 4 || wave == 5))
        {
            Sideways();
            enemycount = sideways_count;
        }

        if ((level == 1 && wave == 5) || (level == 2 && wave == 7))
        {
            level++;
            wave = 1;
            Invoke("LevelComplete", 5f);
        }
    }

    private void LevelComplete()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void Sideways()
    {
        Vector2 src;
        src.y = 5.5f;
        float leftdest_x, rightdest_x;
        for (int i = 0; i < 2; i++)
        {
            leftdest_x = -11.1f;
            rightdest_x = 11.1f;
            for (int j = 0; j < 10; j++)
            {
                if (j % 2 == 0)
                {
                    src.x = -13.8f;
                    GameObject enemy = GameObject.Instantiate(enemyprefab, src, enemyprefab.transform.rotation);
                    EnemyScript ES = enemy.GetComponent<EnemyScript>();
                    ES.SidewaysMovement(j, leftdest_x);
                    leftdest_x += 2.5f;
                }
                else
                {
                    src.x = 13.8f;
                    GameObject enemy = GameObject.Instantiate(enemyprefab, src, enemyprefab.transform.rotation);
                    EnemyScript ES = enemy.GetComponent<EnemyScript>();
                    ES.SidewaysMovement(j, rightdest_x);
                    rightdest_x -= 2.5f;
                }
            }
            src.y -= 1.9f;
        }
    }

    private void Convoy()
    {
        Vector2 v;
        v.x = 1.07f;
        v.y = 8.8f;
        GameObject convoy = GameObject.Instantiate(convoyprefab, v, convoyprefab.transform.rotation);
        ConvoyScript CS = convoy.GetComponent<ConvoyScript>();
        CS.PutConvoyInPosition();
    }
}

