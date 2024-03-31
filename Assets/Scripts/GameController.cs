using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
 
    public Vector3 spawnValues;
    public int hazardCount;
    public float esperaEntreAsteroides;
    public float esperaInicial;
    public float esperaEntreOlas;

    private int score;
    public Text scoreText;
    private static int bestScore;
    public Text bestScoreText;

    public GameObject restartGameObject;
    public GameObject gameOverGameObject;
    private bool restart;
    private bool gameOver;


    void Start()
    {
        UpdateSpawnValues();
        restart = false;
        gameOver = false;
        gameOverGameObject.gameObject.SetActive(false);
        restartGameObject.gameObject.SetActive(false);

        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
    }

    void UpdateSpawnValues()
    {
        Vector2 half = Utils.GetHalfDimensionsInWorldUnits();
        spawnValues = new Vector3(half.x - 0.7f, 0f,half.y + 6f);
    }

    private void Update()
    {
        if(restart && Input.GetKeyDown(KeyCode.R))
        {
            Restart();
        }    
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(esperaInicial);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Instantiate(hazard, spawPosition, Quaternion.identity);
                yield return new WaitForSeconds(esperaEntreAsteroides);
            }
            yield return new WaitForSeconds(esperaEntreOlas);

            if (gameOver)
            {
                restartGameObject.gameObject.SetActive(true);
                restart = true;
                break;
            }
        }
            
   }

    public void AddScore(int value)
    {
        score += value;
        if (score > bestScore) // Solo actualizará bestScore cuando score sea mayor que bestScore
        {
            bestScore = score; // score se asignará a bestScore
        }
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Puntos: " + score;
        bestScoreText.text = "Record: " + bestScore; // Se mostrará el valor de bestScore en el texto que asignamos
    }

    public void GameOver()
    {
        gameOverGameObject.gameObject.SetActive(true);
        gameOver = true;
    }
    
}
