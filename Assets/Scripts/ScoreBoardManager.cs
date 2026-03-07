using TMPro;
using UnityEngine;


public class ScoreBoardManager : MonoBehaviour
{
    [Header("DEPENDENCIES")] 
    public gameManager gameManager;
    public TextMeshProUGUI currentScore;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI middleScoreText;
    public TextMeshProUGUI lowScoreText;

    private void Update()
    {
        currentScore.text = gameManager.getCurrentScore().ToString() +" Points";
        highScoreText.text = gameManager.getHighScore().ToString()+" Points";
        middleScoreText.text = gameManager.getmiddleScore().ToString()+" Points";
        lowScoreText.text = gameManager.getLowScore().ToString()+" Points";
    }
}
    