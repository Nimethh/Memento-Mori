
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestUpgradeCollider : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.tag != "PlayerCube")
        {
            return;
        }

        PlayerUpgradeController controller = collision.GetComponent<PlayerUpgradeController>();

        if(controller == null)
        {
            Debug.Log("Player did not have a controller.");
        }

        Debug.Log("Should be calling EquipUpgrade()");
        controller.EquipUpgrade("HeadUpgrade");
        controller.EquipUpgrade("ArmUpgrade");
        Destroy(this.gameObject);
    }
}
