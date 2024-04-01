using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneScript : MonoBehaviour
{
    public bool HasCollided;

    // Start is called before the first frame update
    void Start()
    {
        HasCollided = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 v = transform.position;
        if (HasCollided || v.y < -14f)
            GameObject.Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        transform.Translate(0, -0.05f, 0);
    }
}
