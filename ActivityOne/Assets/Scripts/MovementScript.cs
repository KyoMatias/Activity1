using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor.SceneManagement;

public class MovementScript : MonoBehaviour
{
    public float MoveSpeed = 10f;

    public float PlayerStealth;
    private const float depri = 10;

    [SerializeField] private TextMeshProUGUI _healthText;
    public SceneManager scene;


    void Awake()
    {
        //GameManager.OnGameStateChange += GameManagerOnOnGameStateChanged; FIX THIS SHIT!!!
        PlayerStealth = 100; // HARDCODED VARIABLE! USED FOR REFERENCES.
        _healthText.text = PlayerStealth.ToString();
    }

    private void Start()
    {
        Debug.Log("$Player Stealth Value: " + PlayerStealth);
    }

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


    public void Spotted()
    {
        LowerStealth(true);
         _healthText.text = PlayerStealth.ToString("#.00");
         StealthCounter();
    }

    void LowerStealth(bool status)
    {
        if(status)
        {
                PlayerStealth -= depri *Time.deltaTime; //Depriciating health when player is in cone
        }
            status = false;
    }
    void StealthCounter() //Function that checks for player stealth (HARDCODED, FOR REFERENCES)
    {

        if (PlayerStealth < 0) //Setup for engage at 50 PS
        {
            PlayerDeath();
           SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 0);;// Loads the death screen UI 
        }
    }
    
    private void PlayerDeath()
    {
        LowerStealth(false);
        //GameManager.Instance.GameRestart(true);
       //StartCoroutine(GameManager.Instance.DisplayScene());
    }
    
}
