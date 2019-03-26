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

    private Joystick shootJoystick;

    private void Start()
    {
        minAngle = -70;
        maxAngle = 50;

        PlayerMobileControls mobileControls = GameObject.Find("Player").GetComponent<PlayerMobileControls>();
        if(mobileControls != null)
            shootJoystick = mobileControls.shootJoystick;
    }

    void Update()
    {
        ////Added 2019-03-18
        if (Time.timeScale == 0)
            return;

        Vector2 direction;
        float rotationZ;

        if(shootJoystick != null) {
            direction = shootJoystick.Direction;
        } else {
            direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        }

        direction.Normalize();

        rotationZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; //Finding the angle in degrees
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
