using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabTreasure : MonoBehaviour {



    [SerializeField]
    AudioSource Pickup;


    public void OnTriggerEnter(Collider other)
    {
        if (SubMovment.PassingNumber == 1)
        {
            Pickup.Play();
            SubmarineGameManager.OneScored = true;
            Destroy(gameObject);
            TreasureManager.ChestGrabbed = true;
        }
        else if (SubMovment.PassingNumber == 2)
        {
            Pickup.Play();
            SubmarineGameManager.TwoScored = true;
            Destroy(gameObject);
            TreasureManager.ChestGrabbed = true;
        }
        else if (SubMovment.PassingNumber == 3)
        {
            Pickup.Play();
            SubmarineGameManager.ThreeScored = true;
            Destroy(gameObject);
            TreasureManager.ChestGrabbed = true;
        }
        else if (SubMovment.PassingNumber == 4)
        {
            Pickup.Play();
            SubmarineGameManager.FourScored = true;
            Destroy(gameObject);
            TreasureManager.ChestGrabbed = true;
        }
       
        
    }
}
