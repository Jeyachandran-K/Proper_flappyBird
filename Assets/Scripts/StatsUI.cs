using TMPro;
using UnityEngine;

public class StatsUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreTextMesh;

    private void Update()
    {
        scoreTextMesh.text = GameManager.Instance.GetHighScore() + "\n" +
                             GameManager.Instance.GetScore();
    }
}
