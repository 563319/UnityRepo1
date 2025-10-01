using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Unity.Burst.Intrinsics.X86.Avx;

public class ScoreForText : MonoBehaviour
{
    public PlayerScript playerScript;
    public TextMeshProUGUI scoreText;
    
    public int score;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreText.text = "SCORE: " + score.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        score = playerScript.playerScore;
        scoreText.text = "SCORE: " + score.ToString();
        
    }
}
