using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float LeftBound, RightBound;
    private bool boundarybreachleft, boundarybreachright;

    public GameObject laser1;
    public GameObject laser2;
    public GameObject laser3;
    public GameObject laser4;
    public float firerate;
    private float nextfire;

    public static int firecount;

    // Start is called before the first frame update
    void Start()
    {
        nextfire = 0f;
        firecount = 1;

        boundarybreachleft = false;
        boundarybreachright = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= LeftBound)
            boundarybreachleft = true;
        if (transform.position.x >= RightBound)
            boundarybreachright = true;
        if (transform.position.x > LeftBound && transform.position.x < RightBound)
        {
            boundarybreachleft = false;
            boundarybreachright = false;
        }
    }

    void FixedUpdate()
    {
        if (boundarybreachleft == false)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(-0.15f, 0, 0);
            }
        }
        if (boundarybreachright == false)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(0.15f, 0, 0);
            }
        }
        if(Input.GetKey(KeyCode.Space))
        {
            if(Time.time >= nextfire)
            {
                Quaternion q = transform.rotation;
                q.x = 0; q.y = 0; q.z = 0;
                Vector2 v = transform.position;
                switch (firecount)
                {
                    case 1:
                        GameObject.Instantiate(laser1, v, q);
                        break;
                    case 2:
                        v.x += -0.18f;
                        GameObject.Instantiate(laser2, v, q);
                        break;
                    case 3:
                        v.x += -0.39f;
                        GameObject.Instantiate(laser3, v, q);
                        break;
                    default:
                        v.x += -0.56f;
                        GameObject.Instantiate(laser4, v, q);
                        break;
                }
                nextfire = Time.time + 1f / firerate;
            }
        }
    }
}
