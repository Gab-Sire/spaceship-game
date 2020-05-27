using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelManager : MonoBehaviour
{
    public GameObject scoreIndicator;
    public GameObject airplanePrefab;
    public GameObject parabolicPrefab;
    public Transform[] spawnPoints;
    public Transform parabolicSpawnPoint;
    private static TMPro.TextMeshProUGUI scoreText;
    private static int remainingEnemiesFromWave;
    private static int wave = 0;
    private static float timer = 0;

    void Start()
    {
        scoreText = scoreIndicator.GetComponent<TMPro.TextMeshProUGUI>();
        scoreText.text = "00000";
        CreateNewEnemiesWave();
        StartCoroutine("CreateNewParabolic");
    }

    void Update()
    {

    }

    public static void UpdateScore(int score)
    {
        scoreText.text = (short.Parse(scoreText.text) + score + "").PadLeft(5, '0'); 
    }

    public void UpdateRemainingEnemiesFromWave(int deaths)
    {
        remainingEnemiesFromWave -= deaths;
        Debug.Log("remaining enemies after death: " + remainingEnemiesFromWave);

        if (remainingEnemiesFromWave <= 0)
        {
            CreateNewEnemiesWave();
        }
    }

    private void CreateNewEnemiesWave()
    {
        if (wave >= 0 && wave <= 1)
        {
            remainingEnemiesFromWave++;
            Instantiate(airplanePrefab, spawnPoints[0]);
        }
        else if (wave >= 2 && wave <= 3)
        {
            int enemiesToSpawn = Random.Range(1,3);
            Debug.Log("enemies spawned: " + enemiesToSpawn);
            remainingEnemiesFromWave += enemiesToSpawn;

            for (int i = 0; i < enemiesToSpawn; i++ )
            {
                Instantiate(airplanePrefab, spawnPoints[i]);
            }
        }
        else if (wave >= 4 && wave <= 6)
        {
            int enemiesToSpawn = Random.Range(2, 4);
            Debug.Log("enemies spawned: " + enemiesToSpawn);
            remainingEnemiesFromWave += enemiesToSpawn;

            for (int i = 0; i < enemiesToSpawn; i++)
            {
                Instantiate(airplanePrefab, spawnPoints[i]);
            }
        }
        else if (wave >= 7)
        {
            int enemiesToSpawn = Random.Range(3, 5);
            Debug.Log("enemies spawned: " + enemiesToSpawn);
            remainingEnemiesFromWave += enemiesToSpawn;

            for (int i = 0; i < enemiesToSpawn; i++)
            {
                Instantiate(airplanePrefab, spawnPoints[i]);
            }
        }

        Debug.Log("remaining enemies after created wave: " + remainingEnemiesFromWave);
        wave++;
    }

    IEnumerator CreateNewParabolic()
    {
        while (true)
        {
            Instantiate(parabolicPrefab, parabolicSpawnPoint.transform.position, parabolicSpawnPoint.transform.rotation);
            yield return new WaitForSeconds(6.0f);
        }
        
    }
}
