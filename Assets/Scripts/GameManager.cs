using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {  get; private set; }
    private int score;

    private void Awake()
    {
        Instance = this;    
    }

    private void Start()
    {
        Bird.Instance.OnPassingPipe += Instance_OnPassingPipe;
    }

    private void Instance_OnPassingPipe(object sender, System.EventArgs e)
    {
        score++;
    }
    public int GetScore()
    {
        return score;
    }
}
