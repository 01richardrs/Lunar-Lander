using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
   private void FixedUpdate() {
       this.transform.Rotate((transform.right + transform.up) *1.0f);
   }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player"){

            Player player = other.GetComponent<Player>();
            player.fuel = 1.0f;
            player.fuelBar.value = player.fuel;
            Destroy(this.gameObject);
        }
    }

}
