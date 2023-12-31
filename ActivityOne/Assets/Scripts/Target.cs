using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Target : MonoBehaviour
{

    public GameObject Player;
    public Transform targetRange;


    // Update is called once per frame
    void FixedUpdate()
    {
        CalculateRange();
    }


    private void  CalculateRange()
    {
      
        var seg2 = Vector3.Normalize(targetRange.transform.position - Player.transform.position ); //Takes the World Position of the Target Turret (Check if This is possible to be replicated via duplicates)
        var seg1 = Player.transform.position; // Tracks player position in world 
        var referencedotX= seg1.x * seg2.x; // This is responsible for calculating the distance of the two segments.
        var referencedotY = seg1.y *seg2.y;//Debug: fucntion is responsible for checking Y axis Coordinates (WILL BE USED FOR TURRET DIRECTION FEEDBACK SYSTEM)

        Debug.Log($"Dot Product X:{referencedotX} / y: {referencedotY} | Player Position: {seg1}");

        bool InRange = false;// Boolean to be used later

        if(InRange)
        {
            Debug.Log($"YOU ARE IN ENEMY TERRITORY {referencedotX}");
        }
    }
}

/*
All scripts are based on recording
*/