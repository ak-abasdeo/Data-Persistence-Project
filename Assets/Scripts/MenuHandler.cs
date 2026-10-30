using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    public TMP_InputField inputField;
    public TextMeshProUGUI nameAndHighScore;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        LoadHighScore();
    }

    void LoadHighScore()
    {
        ScoreManager.instance.LoadScore();
        int highScore = ScoreManager.instance.highScore;
        string playerName = ScoreManager.instance.playerName;
        if(playerName != string.Empty)
        {
            nameAndHighScore.text = "High Score: " + playerName + ": " + highScore;
        }
    }

    void ReadInput()
    {
        string userInput = inputField.text;
        if(userInput == string.Empty)
        {
            userInput = "Anonymous";
        }
        ScoreManager.instance.currentName = userInput;
    }

    public void StartNew()
    {
        ReadInput();
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

}
