using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConvoyScript : MonoBehaviour
{
    private float LeftBound = -3.9f, RightBound = 6.8f;
    private string movement;
    private bool inposition;

    // Start is called before the first frame update
    void Start()
    {
        movement = "Right";
        inposition = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (inposition)
        {
            if (transform.position.x >= RightBound)
            {
                movement = "Left";
            }
            if (transform.position.x <= LeftBound)
            {
                movement = "Right";
            }
        }
    }

    private void FixedUpdate()
    {
        if(inposition)
        {
            if (movement == "Right")
            {
                transform.Translate(0.05f, 0, 0);
            }
            if (movement == "Left")
            {
                transform.Translate(-0.05f, 0, 0);
            }
        }
    }


    public void PutConvoyInPosition()
    {
        StartCoroutine(MoveConvoyInPosition());
    }

    IEnumerator MoveConvoyInPosition()
    {
        Vector2 v = transform.position;
        while(v.y > 0.66f)
        {
            transform.Translate(0, -2f * Time.deltaTime, 0);
            v = transform.position;
            yield return null;
        }
        inposition = true;
    }
}
