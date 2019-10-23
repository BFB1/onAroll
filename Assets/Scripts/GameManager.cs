using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Ekki flókið skrift. Bara að spawna óvinum, stjórna roundum og ljúka leiknum.

    public static GameManager instance;
    
    private Transform m_Player;
    public Transform enemyPrefab;
    public Vector3 area;
    public Terrain terrain;
    
    // Ég nota Fibonacci röðina til að ráða fjölda óvina í hverri lotu.
    private readonly Fibonacci m_Waves = new Fibonacci();
    private readonly List<Enemy> m_Enemies = new List<Enemy>();
    private int m_Score = 0;

    public int Score => m_Score;

    public bool waveActive = false;
    public bool waveActivated = false;

    // Start is called before the first frame update
    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("There should only be one active GameManager");
        }
        m_Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            SpawnEnemy();
        }

        if (!waveActivated)
        {
            StartNewWave();
            waveActivated = true;
        }

        if (waveActive && m_Enemies.Count == 0)
        {
            waveActive = false;
            waveActivated = false;
        }
    }

    private void SpawnEnemy()
    {
        Vector3 spawnPoint = new Vector3(Random.Range(-area.x, area.x), 0, Random.Range(-area.z, area.z));
        spawnPoint += transform.position;
        spawnPoint.y = terrain.SampleHeight(spawnPoint) + 2;
        Enemy newEnemy = Instantiate(enemyPrefab, spawnPoint, Quaternion.identity).GetComponent<Enemy>();
        newEnemy.target = m_Player;
        m_Enemies.Add(newEnemy);
    }

    public void SpawnNewWave()
    {
        double enemyCount = m_Waves.Next();
        for (double i = 0; i < enemyCount; i++)
        {
            SpawnEnemy();
        }
    }

    private void StartNewWave()
    {
        UiManager.instance.DisplayNextWaveUi();
    }

    public void EnemySlain(Enemy dead)
    {
        m_Enemies.Remove(dead);
        m_Score++;
    }

    public void EndGame()
    {
        ScoreHelper.score = m_Score;
        ScoreHelper.wave = UiManager.instance.WaveNumber;
        SceneManager.LoadScene(2);
    }
}