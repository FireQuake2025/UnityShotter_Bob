using UnityEngine;
using TMPro;
using UnityEditor;
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public static int score;
    public static int highScore;
    public TextMeshProUGUI text;
    public TextMeshProUGUI textHighScore;
    
    private void Awake()
    {
        Instance = this;
        score = 0;
        textHighScore.text = "High Score: " + highScore;
        LoadGameState();
    }

    public void ShowScore()
    {
        
        if (score > highScore)
        {
            highScore = score;
            textHighScore.text = "High Score: " + highScore;
            SaveGameState();
        }
    }
    // Update is called once per frame
    void Update()
    {

        text.text = "Score: " + score;
        if (Input.GetKey(KeyCode.Backspace))
        {
            SaveGameState();
        }
        if (Input.GetKey(KeyCode.L))
        {
            LoadGameState();
        }

    }

    public void SaveGameState()
    {
        PlayerPrefs.SetInt("HighScore", score);
    }

    public void LoadGameState() 
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScore = PlayerPrefs.GetInt("HighScore");
        }
        else
        {
            highScore = 0;
            PlayerPrefs.SetInt("HighScore", highScore);
        }
    }
}
