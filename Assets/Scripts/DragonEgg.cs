using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonEgg : MonoBehaviour
{
    public float speed;
    public float minY;
    public float maxY;

    public Transform dragon1Spot;
    public Transform dragon2Spot;
    public Transform dragon3Spot;
    public Transform dragon4Spot;

    public Transform instantiatingSpot;

    public GameObject dragon1;
    public GameObject dragon2;
    public GameObject dragon3;
    public GameObject dragon4;

    void Start()
    {
        //instantiatingSpot.position = new Vector3(transform.position.x, Random.Range(minY, maxY), 0);
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, instantiatingSpot.position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, instantiatingSpot.position) < 0.2f)
        {
            Instantiate(dragon1, dragon1Spot.position, Quaternion.identity);
            Instantiate(dragon2, dragon2Spot.position, Quaternion.identity);
            Instantiate(dragon3, dragon3Spot.position, Quaternion.identity);
            Instantiate(dragon4, dragon4Spot.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
