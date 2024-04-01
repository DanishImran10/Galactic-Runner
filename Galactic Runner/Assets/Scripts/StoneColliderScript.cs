using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneColliderScript : MonoBehaviour
{
    public GameObject stoneprefab;
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
        if(collision.gameObject.name.StartsWith("PlayerCollider"))
        {
            PlayerScript.firecount++;
            stoneprefab.GetComponent<StoneScript>().HasCollided = true;
        }
    }
}
