using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBodyFlip : MonoBehaviour
{
    private Vector3 normal = new Vector3(1, 1, 1);
    private Vector3 invertedX = new Vector3(-1, 1, 1);


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();

        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg; //Finding the angle in degrees
        //Debug.Log(rotationZ);

        //transform.rotation = Quaternion.Euler(0f, 0f, rotationZ + rotationOffset);


        if (rotationZ > 90)
        {
            //rotationZ = 180 + rotationZ;
            //transform.localScale = new Vector3(-1, 1, 1);
            transform.localScale = invertedX;

        }
        else if (rotationZ < -90)
        {
            //rotationZ = 180 + rotationZ;
            //transform.localScale = new Vector3(-1, 1, 1);
            transform.localScale = invertedX;

        }
        else
        {
            //transform.localScale = new Vector3(1, 1, 1);
            transform.localScale = normal;


        }
    }
}
