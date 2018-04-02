using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SubmarineGameManager : MonoBehaviour
{

    [SerializeField]
     Text timeText;
    [SerializeField]
    float GameTimer;

    [SerializeField]
    GameObject EndPanel;

    [SerializeField]
    Text Player1Text;
    [SerializeField]
    Text Player2Text;
    [SerializeField]
    Text Player3Text;
    [SerializeField]
    Text Player4Text;
    [SerializeField]
    Text WInnerText;

    [SerializeField]
    GameObject Player1;
    [SerializeField]
    GameObject Player2;
    [SerializeField]
    GameObject Player3;
    [SerializeField]
    GameObject Player4;

    private int Player1Score = 0;
    private int Player2Score = 0;
    private int Player3Score = 0;
    private int Player4Score = 0;

    public static bool OneScored = false;
    public static bool TwoScored = false;
    public static bool ThreeScored = false;
    public static bool FourScored = false;

    
    

    // Use this for initialization
    void Start()
    {
       

        StartCoroutine(GameisRunning());
    }

    // Update is called once per frame
    void Update()
    {
        GameRunning();
        OnScreenScore();

        
    }

    private IEnumerator GameisRunning()
    {
        yield return new WaitForSecondsRealtime(GameTimer);
        endGame();
    }
    private void OnEnable()
    {
        
    }
    private void endGame()
    {
        Player1.GetComponent<Rigidbody>().useGravity = true;
        Player2.GetComponent<Rigidbody>().useGravity = true;
        Player3.GetComponent<Rigidbody>().useGravity = true;
        Player4.GetComponent<Rigidbody>().useGravity = true;

        EndPanel.SetActive(true);
        if (Player1Score > Player2Score && Player1Score > Player3Score && Player1Score > Player4Score)
            WInnerText.text = "Winner: Player Red";
        else if (Player2Score > Player1Score && Player2Score > Player3Score && Player2Score > Player4Score)
            WInnerText.text = "Winner: Player Blue";
        else if (Player3Score > Player1Score && Player3Score > Player2Score && Player3Score > Player4Score)
            WInnerText.text = "Winner: Player Green";
        else if (Player4Score > Player1Score && Player4Score > Player2Score && Player4Score > Player3Score)
            WInnerText.text = "Winner: Player Yellow";
    }
    private void FixedUpdate()
    {
        ScoreGet();
    }
    private void GameRunning()
    {
        GameTimer -= Time.deltaTime;
        timeText.text = GameTimer.ToString("f0");
    }
    private void ScoreGet( )
    {
        if(OneScored == true)
        {
            Player1Score++;
            OneScored = false;
            
            
        }
        if (TwoScored == true)
        {
            Player2Score++;
            TwoScored = false;
            
        }
        if (ThreeScored == true)
        {
            Player3Score++;
            ThreeScored = false;
        }
        if (FourScored == true)
        {
            Player4Score++;
            FourScored = false;
        }
    }

    private void OnScreenScore()
    {
        if (Player1Score == 0)
            Player1Text.text = "";
        else
            Player1Text.text = Player1Score.ToString();

        if (Player2Score == 0)
            Player2Text.text = "";
        else
            Player2Text.text = Player2Score.ToString();

        if (Player3Score == 0)
            Player3Text.text = "";
        else
            Player3Text.text = Player3Score.ToString();

        if (Player4Score == 0)
            Player4Text.text = "";
        else
            Player4Text.text = Player4Score.ToString();

        if (Player4Score == 0)
            Player4Text.text = "";
        else
            Player4Text.text = Player4Score.ToString();

    }
}
