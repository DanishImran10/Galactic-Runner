using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, -0.15f, 0);
        Vector2 v = transform.position;
        if (v.y < -14f)
            v.y = 14f;
        transform.position = v;
    }
}
