using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Reference to the Player script
    public Player player;

    // Reference to the UI text displaying the score
    public Text scoreText;

    // Reference to the play button GameObject
    public GameObject playButton;

    // Reference to the game over GameObject
    public GameObject gameOver;

    // Variable to store the current score
    private int score;

    // Called when the script instance is being loaded
    private void Awake()
    {
        // Set the target frame rate to 60 frames per second
        Application.targetFrameRate = 60;

        // Pause the game initially
        Pause();
    }

    // Method to start the game
    public void Play()
    {
        // Initialize the score to zero and update the score text
        score = 0;
        scoreText.text = score.ToString();

        // Disable the play button and game over UI
        playButton.SetActive(false);
        gameOver.SetActive(false);

        // Set the time scale to 1 (normal speed), enable the player, and clear existing pipes
        Time.timeScale = 1f;
        player.enabled = true;

        // Find all existing Pipes objects and destroy them
        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }

    // Method to temporarily pause the game
    public void TempPause()
    {
        // Pause the game and activate the play button
        Pause();
        playButton.SetActive(true);
    }

    // Method to pause the game
    public void Pause()
    {
        // Set the time scale to 0 (paused) and disable the player
        Time.timeScale = 0f;
        player.enabled = false;
    }

    // Method to handle game over
    public void GameOver()
    {
        // Activate the game over UI and play button
        gameOver.SetActive(true);
        playButton.SetActive(true);

        // Pause the game
        Pause();
    }

    // Method to increase the score
    public void IncreaseScore()
    {
        // Increment the score and update the score text
        score++;
        scoreText.text = score.ToString();
    }
}
