using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ActivatePlayers : MonoBehaviour
{
    [SerializeField]
    GameObject Player1;
    [SerializeField]
    GameObject Player2;
    [SerializeField]
    GameObject Player3;
    [SerializeField]
    GameObject Player4;

    public static bool Player1Joined = false;
    public static bool Player2Joined = false;
    public static bool Player3Joined = false;
    public static bool Player4Joined = false;

 
	
	// Update is called once per frame
	void Update ()
    {
        TurnOnPlayer();

    }
    private void TurnOnPlayer()
    {
        if (Player1Joined == true)
            Player1.SetActive(true);
        if (Player2Joined == true)
            Player2.SetActive(true);
        if (Player3Joined == true)
            Player3.SetActive(true);
        if (Player4Joined == true)
            Player4.SetActive(true);

    }
}
