using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerTest : MonoBehaviour
{
    public GameObject enemy;
    public GameObject minion1;
    public GameObject minion2;
    public GameObject minion3;
    public GameObject enemy3;
    public GameObject commander1;
    
    public Vector3 spawnValues;
    public int enemyCounter;
    public float spawnWait;
    public float waveWait;
    public float startWait;

    private bool restart;

    void Start ()
    {
        restart = false;
        StartCoroutine(SpawnWaves());
    }
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
           
            //for (int i = 0; i < enemyCounter; i++)
            //{
            //    Vector3 spawnPosition = new Vector3(spawnValues.x, Random.Range(-spawnValues.y, spawnValues.y), spawnValues.z);
            //    Quaternion spawnRotation = Quaternion.identity;
            //    Instantiate(enemy, spawnPosition, spawnRotation);
            //    yield return new WaitForSeconds(spawnWait);
            //}
            //yield return new WaitForSeconds(waveWait);

            //for (int i = 0; i < enemyCounter; i++) // follow the position of the player.
            //{
            //    Vector3 spawnPosition = new Vector3(spawnValues.x, Random.Range(-spawnValues.y, spawnValues.y), spawnValues.z);
            //    Quaternion spawnRotation = Quaternion.identity;
            //    Instantiate(minion1, spawnPosition, spawnRotation);
            //    yield return new WaitForSeconds(spawnWait);
            //}
            //yield return new WaitForSeconds(waveWait);

            //for (int i = 0; i < enemyCounter; i++) // moves forward and shoots at the position of the player.
            //{
            //    Vector3 spawnPosition = new Vector3(spawnValues.x, Random.Range(-spawnValues.y, spawnValues.y), spawnValues.z);
            //    Quaternion spawnRotation = Quaternion.identity;
            //    Instantiate(minion2, spawnPosition, spawnRotation);
            //    yield return new WaitForSeconds(spawnWait);
            //}
            //yield return new WaitForSeconds(waveWait);

            //for (int i = 0; i < enemyCounter; i++) // movest into random spots in the screen.
            //{
            //    Vector3 spawnPosition = new Vector3(spawnValues.x, Random.Range(-spawnValues.y, spawnValues.y), spawnValues.z);
            //    Quaternion spawnRotation = Quaternion.identity;
            //    Instantiate(minion3, spawnPosition, spawnRotation);
            //    yield return new WaitForSeconds(spawnWait);
            //}
            //yield return new WaitForSeconds(waveWait);

            for (int i = 0; i < 1; i++) // enemy3.
            {
                Vector3 spawnPosition = new Vector3(spawnValues.x, spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(enemy3, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            for (int i = 0; i < 1; i++) // commander.
            {
                Vector3 spawnPosition = new Vector3(spawnValues.x, Random.Range(-spawnValues.y, spawnValues.y), spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(commander1, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }
}
