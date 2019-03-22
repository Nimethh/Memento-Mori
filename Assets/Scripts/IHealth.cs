﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealth
{
    void TakeDamage(int damage);
    void TakeDamage(float damage);
    float GetHealth();

}
