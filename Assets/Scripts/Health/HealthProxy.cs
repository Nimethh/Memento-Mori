using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthProxy : MonoBehaviour, IHealth
{
    private GameObject _proxiedHealthHolder;
    public GameObject proxiedHealthHolder {
        get { return _proxiedHealthHolder; }
        set {
            _proxiedHealthHolder = value;
            proxiedHealth = value.GetComponent<IHealth>();
        }
    }
    private IHealth proxiedHealth;

    public void TakeDamage(int damage)
    {
        proxiedHealth.TakeDamage(damage);
    }

    public void TakeDamage(float damage)
    {
        proxiedHealth.TakeDamage(damage);
    }

    public float GetHealth()
    {
        return proxiedHealth.GetHealth();
    }
}
