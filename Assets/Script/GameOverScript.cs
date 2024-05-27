using UnityEngine;
using TMPro;

public class GameOverScript : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    void Start()
    {
        scoreText.text = "Score: " + ScoreManager.instance.score;
    }
}
