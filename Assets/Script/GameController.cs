using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Runtime.CompilerServices;

public class GameController : MonoBehaviour
{
    public List<GameObject> targets;
    public float spawnRate = 1f;
    private int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI lifeText;
    public bool isGameActive;
    public GameObject restartButton;
    public GameObject titleScreen;
    public int lifeAmount = 3;
    public int difficultyActuel=1;
    public float actualspawnRate;


    void Start()
    {
       

    }

    public void StartGame(int difficulty)
    {   
        isGameActive = true;
        score = 0;
        StartCoroutine(SpawnTarget());
        UpdateLife();
        UpdateScore(0);
        titleScreen.gameObject.SetActive(false);
        actualspawnRate = spawnRate /= difficulty;
    }
    void Update()
    {
        
    }
    IEnumerator SpawnTarget()
    {
        while (true)
        {
   
        yield return new WaitForSeconds(spawnRate);
        int index = Random.Range(0, targets.Count);
        Instantiate(targets[index]);

        }
        
    }
    public void UpdateScore (int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score " + score;
        if (score >= 100 && score < 200)
        {
            difficultyActuel = 2;
        }
        if (score >= 200)
        {
            difficultyActuel = 3;
        }
        
    }
    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
        restartButton.SetActive(true);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Life(int amount)

    {
        if (lifeAmount > 0)
            {
                lifeAmount = lifeAmount + amount;
            }
        if (lifeAmount <= 0)
            {
                GameOver();
            }
        UpdateLife();
    }     
    public void UpdateLife()
    {
        lifeText.text = "Life: " + lifeAmount;
    }
    public void UpdateDifficulty()
    {
        if (difficultyActuel == 2 )
        {
            actualspawnRate = spawnRate/=2;
        }
    }
}
