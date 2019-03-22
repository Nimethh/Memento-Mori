using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthProxy : MonoBehaviour, IHealth
{
    public GameObject proxiedHealthHolder;
    public bool active = true;

    public void TakeDamage(int damage)
    {
        if(!active) return;

        IHealth proxiedHealth = proxiedHealthHolder.GetComponent<IHealth>();
        proxiedHealth.TakeDamage(damage);
    }

    public void TakeDamage(float damage)
    {
        if(!active) return;
        
        IHealth proxiedHealth = proxiedHealthHolder.GetComponent<IHealth>();
        proxiedHealth.TakeDamage(damage);
    }

    public float GetHealth()
    {
        if(!active) return -1;
        
        IHealth proxiedHealth = proxiedHealthHolder.GetComponent<IHealth>();
        return proxiedHealth.GetHealth();
    }
}
