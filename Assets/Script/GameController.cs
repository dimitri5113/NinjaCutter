using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public List<GameObject> targets;
    private float spawnRate = 1f;
    private int score;
    public TextMeshProUGUI scoreText;


    void Start()
    {
       StartCoroutine(SpawnTarget());
       UpdateScore(0);
    }

    // Update is called once per frame
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
        scoreText.text = "Score" + score;
    }
}