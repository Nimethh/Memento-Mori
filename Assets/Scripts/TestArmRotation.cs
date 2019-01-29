using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestArmRotation : MonoBehaviour
{
    public int rotationOffset = 0;

    void Update()
    {

        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();

        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg; //Finding the angle in degrees
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ + rotationOffset);
    }
}
