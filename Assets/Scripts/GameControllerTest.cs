using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[System.Serializable]
public class Wave
{
    public string name;
    public GameObject[] enemies;
    public string enemyName;
    public int numberOfEnemies;
    public float spawnWait;
}

[System.Serializable]
public class FixedWave
{
    public string name;
    public GameObject[] enemies;
    public Transform[] spawnPosition;
    public int numberOfEnemies;
    public float spawnWait;
}

public enum SpawnState { COUNTING, SPAWNING, SWITCHINGWAVES, DONESPAWNING }
public enum FixedSpawnState { COUNTING, SPAWNING, SWITCHINGWAVES, DONESPAWNING }

public class GameControllerTest : MonoBehaviour
{
    public Wave[] waves;
    public FixedWave[] fixedWaves;
    private int nextWave = 0;
    private int nextFixedWave = 0;
    private int enemyType;
    public float timeBetweenWaves;
    public float timeBetweenFixedWaves;
    [SerializeField]
    private float nextWaveCountDown;
    [SerializeField]
    private float nextFixedWaveCountDown;
    public Vector2 spawnValues;
    public GameObject minion;

    private SpawnState state = SpawnState.COUNTING;
    private FixedSpawnState fixedState = FixedSpawnState.COUNTING;


    void Start()
    {
        nextWaveCountDown = timeBetweenWaves;
        nextFixedWaveCountDown = timeBetweenFixedWaves;
    }

    void Update()
    {
        if (state == SpawnState.SWITCHINGWAVES)
        {
            WaveCompleted();
        }
        if (fixedState == FixedSpawnState.SWITCHINGWAVES && fixedWaves.Length != 0)
        {
            FixedWaveCompleted();
        }
        
        if (nextFixedWaveCountDown <= 0 && fixedState != FixedSpawnState.DONESPAWNING)
        {
            if (fixedState != FixedSpawnState.SPAWNING && fixedWaves.Length != 0 )
            {
                StartCoroutine(SpawnFixedWaves(fixedWaves[nextFixedWave]));
            }
        }
        else
            nextFixedWaveCountDown -= Time.deltaTime;

        if (nextWaveCountDown <= 0 && state != SpawnState.DONESPAWNING)
        {
            if (state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWaves(waves[nextWave]));
            }
        }
        else
            nextWaveCountDown -= Time.deltaTime;
    }

    IEnumerator SpawnWaves(Wave p_wave)
    {
        state = SpawnState.SPAWNING;
        Quaternion spawnRotation = Quaternion.identity;

        for (int i = 0; i < p_wave.numberOfEnemies; i++)
        {
            enemyType = Random.Range(0, p_wave.enemies.Length);
            Vector2 spawnPosition = new Vector2(spawnValues.x, Random.Range(-spawnValues.y, spawnValues.y));
            Instantiate(p_wave.enemies[enemyType], spawnPosition, spawnRotation);

            yield return new WaitForSeconds(p_wave.spawnWait);

        }
        state = SpawnState.SWITCHINGWAVES;

        yield break;

    }

    IEnumerator SpawnFixedWaves(FixedWave p_fixedWave)
    {
       
        fixedState = FixedSpawnState.SPAWNING;
        Quaternion spawnRotation = Quaternion.identity;

        for (int i = 0; i < p_fixedWave.numberOfEnemies; i++)
        {
            for (int j = 0; j < p_fixedWave.enemies.Length; j++)
            {
                Vector2 spawnPos = p_fixedWave.spawnPosition[j].position;
                Instantiate(p_fixedWave.enemies[j], spawnPos, spawnRotation);
            }
            yield return new WaitForSeconds(p_fixedWave.spawnWait);
        }
        fixedState = FixedSpawnState.SWITCHINGWAVES;

        yield break;

    }

    void WaveCompleted()
    {
        state = SpawnState.COUNTING;
        nextWaveCountDown = timeBetweenWaves;
        if (nextWave + 1 > waves.Length - 1)
        {
            state = SpawnState.DONESPAWNING;
            //nextWave = 0;
        }
        else
        {
            nextWave++;
        }
    }

    void FixedWaveCompleted()
    {
        fixedState = FixedSpawnState.COUNTING;
        nextFixedWaveCountDown = timeBetweenFixedWaves;
        if (nextFixedWave + 1 > fixedWaves.Length - 1 || fixedWaves.Length == 0)
        {
            nextFixedWave = 0;
        }
        else
        {
            nextFixedWave++;
        }
    }
}
