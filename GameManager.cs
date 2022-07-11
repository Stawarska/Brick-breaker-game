using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int lives;
    public int score;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public TMP_InputField highScoreInput;
    public bool gameOver;
    public GameObject gameOverPanel;
    public GameObject loadLevelPanel;
    public int numberOfBricks;
    public Transform[] levels;
    public int currentLevelIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        livesText.text = "Lives " + lives;
        scoreText.text = "Score: " + score;
        numberOfBricks = GameObject.FindGameObjectsWithTag("Brick").Length;
        
    }

  
    // lives mechanism
    public void UpdateLives(int changeInLives){
        lives += changeInLives;

        // Check if no lives left and trigger game over
        if (lives <= 0) {
            lives = 0;
            GameOver();
        }

        livesText.text = "Lives " + lives;
    }
    
    //method to monitoring score
    public void UpdateScore (int points){
        score += points;

        scoreText.text = "Score: " + score;
    }
    
    //method to end level and load next or end game if it was the last one
    public void UpdateNumberOfBricks(){
        numberOfBricks--;
        if(numberOfBricks <=0){
            if(currentLevelIndex >= levels.Length - 1) {
                GameOver();
            } else {
                loadLevelPanel.SetActive(true);
                loadLevelPanel.GetComponentInChildren<TextMeshProUGUI>().text = "Level " + (currentLevelIndex + 2);
                gameOver = true;
                Invoke ("LoadLevel", 3f);
            }
        }
    }

    // method to load next level
    void LoadLevel(){
        currentLevelIndex++;
        Instantiate(levels[currentLevelIndex], Vector2.zero, Quaternion.identity);
        numberOfBricks = GameObject.FindGameObjectsWithTag("Brick").Length;
        gameOver = false;
        loadLevelPanel.SetActive(false);
    }

    // method to active game over panel
    void GameOver(){
        gameOver = true;
        gameOverPanel.SetActive(true);
        int highScore = PlayerPrefs.GetInt("HIGHSCORE");
        if(score > highScore) {
            PlayerPrefs.SetInt("HIGHSCORE", score);

            highScoreText.text = "New high score!  ";
            highScoreInput.gameObject.SetActive(true);
        } else {
            highScoreText.text = PlayerPrefs.GetString("HIGHSCORENAME") + "'s " + "high score was " + highScore + "\n" + "Come on, you can beat it!";
        }
    }
    
    //Show the highest score
    public void NewHighScore(){
        string highScoreName = highScoreInput.text;
        PlayerPrefs.SetString("HIGHSCORENAME", highScoreName);
        highScoreInput.gameObject.SetActive(false);
        highScoreText.text =  "Congratulations " + highScoreName + "\n" + "Your new high score is " + score;
    }

    // Play again game at level 1 
    public void PlayAgain(){
        SceneManager.LoadScene("Brick breaker v1.1");
    }

    // Open score board
     public void ScoreBoard(){
        SceneManager.LoadScene("Score Board");
    }

    // Quit game and back to start menu
    public void Quit(){
        SceneManager.LoadScene("Start Menu");
    }
}
