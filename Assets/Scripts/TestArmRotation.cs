using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestArmRotation : MonoBehaviour
{

    private int rotationOffset = 0;
    [SerializeField]
    private float minAngle;
    [SerializeField]
    private float maxAngle;


    private void Start()
    {
        minAngle = -70;
        maxAngle = 50;
    }

    void Update()
    {
        ////Added 2019-03-18
        if (Time.timeScale == 0)
            return;

        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();

        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg; //Finding the angle in degrees
        //Debug.Log(rotationZ);

        //transform.rotation = Quaternion.Euler(0f, 0f, rotationZ + rotationOffset);
        

        if (rotationZ > 90)
        {
            rotationZ = 180 + rotationZ;
            //transform.localScale = new Vector3(1,1,1);
        }
        else if (rotationZ < -90)
        {
            rotationZ = 180 +rotationZ;
            //transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            //transform.localScale = new Vector3(1,1,1);

        }

        //rotationZ = Mathf.Clamp(rotationZ, minAngle, maxAngle);
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ + rotationOffset);


    }
}
