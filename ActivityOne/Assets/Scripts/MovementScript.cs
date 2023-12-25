using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public float MoveSpeed = 10f;
    public int PlayerStealth;
    
    
// Update is called once per frame
    void FixedUpdate()
    { 
        PlayerControls(); // checks for player movement by calling the function in the FixedUpdate.
    }

    void PlayerControls()
    {
        //Move player Left and Right
        float MoveX = Input.GetAxis("Horizontal") * MoveSpeed;
        transform.Translate(MoveX *Time.deltaTime, 0, 0);

        //Move player Left and Right
        float MoveY = Input.GetAxis("Vertical") * MoveSpeed;
        transform.Translate(0, MoveY *Time.deltaTime, 0, 0);
        
    }

    void StealthCounter() //Function that checks for player stealth (HARDCODED, FOR REFERENCES)
    {
        PlayerStealth = 100;

        if (PlayerStealth >= 50)
        {
            Debug.Log("Warning! Your Stealth is Getting Low, Move away from towers to regenerate");
        }
        
        else if (PlayerStealth == 0)
        {
            PlayerDeath();
        }
    }

    private void PlayerDeath()
    {
        GameManager.Instance.GameRestart(true);
        StartCoroutine(GameManager.Instance.DisplayScene());
    }
}
