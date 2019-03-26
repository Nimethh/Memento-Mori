using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}

public class PlayerController : MonoBehaviour
{
    public float speed;

    public Boundary boundary;

    // Mobile controls
    private Joystick movJoystick;

    [SerializeField]
    private CommanderHealth commanderHealthScript;
    
    Rigidbody2D rb;

	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        
        PlayerMobileControls mobileControls = GetComponent<PlayerMobileControls>();
        if(mobileControls != null)
            movJoystick = mobileControls.movJoystick;
	}
    

    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement;
        
        if(movJoystick != null) {
            movement = new Vector2(movJoystick.Horizontal, movJoystick.Vertical);
        } else {
            movement = new Vector2(moveHorizontal, moveVertical);
        }

        movement.Normalize();

        rb.velocity = movement * speed;
        rb.position = new Vector2(Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
                                  Mathf.Clamp(rb.position.y, boundary.yMin, boundary.yMax));
	}
}
