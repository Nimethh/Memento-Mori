using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeterrenceCheck : MonoBehaviour
{
    private GameObject player;
    [SerializeField]
    private GameObject deterrenceObject;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("PlayerCube");  
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.x > transform.position.x)
        {
            deterrenceObject.SetActive(true);
        }
        else
        {
            deterrenceObject.SetActive(false);
        }
    }
}
