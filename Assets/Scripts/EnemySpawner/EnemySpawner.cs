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
    public bool _randomize;
}

public enum RANDOMWAVESTATE { COUNTING, SPAWNING, SWITCHINGWAVES, DONESPAWNING }
public enum FIXEDWAVESTATE { COUNTING, SPAWNING, SWITCHINGWAVES, DONESPAWNING }

public class EnemySpawner : MonoBehaviour
{
    public _Wave[] randomWaves;
    public int randomWaveStartWait = 5;
    [SerializeField]
    private int currentWave = 0;
    [SerializeField]
    private float nextWaveCountDown;

    public _FixedWave[] fixedWaves;
    public int fixedWaveStartWait = 5;
    [SerializeField]
    private int currentFixedWave = 0;
    [SerializeField]
    private float nextFixedWaveCountDown;

    private int enemyType;
    private int transformIndex = 0;

    public Vector2 spawnValues;
    public GameObject minion;
    public GameObject upgradeUI;
    
    private bool commanderIsSpawned;
    private bool firstRandomWave;
    private bool firstFixedWave;

    public static bool commanderIsDead = false;

    [SerializeField]
    private float timePassed;

    private RANDOMWAVESTATE randomWaveState = RANDOMWAVESTATE.COUNTING;
    private FIXEDWAVESTATE fixedWaveState = FIXEDWAVESTATE.COUNTING;


    void Start()
    {
        firstRandomWave = true;
        firstFixedWave = true;
        StartCoroutine(RandomWaveCountDown(randomWaves[currentWave]));
        StartCoroutine(FixedWaveCountDown(fixedWaves[currentFixedWave]));
        commanderIsSpawned = false;
    }

    void Update()
    {
        timePassed += Time.deltaTime;
        CommanderChecker();
        // Normal Waves
        if (randomWaves.Length != 0)// Check if we have any normal waves in the waves array.
        {
            if (randomWaveState == RANDOMWAVESTATE.SWITCHINGWAVES && randomWaveState != RANDOMWAVESTATE.DONESPAWNING)
            {
                if(currentWave > randomWaves.Length - 1)
                {
                    randomWaveState = RANDOMWAVESTATE.DONESPAWNING;
                }
                else
                    StartCoroutine(RandomWaveCountDown(randomWaves[currentWave])); // start the countDown.
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
                if(currentFixedWave > fixedWaves.Length - 1)
                {
                    fixedWaveState = FIXEDWAVESTATE.DONESPAWNING;
                }
                else
                    StartCoroutine(FixedWaveCountDown(fixedWaves[currentFixedWave]));
            }

            if (nextFixedWaveCountDown <= 0 && fixedWaveState != FIXEDWAVESTATE.DONESPAWNING)// Check wave's timer, if not spawn new wave.
            {
                if (fixedWaveState != FIXEDWAVESTATE.SPAWNING) // Check if we're not already spawning.
                    StartCoroutine(SpawnFixedWaves(fixedWaves[currentFixedWave]));
            }
            else
                nextFixedWaveCountDown -= Time.deltaTime;
        }
        
    }

    IEnumerator RandomWaveCountDown(_Wave p_wave) // start the countdown for the random position wave.
    {
        if (randomWaves.Length != 0)
        {
            //if (currentWave + 1 > randomWaves.Length - 1 || commanderIsSpawned == true)
            if(currentWave > randomWaves.Length - 1)
            {
                yield break;
            }
            else if (commanderIsSpawned == true)// if there is a commander in the scene
            {
                randomWaveState = RANDOMWAVESTATE.DONESPAWNING; // stop spawning more enemies
            }
            else if (firstRandomWave == true)
            {
                randomWaveState = RANDOMWAVESTATE.COUNTING;
                nextWaveCountDown = randomWaveStartWait;
            }
            else
            {
                currentWave++;
                randomWaveState = RANDOMWAVESTATE.COUNTING;
                nextWaveCountDown = p_wave._nextWaveWait;
            }
        }

        yield break;
    }

    IEnumerator SpawnRandomWaves(_Wave p_wave) // spawning waves at a random positions.
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
        if (currentWave + 1 > randomWaves.Length - 1)
        {
            randomWaveState = RANDOMWAVESTATE.DONESPAWNING;
        }
        else
        {
            randomWaveState = RANDOMWAVESTATE.SWITCHINGWAVES;
            firstRandomWave = false;
        }

        yield break;
    }

 
    IEnumerator FixedWaveCountDown(_FixedWave p_fixedwave) // start the countdown for the fixed position wave.
    {
        //if (fixedWaves.Length != 0)
        //{
        if (fixedWaveState != FIXEDWAVESTATE.DONESPAWNING)
        {
            if (currentFixedWave > fixedWaves.Length - 1)
            {
                yield break;
            }
            else if (commanderIsSpawned == true)
            {
                fixedWaveState = FIXEDWAVESTATE.DONESPAWNING; // stop spawning enemies.
            }
            else if (firstFixedWave == true)
            {
                fixedWaveState = FIXEDWAVESTATE.COUNTING;
                nextFixedWaveCountDown = fixedWaveStartWait;
            }
            // if there is a commander in the scene and if it's not outside of the bounds of the array.
            //else if (currentFixedWave + 1 > fixedWaves.Length - 1 || commanderIsSpawned == true)

            else
            {
                currentFixedWave++;
                fixedWaveState = FIXEDWAVESTATE.COUNTING;
                nextFixedWaveCountDown = p_fixedwave._nextFixedWaveWait;
            }
        }
        //}
        yield break;
    }

    IEnumerator SpawnFixedWaves(_FixedWave p_fixedWave) // Spawn enemies at a fixed positions.
    {
        fixedWaveState = FIXEDWAVESTATE.SPAWNING;
        Quaternion spawnRotation = Quaternion.identity;

        for (int i = 0; i < p_fixedWave._numberOfEnemies; i++)
        {
            for (int j = 0; j < p_fixedWave._enemies.Length; j++)
            {
                if (p_fixedWave._randomize == false)
                {
                    Vector2 spawnPos = p_fixedWave._spawnPosition[j].position;
                    Instantiate(p_fixedWave._enemies[j], spawnPos, spawnRotation);
                }
                else
                {
                    if(transformIndex + 1 > p_fixedWave._spawnPosition.Length )
                    {
                        transformIndex = 0;
                    }
                    Vector2 spawnPos = p_fixedWave._spawnPosition[transformIndex].position;
                    Instantiate(p_fixedWave._enemies[j], spawnPos, spawnRotation);
                    transformIndex++;
                }
            }
            yield return new WaitForSeconds(p_fixedWave._spawnWait);
        }
        if (currentFixedWave + 1 > fixedWaves.Length - 1)
        {
            fixedWaveState = FIXEDWAVESTATE.DONESPAWNING;
        }
        else
        {
            fixedWaveState = FIXEDWAVESTATE.SWITCHINGWAVES;
            firstFixedWave = false;
        }

        yield break;
    }

    void CommanderChecker()
    {
        if(GameObject.FindGameObjectWithTag("Commander") != null)
        {
            commanderIsSpawned = true;
        }
        
        if (commanderIsSpawned == true && GameObject.FindGameObjectWithTag("Commander") == null)
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            //commanderIsDead = true;
            upgradeUI.SetActive(true);
        }
    }
}
