using TMPro;   
using UnityEngine;
using UnityEngine.UI;

public class UIMenuManager : MonoBehaviour
{
    private int bestScore;
    private string playerName;
    
    public TextMeshProUGUI bestScoreTextObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LoadBestScore();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (System.IO.File.Exists(path))
        {
            string json = System.IO.File.ReadAllText(path);
            MainManager.SaveData data = JsonUtility.FromJson<MainManager.SaveData>(json);

            bestScore = data.bestScore;
        }
        playerName = PlayerPrefs.GetString("PlayerName", "Anonymous");

        if (playerName != null)
        {
            bestScoreTextObject.text = $"Best Score : {playerName} : {bestScore}";
        }
    }

    // player name save between scenes & game over
    public void SetPlayerName(string name)
    {
        playerName = name;
        PlayerPrefs.SetString("PlayerName", playerName);
    }
}
