using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI NormalHighScoretext;

    [SerializeField]
    TextMeshProUGUI HardHighScoretext;
    void Start()
    {

        if (!PlayerPrefs.HasKey("NormalHighScore"))
        {
            PlayerPrefs.SetInt("NormalHighScore", 0);
            NormalHighScoretext.text = "0";
        }
        else
        {
          int  highscore = PlayerPrefs.GetInt("NormalHighScore");
            NormalHighScoretext.text = highscore.ToString();
        }

        if (!PlayerPrefs.HasKey("HardHighScore"))
        {
            PlayerPrefs.SetInt("HardHighScore", 0);
            HardHighScoretext.text = "0";
        }
        else
        {
            int highscore = PlayerPrefs.GetInt("HardHighScore");
            HardHighScoretext.text = highscore.ToString();
        }
    }

   public void LoadScene(int i)
    {
        SceneManager.LoadSceneAsync(i);
    }
}
