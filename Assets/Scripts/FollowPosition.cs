using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPosition : MonoBehaviour
{
    public float speed;
    
    private Transform player;
    [SerializeField]
    private int damage;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("PlayerCube").transform;
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PlayerCube")
        {
            //if (other.gameObject.GetComponent<IHealth>() == null)
            //{
            //    Debug.Log("No IHealth interface found on the object with an Enemy tag");
            //    return;
            //}

            other.gameObject.GetComponent<IHealth>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
