using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonEgg : MonoBehaviour
{
    public GameObject[] dragons;
    public Transform[] dragonPos;
    private Animator anim;


    void Start()
    {
        //instantiatingSpot.position = new Vector3(transform.position.x, Random.Range(minY, maxY), 0);
    }

    void Update()
    {
        //transform.position = Vector2.MoveTowards(transform.position, instantiatingSpot.position, speed * Time.deltaTime);
        //if (Vector2.Distance(transform.position, instantiatingSpot.position) < 0.2f)
        //{
        //    Instantiate(dragon1, dragon1Spot.position, Quaternion.identity);
        //    Instantiate(dragon2, dragon2Spot.position, Quaternion.identity);
        //    Instantiate(dragon3, dragon3Spot.position, Quaternion.identity);
        //    Instantiate(dragon4, dragon4Spot.position, Quaternion.identity);
        //    Destroy(gameObject);
        //}
    }

    public void InstatiateDragons()
    {
        if (gameObject.transform.parent == null)
        {
            anim = GetComponent<Animator>();
            anim.SetBool("noParent", true);
            for (int i = 0; i < dragons.Length; i++)
            {
                for (int j = 0; j < dragonPos.Length; j++)
                {
                    Instantiate(dragons[i], dragonPos[j].position, Quaternion.identity);
                }
                Destroy(gameObject);
            }
        }
    }
    
}
