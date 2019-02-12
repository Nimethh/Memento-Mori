using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMinionMovement : MonoBehaviour
{
    private Transform transform;
    [SerializeField]
    private float speed;

    void Start()
    {
        transform = GetComponent<Transform>();
    }

    void Update()
    {
        transform.position = transform.position + (transform.right * -1 * speed);
    }

}
