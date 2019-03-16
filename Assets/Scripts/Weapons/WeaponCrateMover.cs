using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCrateMover : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rigid;
    [SerializeField]
    private float speed;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        speed = 1.5f;
        rigid.velocity = -transform.right * speed;
    }
}
