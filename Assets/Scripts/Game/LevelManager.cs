using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;
using TMPro;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    GameObject scoreIndicator = default;
    [SerializeField]
    GameObject finalScoreIndicator = default;
    [SerializeField]
    GameObject gameOverPanel = default;
    [SerializeField]
    GameObject airplanePrefab = default;
    [SerializeField]
    GameObject parabolicPrefab = default;
    [SerializeField]
    GameObject skyscrapersPrefab = default;
    [SerializeField]
    Transform[] spawnPoints = default;
    [SerializeField]
    Transform parabolicSpawnPoint = default;

    RectTransform rectTransform;
    GameObject[] skyscrapers;
    TextMeshProUGUI scoreText;
    TextMeshProUGUI finalScoreText;
    static int remainingEnemiesFromWave;
    static int wave = 0;
    static float timer = 6.0f;
    static int playerComponentsFunctioning;
    static bool isGameOver = false;

    void Start()
    {
        playerComponentsFunctioning = 4;
        scoreText = scoreIndicator.GetComponent<TextMeshProUGUI>();
        finalScoreText = finalScoreIndicator.GetComponent<TextMeshProUGUI>();
        scoreText.text = "00000";
        finalScoreText.text = "00000";
        skyscrapers = GameObject.FindGameObjectsWithTag("skyscraper");
        rectTransform = (RectTransform)skyscrapersPrefab.transform;

        StartCoroutine("CreateNewParabolic");
        CreateNewEnemiesWave();
    }

    void Update()
    {
        if (Time.time > timer)
        {
            timer = Time.time + 6.0f;
            StartCoroutine("CreateNewParabolic");
        }
    }

    public void UpdateScore(int score)
    {
        scoreText.text = (short.Parse(scoreText.text) + score + "").PadLeft(5, '0');
        finalScoreText.text = (short.Parse(finalScoreText.text) + score + "").PadLeft(5, '0');
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
            int enemiesToSpawn = Random.Range(1, 3);
            Debug.Log("enemies spawned: " + enemiesToSpawn);
            remainingEnemiesFromWave += enemiesToSpawn;

            for (int i = 0; i < enemiesToSpawn; i++)
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
        Instantiate(parabolicPrefab, parabolicSpawnPoint.transform.position, parabolicSpawnPoint.transform.rotation);
        yield return new WaitForSeconds(6.0f);
    }

    public void LoopSkyscrapers()
    {
        Debug.Log("skyscraper destroyed, creating new one");
        GameObject skyscraper = Instantiate(skyscrapersPrefab, skyscrapers[1].transform.position + new Vector3(rectTransform.rect.width * 4, 0, 0), skyscrapers[1].transform.rotation);

        for (int i = 0; i < skyscrapers.Length - 1; i++)
        {
            skyscrapers[i] = skyscrapers[i + 1];
        }
        skyscrapers[2] = skyscraper;
    }

    public void PlayerComponentKilled(){
        
        playerComponentsFunctioning -= 1;
        Debug.Log("remaining player components: " + playerComponentsFunctioning);

        if (playerComponentsFunctioning <= 0)
        {
            isGameOver = true;
            gameOverPanel.SetActive(true);
        }
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }
}
