using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBodyFlip : MonoBehaviour
{
    private Vector3 normal = new Vector3(1, 1, 1);
    private Vector3 invertedX = new Vector3(-1, 1, 1);

    private Joystick shootJoystick;

    // Start is called before the first frame update
    void Start()
    {
        PlayerMobileControls mobileControls = GameObject.Find("Player").GetComponent<PlayerMobileControls>();
        if(mobileControls != null)
            shootJoystick = mobileControls.shootJoystick;
    }

    // Update is called once per frame
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
