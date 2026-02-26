using TMPro;
using UnityEngine;


public class ScoreBoardManager : MonoBehaviour
{
    [Header("DEPENDENCIES")] 
    public gameManager gameManager;
    public GameObject goldMedal;
    public GameObject silverMedal;
    public TextMeshProUGUI currentScore;
    public TextMeshProUGUI highScoreText;

    private void Update()
    {
        currentScore.text = gameManager.getCurrentScore().ToString();
        if (gameManager.getHighScore()<gameManager.getCurrentScore())
        {
            goldMedal.SetActive(true);
            silverMedal.SetActive(false);
            highScoreText.text = gameManager.getHighScore().ToString();
        }
        else if(gameManager.getHighScore()>gameManager.getCurrentScore() ||gameManager.getCurrentScore()==gameManager.getHighScore())
        {
            goldMedal.SetActive(false);
            silverMedal.SetActive(true);
            highScoreText.text = gameManager.getCurrentScore().ToString();
        }
    }
}
