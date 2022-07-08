using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;


public class GameManager : MonoBehaviour
{
    public Ghost[] ghosts;
    public Pacman pacman;
    public Transform pellets;

    public GameObject gameOverText;
    public Text scoreText;
    public Text livesText;
    public Text highScore;

    public int NextLevel;

    public GameObject Life1;
    public GameObject Life2;
    public GameObject Life3;
    public GameObject Life4;
    public GameObject Life5;

    public GameObject bonusDisplay;
    public bool bonusLevel;

    public AudioSource GhostEatSound;

    public bool FirstScene;
    public bool HasFire;

    public Text HasGot;
    public Text Times;

    private int PrfabScore;

    public float targetTime;

    public int ghostMultiplier { get; private set; } = 1;
    public int score;
    public int lives { get; private set; }

    private void Start()
    {
        if (PlayerPrefs.GetInt("HighScore") == 0)
        {
            PlayerPrefs.SetInt("HighScore", 10000);
            highScore.text = PlayerPrefs.GetInt("HighScore").ToString();
        }
        if (FirstScene == true)
        {
            PlayerPrefs.SetInt("Score", 0);
        }
        else
        {
            score =+ PlayerPrefs.GetInt("Score");
        }

        scoreText.text = score.ToString().PadLeft(2, '0');

        if (bonusLevel == true)
        {
            bonusDisplay.SetActive(true);
            Invoke(nameof(bonus), 1F);
        }
        

        NewGame();
        SetLives(3);
    }

    private void bonus()
    {
        bonusDisplay.SetActive(false);
    }
    private void Update()
    {
        PrfabScore = PlayerPrefs.GetInt("Score");
        highScore.text = PlayerPrefs.GetInt("HighScore").ToString();
        if (HasGot.text == "true")
        {
            SetScore(score + 100);
            HasGot.text = "false";
        }
        if (lives <= 0 && Input.GetKeyDown(KeyCode.R))
        {
            SetScore(0);
            NewGame();
        }
        if (bonusLevel == true)
        {

            targetTime -= Time.deltaTime;
            Times.text = targetTime.ToString();
            if (targetTime <= 0.0f)
            {
                SceneManager.LoadScene(NextLevel);
            }
        }
    }

    private void NewGame()
    {
        
        SetLives(3);
        NewRound();
    }

    private void NewRound()
    {
        gameOverText.SetActive(false);

        foreach (Transform pellet in pellets)
        {
            pellet.gameObject.SetActive(true);
        }

        ResetState();
    }

    private void ResetState()
    {
        for (int i = 0; i < ghosts.Length; i++)
        {
            ghosts[i].ResetState();
        }

        pacman.ResetState();
    }

    private void GameOver()
    {
        gameOverText.SetActive(true);

        for (int i = 0; i < ghosts.Length; i++)
        {
            ghosts[i].gameObject.SetActive(false);
        }

        pacman.gameObject.SetActive(false);
    }

    private void SetLives(int lives)
    {
        this.lives = lives;

        if (lives < 5)
        {
            lives = 5;
        }

        lifesCheck();
    }
    private void lifesCheck()
    {
        Debug.Log(lives);

        if (lives == 1)
        {
            Life1.SetActive(true);
            Life2.SetActive(false);
            Life3.SetActive(false);
            Life4.SetActive(false);
            Life5.SetActive(false);
        }
        else if (lives == 2)
        {
            Life1.SetActive(true);
            Life2.SetActive(true);
            Life3.SetActive(false);
            Life4.SetActive(false);
            Life5.SetActive(false);
        }
        else if (lives == 3)
        {
            Life1.SetActive(true);
            Life2.SetActive(true);
            Life3.SetActive(true);
            Life4.SetActive(false);
            Life5.SetActive(false);
        }
        else if (lives == 4)
        {
            Life1.SetActive(true);
            Life2.SetActive(true);
            Life3.SetActive(true);
            Life4.SetActive(true);
            Life5.SetActive(false);
        }
        else if (lives == 5)
        {
            Life1.SetActive(true);
            Life2.SetActive(true);
            Life3.SetActive(true);
            Life4.SetActive(true);
            Life5.SetActive(true);
        }
    }

    public void SetScore(int score)
    {
        this.score = score;

        if (PlayerPrefs.GetInt("HighScore") < score)
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScore.text = PlayerPrefs.GetInt("HighScore").ToString();
        }

        scoreText.text = score.ToString().PadLeft(2, '0');
    }

    public void PacmanEaten()
    {
        pacman.DeathSequence();

        SetLives(lives - 1);

        if (lives > 0)
        {
            Invoke(nameof(ResetState), 3f);
        }
        else
        {
            GameOver();
        }
    }

    public void GhostEaten(Ghost ghost)
    {
        GhostEatSound.Play();
        int points = ghost.points * ghostMultiplier;
        SetScore(score + points);

        ghostMultiplier++;
    }

    public void PelletEaten(Pellet pellet)
    {
        pellet.gameObject.SetActive(false);

        SetScore(score + pellet.points);

        if (!HasRemainingPellets())
        {
            pacman.gameObject.SetActive(false);
            PlayerPrefs.SetInt("Score", score);
            Invoke(nameof(EndGame), 3f);

        }
    }

    public void FirePellet(FirePowerUp pellet)
    {
        SetScore(score + pellet.points);
        HasFire = true;
    }

    public void PowerPelletEaten(PowerPellet pellet)
    {
        for (int i = 0; i < ghosts.Length; i++)
        {
            ghosts[i].frightened.Enable(pellet.duration);
        }

        PelletEaten(pellet);
        CancelInvoke(nameof(ResetGhostMultiplier));
        Invoke(nameof(ResetGhostMultiplier), pellet.duration);
    }

    private bool HasRemainingPellets()
    {
        foreach (Transform pellet in pellets)
        {
            if (pellet.gameObject.activeSelf)
            {
                return true;
            }
        }

        return false;
    }

    private void ResetGhostMultiplier()
    {
        ghostMultiplier = 1;
    }

    public void EndGame()
    {
        SceneManager.LoadScene(NextLevel);
    }
}