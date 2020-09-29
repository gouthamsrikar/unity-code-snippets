using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyup : MonoBehaviour
{
    public moveup jumpb;
    public moveup jumpa;
    public touchfield tf;
    public float boostSpeed = 20f;
    public FixedJoystick fj;

    public float moveSpeed = 10f;
    public float liftSpeed = 10f;
    public float turnSpeed = 10f;
   
    public float bankSpeed = 10f;


    void RotateUpDown(float axis)
    {
        transform.RotateAround(transform.position, transform.right, -axis * Time.deltaTime);
    }
    void RotateRightLeft(float axis)
    {
        transform.RotateAround(transform.position, Vector3.up, -axis * Time.deltaTime);
    }
    void Update()
    {
        if(jumpb.Pressed)
        {
            transform.Translate(Vector3.forward * boostSpeed * Time.deltaTime);
        }

        if (jumpa.Pressed)
        {
            transform.Translate(-Vector3.forward * boostSpeed * Time.deltaTime);
        }

        float xdis = tf.TouchDist.x;
        float ydis = tf.TouchDist.y;
        RotateRightLeft(-xdis);
        RotateUpDown(ydis);
        float x = fj.Horizontal;
        float y = fj.Vertical;
        if (y >0)
        { transform.Translate(-Vector3.up * moveSpeed * Time.deltaTime,Space.Self );
            y = 0;
        }
        else if(y<0)
        { transform.Translate(Vector3.up * moveSpeed * Time.deltaTime, Space.Self);
            y = 0;
        }

    }
}
    