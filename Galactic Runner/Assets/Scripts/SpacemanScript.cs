using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacemanScript : MonoBehaviour
{
    public GameObject fireballprefab;
    private float LowerRange = 0.2f, HigherRange = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FireShots());
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 v = transform.position;
        if (v.x > 14f)
            GameObject.Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        transform.Translate(0.02f, 0.05f, 0);
    }

    IEnumerator FireShots()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(LowerRange, HigherRange));
            Fire();
        }
    }

    private void Fire()
    {
        
        Vector2 v = transform.position;
        v.x += 0.5f;
        v.y += -1.5f;
        Quaternion q = transform.rotation;
        q.x = 0; q.y = 0; q.z = 0;
        GameObject.Instantiate(fireballprefab, v, q);
    }
}
