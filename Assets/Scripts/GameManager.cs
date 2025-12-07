using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {  get; private set; }
    private int score;
    private static int highScore;
    private float gameTime;

    private void Awake()
    {
        Instance = this;    
    }

    private void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        Bird.Instance.OnPassingPipe += Instance_OnPassingPipe;
        Bird.Instance.OnHittingPipe += Instance_OnHittingPipe;
    }
    private void Update()
    {
        gameTime += Time.deltaTime;
    }

    private void Instance_OnHittingPipe(object sender, System.EventArgs e)
    {
        OnBirdDeath();
        SceneManager.LoadScene(2);
    }

    private void Instance_OnPassingPipe(object sender, System.EventArgs e)
    {
        score++;
    }
    public int GetScore()
    {
        return score;
    }
    public  int GetHighScore()
    {
         return highScore;
    }
    private void OnBirdDeath()
    {
        if (score > highScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
            PlayerPrefs.Save();
        }
        highScore =PlayerPrefs.GetInt("HighScore", 0);
        
    }
    public float GetGameTime()
    {
        return gameTime;
    }
}
