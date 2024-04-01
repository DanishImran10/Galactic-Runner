using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerColliderScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.StartsWith("Enemy Laser") || collision.gameObject.name.StartsWith("Celestial Ring") || 
            collision.gameObject.name.StartsWith("Fireball") || collision.gameObject.name.StartsWith("Boss Laser"))
        {
            GameObject.Destroy(collision.gameObject);
            SceneManager.LoadScene("GameOver");   
        }
    }
}
