using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor.U2D.Animation;
using UnityEngine;
using UnityEngine.UIElements;

public class Target : MonoBehaviour
{
    
    public GameObject Player;
    public Transform targetRange;

    MovementScript movescript;

    // Update is called once per frame

    void Start()
    {
        movescript = GameObject.FindGameObjectWithTag("Player").GetComponent<MovementScript>();
    }
    void FixedUpdate()
    {
        CalculateRange();
    }


    private void  CalculateRange()
    {
      
        var seg2 = Vector3.Normalize(targetRange.transform.position - Player.transform.position ); //Takes the World Position of the Target Turret (Check if This is possible to be replicated via duplicates)
        var seg1 = Player.transform.position; // Tracks player position in world 
        var dotproduct = seg1.x * seg2.x + seg1.y * seg2.y + seg1.z + seg2.z;
        var referencedotX= seg1.x - seg2.x; // This is responsible for calculating the distance of the two segments.
        var referencedotY = seg1.y - seg2.y;//Debug: fucntion is responsible for checking Y axis Coordinates (WILL BE USED FOR TURRET DIRECTION FEEDBACK SYSTEM)

        Debug.Log($"Dot Product | Product: {dotproduct} / X:{referencedotX} / Y: {referencedotY} | Player Position: {seg1}");

        bool InRange = dotproduct >  15;

        if(InRange)
        {
            Debug.Log($"YOU ARE SPOTTED!! {referencedotX}");
            movescript.Spotted();
            
        }
    }
}

/*
All scripts are based on recording
*/
