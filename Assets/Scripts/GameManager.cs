using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int score = 0; // Start score at 0
    public static GameManager instance; // Singleton instance
    public TMP_Text scoreText; // TextMeshPro text component for displaying the score

    private void Awake()
    {
        // Ensure there's only one instance of GameManager
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate GameManager objects
        }
    }

    private void Start()
    {
        // Initialize the score display
        scoreText.text = "Score: " + score;
    }

    public void IncrementScore()
    {
        score++;
        Debug.Log("IncrementScore called. Current score: " + score);
        scoreText.text = "Score: " + score;
    }
}
