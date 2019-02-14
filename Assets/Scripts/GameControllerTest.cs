using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Wave
{
    public GameObject[] enemies;
    public int numberOfEnemies;
    public float spawnWait;
}

public enum SpawnState { COUNTING, SPAWNING, SWITCHINGWAVES }

public class GameControllerTest : MonoBehaviour
{
    public Wave[] waves;
    private int nextWave = 0;
    private int currentWave;
    private int enemyType;
    private int enemyNum;
    public float timeBetweenWaves;
    [SerializeField]
    private float nextWaveCountDown; 
    public Vector2 spawnValues;
    public GameObject minion;

    private SpawnState state = SpawnState.COUNTING;

    void Start ()
    {
        nextWaveCountDown = timeBetweenWaves;

    }
	
	void Update ()
    {
        if (state == SpawnState.SWITCHINGWAVES)
        {
            WaveCompleted();
        }

        if (nextWaveCountDown <= 0)
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
        enemyNum = 0;
        state = SpawnState.SPAWNING;
        Quaternion spawnRotation = Quaternion.identity;
       
        for(int i = 0; i < p_wave.numberOfEnemies; i++)
        {
            enemyType = Random.Range(0, p_wave.enemies.Length);
            Vector2 spawnPosition = new Vector2(spawnValues.x, Random.Range(-spawnValues.y, spawnValues.y));
            if (enemyType == 0)
            {
                Instantiate(p_wave.enemies[enemyType], spawnPosition, spawnRotation);
            }
            else if (enemyType == 1 )
            {
                Instantiate(p_wave.enemies[enemyType], spawnPosition, spawnRotation);
            }
            else if (enemyType == 2)
            {
                Instantiate(p_wave.enemies[enemyType], spawnPosition, spawnRotation);
            }
            else if (enemyType == 3)
            {
                Instantiate(p_wave.enemies[enemyType], spawnPosition, spawnRotation);
            }
            else if (enemyType == 4)
            {
                Instantiate(p_wave.enemies[enemyType], spawnPosition, spawnRotation);
            }
            else if (enemyType == 5)
            {
                Instantiate(p_wave.enemies[enemyType], spawnPosition, spawnRotation);
            }
            else
            {
                Instantiate(minion, spawnPosition, spawnRotation);
            }
            state = SpawnState.SWITCHINGWAVES;
            yield return new WaitForSeconds(p_wave.spawnWait);
        }

       
        yield break;
   
    }

    void WaveCompleted()
    {
        state = SpawnState.COUNTING;
        nextWaveCountDown = timeBetweenWaves;
        if (nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
        }
        nextWave++;
    }
}
