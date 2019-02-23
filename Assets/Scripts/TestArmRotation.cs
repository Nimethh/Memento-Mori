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

        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();

        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg; //Finding the angle in degrees
        rotationZ = Mathf.Clamp(rotationZ, minAngle, maxAngle);
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ + rotationOffset);

    }
}
