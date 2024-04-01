using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEmptyScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyEmpty());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DestroyEmpty()
    {
        yield return new WaitForSeconds(1);
        GameObject.Destroy(gameObject);
    }
}
