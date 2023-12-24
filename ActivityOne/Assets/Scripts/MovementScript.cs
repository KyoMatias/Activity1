using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public float MoveSpeed = 10f;
    
// Update is called once per frame
    void FixedUpdate()
    { 
        //Move player Left and Right
        float MoveX = Input.GetAxis("Horizontal") * MoveSpeed;
        transform.Translate(MoveX *Time.deltaTime, 0, 0);

        //Move player Left and Right
        float MoveY = Input.GetAxis("Vertical") * MoveSpeed;
        transform.Translate(0, MoveY *Time.deltaTime, 0, 0);
    }
}
