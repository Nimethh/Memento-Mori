﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour
{
    [SerializeField]
    private float lifeTime;

    void Start()
    {
        lifeTime = 20.0f;
    }
    void Update()
    {
        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }
        else
            lifeTime -= Time.deltaTime;
    }

}