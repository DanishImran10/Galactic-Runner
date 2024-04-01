using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class BossScript : MonoBehaviour
{
    private float moveIntervalMin = 3f;
    private float moveIntervalMax = 6f;
    private float xLimitMin = -10.3f;
    private float xLimitMax = 10.3f;
    private float yLimitMin = 0f;
    private float yLimitMax = 4.68f;

    private Vector2 targetposition;
    private float nextMoveTime;
    private float movespeed = 3f;

    public GameObject bosslaser;
    private float nextfire;

    public float health;
    public Image HealthBar;
    public GameObject explosionprefab;

    private bool HasDestroyed = false;

    void Start()
    {
        health = 100f;

        nextfire = Random.Range(0.5f, 1.5f);
        SetNextMoveTime();
        CalculateRandomTargetPosition();
    }

    void Update()
    {
        if (!HasDestroyed && Time.time >= nextMoveTime)
        {
            CalculateRandomTargetPosition();
            SetNextMoveTime();
        }
        transform.position = Vector2.Lerp(transform.position, targetposition, movespeed * Time.deltaTime);
        Fire();
    }

    void CalculateRandomTargetPosition()
    {
        float randomX = Random.Range(xLimitMin, xLimitMax);
        float randomY = Random.Range(yLimitMin, yLimitMax);
        targetposition = new Vector2(randomX, randomY);
    }

    void SetNextMoveTime()
    {
        nextMoveTime = Time.time + Random.Range(moveIntervalMin, moveIntervalMax);
    }

    private void Fire()
    {
        if (!HasDestroyed && Time.time >= nextfire)
        {
            GameObject Laser = GameObject.Instantiate(bosslaser, transform.position, bosslaser.transform.rotation);
            nextfire = Time.time + Random.Range(0.5f, 1.5f);
            StartCoroutine(InstantiateLasers(Laser));
        }
    }

    IEnumerator InstantiateLasers(GameObject Laser)
    {
        yield return new WaitForSeconds(0.02f);

        float angle1 = Random.Range(5f, 10f);
        float angle2 = Random.Range(-5f, -10f);

        Quaternion rotation1 = Laser.transform.rotation * Quaternion.Euler(0, 0, angle1);
        Quaternion rotation2 = Laser.transform.rotation * Quaternion.Euler(0, 0, angle2);

        GameObject.Instantiate(bosslaser, Laser.transform.position, rotation1);
        GameObject.Instantiate(bosslaser, Laser.transform.position, rotation2);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.StartsWith("Laser"))
        {
            float h = Random.Range(3f, 5f);
            health -= h;
            HealthBar.fillAmount = health / 100f;
            if (health <= 0f)
            {
                GameObject explosion = GameObject.Instantiate(explosionprefab, transform.position, transform.rotation);
                GameObject.Destroy(explosion, 0.5f);
                Invoke("LevelComplete", 5f);
                HasDestroyed = true;
            }
        }
    }

    private void LevelComplete()
    {
        SceneManager.LoadScene("VictoryScene");
    }
}

