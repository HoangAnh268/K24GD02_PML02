using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int score = 0;
    public Text ScoreText;
    public GameObject gameoverPanel;
    public bool isGameStarted = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        //Tao singleton
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    void Start()
    {
        Time.timeScale = 1f; //Game chay bth khi Game chay lai
        ScoreText.text = "0";
        gameoverPanel.SetActive(false);
    }
    public void AddScore()
    {
        score++;
        ScoreText.text = score.ToString();
    }
    public void GameOver()
    {
        Time.timeScale = 0;
        gameoverPanel.SetActive(true);
    }
    
}
