using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[System.Serializable]
public class _Wave
{
    public string _name;
    public GameObject[] _enemies;
    public int _numberOfEnemies;
    public float _spawnWait;
    public float _nextWaveWait;
}

[System.Serializable]
public class _FixedWave
{
    public string _name;
    public GameObject[] _enemies;
    public Transform[] _spawnPosition;
    public int _numberOfEnemies;
    public float _spawnWait;
    public float _nextFixedWaveWait;
}

public enum RANDOMWAVESTATE { COUNTING, SPAWNING, SWITCHINGWAVES, DONESPAWNING }
public enum FIXEDWAVESTATE { COUNTING, SPAWNING, SWITCHINGWAVES, DONESPAWNING }

public class EnemySpawner : MonoBehaviour
{
    public _Wave[] randomWaves;
    private int currentWave = 0;
    [SerializeField]
    private float nextWaveCountDown;

    public _FixedWave[] fixedWaves;
    private int currentFixedWave = 0;
    [SerializeField]
    private float nextFixedWaveCountDown;

    private int enemyType;
    public Vector2 spawnValues;
    public GameObject minion;

    

    private RANDOMWAVESTATE randomWaveState = RANDOMWAVESTATE.COUNTING;
    private FIXEDWAVESTATE fixedWaveState = FIXEDWAVESTATE.COUNTING;


    void Start()
    {
        StartCoroutine(RandomWaveCountDown(randomWaves[currentWave]));
        StartCoroutine(FixedWaveCountDown(fixedWaves[currentFixedWave]));
    }

    void Update()
    {
        // Normal Waves
        if (randomWaves.Length != 0)// Check if we have any normal waves int the waves.
        {
            if (randomWaveState == RANDOMWAVESTATE.SWITCHINGWAVES && randomWaveState != RANDOMWAVESTATE.DONESPAWNING)
            {
                StartCoroutine(RandomWaveCountDown(randomWaves[currentWave]));
            }

            if (nextWaveCountDown <= 0 && randomWaveState != RANDOMWAVESTATE.DONESPAWNING) // Check wave's timer, if not spawn new wave.
            {
                if (randomWaveState != RANDOMWAVESTATE.SPAWNING) // Check if we're not already spawning.
                    StartCoroutine(SpawnRandomWaves(randomWaves[currentWave]));
            }
            else
                nextWaveCountDown -= Time.deltaTime;
        }

        // Fixed Waves
        if (fixedWaves.Length != 0)// Check if we have any waves in the fixedWaves array.
        {
            if(fixedWaveState == FIXEDWAVESTATE.SWITCHINGWAVES && fixedWaveState != FIXEDWAVESTATE.DONESPAWNING)
            {
                StartCoroutine(FixedWaveCountDown(fixedWaves[currentFixedWave]));
            }

            if (nextFixedWaveCountDown <= 0 && fixedWaveState != FIXEDWAVESTATE.DONESPAWNING)
            {
                if (fixedWaveState != FIXEDWAVESTATE.SPAWNING)
                    StartCoroutine(SpawnFixedWaves(fixedWaves[currentFixedWave]));
            }
            else
                nextFixedWaveCountDown -= Time.deltaTime;
        }
        
    }
    
    IEnumerator RandomWaveCountDown(_Wave p_wave)
    {
        if (currentWave + 1 > randomWaves.Length - 1 || GameObject.FindGameObjectWithTag("ControlRobot") != null)
        {
            randomWaveState = RANDOMWAVESTATE.DONESPAWNING;
            //nextWave = 0;
        }
        else
        {
            currentWave++;
        }
        randomWaveState = RANDOMWAVESTATE.COUNTING;
        nextWaveCountDown = p_wave._nextWaveWait;

        yield break;
    }

    IEnumerator SpawnRandomWaves(_Wave p_wave)
    {
        randomWaveState = RANDOMWAVESTATE.SPAWNING;
        Quaternion spawnRotation = Quaternion.identity;

        for (int i = 0; i < p_wave._numberOfEnemies; i++)
        {
            enemyType = Random.Range(0, p_wave._enemies.Length);
            Vector2 spawnPosition = new Vector2(spawnValues.x, Random.Range(-spawnValues.y, spawnValues.y));
            Instantiate(p_wave._enemies[enemyType], spawnPosition, spawnRotation);

            yield return new WaitForSeconds(p_wave._spawnWait);

        }
        randomWaveState = RANDOMWAVESTATE.SWITCHINGWAVES;

        yield break;
    }

 
    IEnumerator FixedWaveCountDown(_FixedWave p_fixedwave)
    {
        if (currentFixedWave + 1 > fixedWaves.Length - 1 || GameObject.FindGameObjectWithTag("ControlRobot") != null)
        {
            fixedWaveState = FIXEDWAVESTATE.DONESPAWNING;
            //nextfixedWave = 0;
        }
        else
        {
            currentFixedWave++;
        }
        fixedWaveState = FIXEDWAVESTATE.COUNTING;
        nextFixedWaveCountDown = p_fixedwave._nextFixedWaveWait;

        yield break;
    }

    IEnumerator SpawnFixedWaves(_FixedWave p_fixedWave)
    {
        fixedWaveState = FIXEDWAVESTATE.SPAWNING;
        Quaternion spawnRotation = Quaternion.identity;

        for (int i = 0; i < p_fixedWave._numberOfEnemies; i++)
        {
            for (int j = 0; j < p_fixedWave._enemies.Length; j++)
            {
                Vector2 spawnPos = p_fixedWave._spawnPosition[j].position;
                Instantiate(p_fixedWave._enemies[j], spawnPos, spawnRotation);
            }
            yield return new WaitForSeconds(p_fixedWave._spawnWait);
        }
        fixedWaveState = FIXEDWAVESTATE.SWITCHINGWAVES;

        yield break;
    }
}
