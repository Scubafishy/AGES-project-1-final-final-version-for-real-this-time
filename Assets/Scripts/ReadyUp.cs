using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReadyUp : MonoBehaviour
{

    [SerializeField]
    GameObject RedText;
    [SerializeField]
    GameObject BlueText;
    [SerializeField]
    GameObject GreenText;
    [SerializeField]
    GameObject YellowText;
    [SerializeField]
    GameObject StartText;
    

    // Use this for initialization
    void Start ()
    {
		

    }
	
	// Update is called once per frame
	void Update ()
    {
        Getready();
        if(ActivatePlayers.Player1Joined == true && ActivatePlayers.Player2Joined == true)
        {
            StartText.SetActive(true);
            if (Input.GetButtonDown("Fire1"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }

    }
    private void Getready()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ActivatePlayers.Player1Joined = true;
            RedText.SetActive(true);
        }


        if (Input.GetButtonDown("Fire2"))
        {
            ActivatePlayers.Player2Joined = true;
            BlueText.SetActive(true);
        }

        if (Input.GetButtonDown("Fire3"))
        {
            ActivatePlayers.Player3Joined = true;
            GreenText.SetActive(true);
        }

        if (Input.GetButtonDown("Fire4"))
        {
            ActivatePlayers.Player4Joined = true;
            YellowText.SetActive(true);
        }
    }
}
