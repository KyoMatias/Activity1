using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MovementScript : MonoBehaviour
{
    public float MoveSpeed = 10f;

    public float PlayerStealth;
    private const float depri = 10;

    [SerializeField] private GameObject _deathScreen;
    [SerializeField] private TextMeshProUGUI _healthText;


    void Awake()
    {
        //GameManager.OnGameStateChange += GameManagerOnOnGameStateChanged; FIX THIS SHIT!!!
        PlayerStealth = 100; // HARDCODED VARIABLE! USED FOR REFERENCES.
        _healthText.text = PlayerStealth.ToString();
    }

    private void GameManagerOnOnGameStateChanged(GameState obj)
    {
        throw new System.NotImplementedException();
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

         _healthText.text = PlayerStealth.ToString("#.00");
         StealthCounter();
    }

    void LowerStealth()
    {
                PlayerStealth -= depri *Time.deltaTime; //Depriciating health when player is in cone
    }
    void StealthCounter() //Function that checks for player stealth (HARDCODED, FOR REFERENCES)
    {

        if (PlayerStealth <= 50) //Setup for engage at 50 PS
        {
            Debug.Log("Warning! Your Stealth is Getting Low, Move away from towers to regenerate"); 
            //Add Code here for Warning Function [ WarningFunc() ]
        }
        
        else if (PlayerStealth <=0) //Engage PLayerDeath() Function on zero.
        {
            _deathScreen.SetActive(true);
            Debug.Log("PLAYER DEAD!!!");
        }
    }
    
    private void PlayerDeath()
    {
        GameManager.Instance.GameRestart(true);
        StartCoroutine(GameManager.Instance.DisplayScene());
    }
    
}
