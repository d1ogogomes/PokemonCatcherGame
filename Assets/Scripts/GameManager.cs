using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; 
    public int currentLevel = 1; 
    public float levelTimeLimit = 60f;
    public Text levelText; 
    public Text timerText; 
    public Text gameOverText; 
    public Text pokeballsLeftText; 
    public ObjectPlacer objectPlacer; 

    private float startTime; 
    private int pokeballsCollected = 0; 
    private bool isGameOver = false; 

    void Start()
    {
        instance = this; 
        StartLevel();
    }

    void Update()
    {
        if (isGameOver) return; 

        float remainingTime = levelTimeLimit - (Time.time - startTime);
        timerText.text = remainingTime.ToString("0.0") + " seconds left!";

        if (remainingTime <= 0)
        {
            Debug.Log("Level failed: Time out!");
            GameOver("Time's up! You lost."); 
        }
    }

    public void OnPokeballCollected()
    {
        pokeballsCollected++;

        if (pokeballsCollected >= currentLevel)
        {
            Debug.Log("Level " + currentLevel + " completed!");
            currentLevel++;
            StartLevel(); 
        }

        UpdatePokeballsLeftText();
    }

    private void StartLevel()
    {
        pokeballsCollected = 0; 
        startTime = Time.time; 
        levelTimeLimit = 60f; 
        isGameOver = false; 

        if (objectPlacer != null)
        {
            objectPlacer.PlaceObjectsOnTerrain();
        }
        else
        {
            Debug.LogError("ObjectPlacer not assigned in GameManager!");
        }

        UpdateUI();
        UpdatePokeballsLeftText();
    }

    private void UpdateUI()
    {
        if (levelText != null)
        {
            levelText.text = "Level: " + currentLevel;
        }

        if (timerText != null)
        {
            timerText.text = levelTimeLimit.ToString("0.0") + "s";
        }
    }

    private void UpdatePokeballsLeftText()
    {
        int pokeballsLeft = currentLevel - pokeballsCollected;
        if (pokeballsLeftText != null)
        {
            pokeballsLeftText.text = "Pokeballs Left: " + pokeballsLeft;
        }
    }

    public void GameOver(string message)
    {
        isGameOver = true; 
        gameOverText.text = message; 
        SceneManager.LoadScene("MainMenu");
    }
}
