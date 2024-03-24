using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

/*
 *
 * This class object Acts as Game Manager which controls Win/Lose and score of the Game
 * 
 */
public class Mananger : MonoBehaviour
{
   

    [SerializeField]
    TextMeshProUGUI HighScoretext;


    [SerializeField]
    TextMeshProUGUI CurrentScoretext;

    [SerializeField]
    TextMeshProUGUI Playerhealthtext;



    int highscore;
    int currentscore=0;

    int PlayerHealth=100;

    [SerializeField]
    MeshRenderer RacketMesh;

    public static Mananger instance;

    [SerializeField]
    float RacketRedValue = 0;

    

    [SerializeField]
    BallSpawner ballspawner;

    [SerializeField]
    GameObject EndCanvas;

    [SerializeField]
    GameObject InfoCanvas;

    [SerializeField]
    bool IsNormalMode;

    [SerializeField]
    int Damage = 16;
    void Awake()
    {

        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;


    }
    private void Start()
    {
      
        if(IsNormalMode)
        {
            if (!PlayerPrefs.HasKey("NormalHighScore"))
            {
                PlayerPrefs.SetInt("NormalHighScore", 0);
                HighScoretext.text = "0";
            }
            else
            {
                highscore = PlayerPrefs.GetInt("NormalHighScore");
                HighScoretext.text = highscore.ToString();
            }
        }
        else
        {
            if (!PlayerPrefs.HasKey("HardHighScore"))
            {
                PlayerPrefs.SetInt("HardHighScore", 0);
                HighScoretext.text = "0";
            }
            else
            {
                highscore = PlayerPrefs.GetInt("HardHighScore");
                HighScoretext.text = highscore.ToString();
            }
        }

        
        CurrentScoretext.text = "0";

        Invoke("StartGame", 2);
    }

    public void StartGame()
    {
        InfoCanvas.SetActive(false);
        ballspawner.enabled = true;
    }

    public void IncreaseScore()
    {
        

        currentscore++;
        CurrentScoretext.text = currentscore.ToString();
        

        if(IsNormalMode)
        {

            if (currentscore > highscore)
            {
                highscore = currentscore;
                PlayerPrefs.SetInt("NormalHighScore", highscore);
                HighScoretext.text = highscore.ToString();
            }

            RacketRedValue += 0.14f;

            if(RacketRedValue>=1f)
            {
                RacketRedValue = 0; 
                RacketMesh.enabled = false;
                GameEnd();
                return;
            }

            RacketMesh.material.SetColor("_EmissionColor", Color.red* Mathf.LinearToGammaSpace(RacketRedValue));
        }
        else
        {
            if (currentscore > highscore)
            {
                highscore = currentscore;
                PlayerPrefs.SetInt("HardHighScore", highscore);
                HighScoretext.text = highscore.ToString();
            }

            RacketRedValue += 0.25f;

            if (RacketRedValue >= 1f)
            {
                RacketRedValue = 0;
                RacketMesh.enabled = false;
                GameEnd();
                return;
            }

            RacketMesh.material.SetColor("_EmissionColor", Color.red * Mathf.LinearToGammaSpace(RacketRedValue));
        }
        
    }
   

    public void PlayerHit()
    {
        PlayerHealth -= Damage;



        if(PlayerHealth<0)
        {
            //game end
            GameEnd();
            Playerhealthtext.text = "0";
            return;
        }
        Playerhealthtext.text = PlayerHealth.ToString();
    }

    public void CoolRacket()
    {
        RacketRedValue = 0;
         RacketMesh.material.SetColor("_EmissionColor", Color.red * Mathf.LinearToGammaSpace(RacketRedValue));

    }

    public void GameEnd()
    {
        ballspawner.NoAttack = true;

        EndCanvas.SetActive(true);
    }

    public void LoadMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void Retry()
    {
       if(IsNormalMode)
        {
            SceneManager.LoadSceneAsync(1);
        }
       else
            SceneManager.LoadSceneAsync(2);
    }
}
