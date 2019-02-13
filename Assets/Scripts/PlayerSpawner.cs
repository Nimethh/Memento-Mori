using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject player;
    GameObject playerCopy;

    [SerializeField]
    private int lives;
    [SerializeField]
    private bool isInvulnerable;
    [SerializeField]
    private float invulnerabilityCounter;
    [SerializeField]
    private float invulnerabilityTime;

    // Start is called before the first frame update
    void Start()
    {
        lives = 3;
        isInvulnerable = false;
        invulnerabilityTime = 3f;
        SpawnPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerCopy == null && lives >= 0)
        {
            SpawnPlayer();
        }
    }
    void SpawnPlayer()
    {
       playerCopy = (GameObject)Instantiate(player, transform.position, Quaternion.identity);
    }

}
