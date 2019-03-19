using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommanderColliderDamage : MonoBehaviour
{
    [SerializeField]
    private float damage;
    private Collider2D col;

    void Start()
    {
        damage = 30f;
        col = GetComponent<Collider2D>();
        if(col == null)
        {
            Debug.Log("No collider found on gameObject");
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerCube")
        {
            if (collision.gameObject.GetComponent<IHealth>() == null)
            {
                Debug.Log("No IHealth interface found on the object with an Enemy tag - Called from GunBullet");
                return;
            }

            collision.gameObject.GetComponent<IHealth>().TakeDamage(damage * Time.deltaTime);
            //Debug.Log("Dealing damage");
        }

    }
}
