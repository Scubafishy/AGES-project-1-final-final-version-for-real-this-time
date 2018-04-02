using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void resetGame()
    {
        if (Input.GetButtonDown("Fire1")|| Input.GetButtonDown("Fire2") || Input.GetButtonDown("Fire3")|| Input.GetButtonDown("Fire4"))
        {
            SceneManager.LoadScene("OpeningScene");
        }
    }
}
