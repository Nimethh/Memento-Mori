using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PrototypeWeaponSpawner : MonoBehaviour
{
    [SerializeField]
    private int prefabsSpawned = 0;
    [SerializeField]
    private GameObject spawnPrefab;
    [SerializeField]
    private Transform spawnPoint;


    void Start()
    {
        spawnPoint = this.transform.Find("SpawnPoint");
    }

    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "PlayerCube")
        {
            SpawnPrefab();
        }
    }

    private void SpawnPrefab()
    {
        if(spawnPoint.childCount == 0)
        {
            GameObject itemToSpawn = Instantiate(spawnPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
            itemToSpawn.gameObject.transform.SetParent(spawnPoint);
            //(GameObject)Instantiate(Resources.Load<GameObject>("ITEMPATH"));
            //is another way to instantiate, might be worth to check it our if we add more spawners
            prefabsSpawned++;
        }
    }
}
