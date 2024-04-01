using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 v = transform.position;
        if (v.y < -14f)
            GameObject.Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        transform.Translate(0, -0.2f, 0);
    }
}
