using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBall : MonoBehaviour
{
    public float movRadius = 3f;
    private Vector3 tmp = new Vector3();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.tmp.Set(this.transform.position.x, this.transform.position.y, this.transform.position.z);

        this.tmp.x += this.movRadius * Mathf.Sin(Time.time);
        this.tmp.y += this.movRadius * Mathf.Sin(Time.time);
        this.tmp.z += this.movRadius * Mathf.Sin(Time.time);

        this.transform.position = tmp;
    }
}
