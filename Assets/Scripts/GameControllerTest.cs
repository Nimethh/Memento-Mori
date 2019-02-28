using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[System.Serializable]
public class Wave
{
    public string name;
    public GameObject[] enemies;
    public int numberOfEnemies;
    public float spawnWait;
    public float nextWaveWait;
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
    private int nextWave = 0;
    public float timeBetweenWaves;
    [SerializeField]
    private float nextWaveCountDown;

    public FixedWave[] fixedWaves;
    private int nextFixedWave = 0;
    public float timeBetweenFixedWaves;
    [SerializeField]
    private float nextFixedWaveCountDown;

    private int enemyType;
    public Vector2 spawnValues;
    public GameObject minion;

    private SpawnState state = SpawnState.COUNTING;
    private FixedSpawnState fixedState = FixedSpawnState.SPAWNING;


    void Start()
    {
        nextWaveCountDown = timeBetweenWaves;
        //nextFixedWaveCountDown = timeBetweenFixedWaves;
    }

    void Update()
    {
        
        if (state == SpawnState.SWITCHINGWAVES && waves.Length != 0)
        {
            WaveCompleted();
        }
        if (fixedState == FixedSpawnState.SWITCHINGWAVES && fixedWaves.Length != 0 )
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
        else if (fixedState == FixedSpawnState.COUNTING)
            nextFixedWaveCountDown -= Time.deltaTime;

        if (nextWaveCountDown <= 0 && state != SpawnState.DONESPAWNING)
        {
            if (state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWaves(waves[nextWave]));
            }
        }
        else if(state == SpawnState.COUNTING)
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
        //state = SpawnState.SWITCHINGWAVES;
        fixedState = FixedSpawnState.SWITCHINGWAVES;

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
        //fixedState = FixedSpawnState.SWITCHINGWAVES;
        // check if nextWave/ nextFixedWave is > 0 if so just switch the opposite wave otherwise if it's == 0 we just start counting.
        state = SpawnState.SWITCHINGWAVES;

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
        if (nextFixedWave + 1 > fixedWaves.Length - 1 || GameObject.FindGameObjectWithTag("ControlRobot") != null)
        {
            fixedState = FixedSpawnState.DONESPAWNING;
            //nextFixedWave = 0;
        }
        else
        {
            nextFixedWave++;
        }
    }
}
