using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class CustomerPlate : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            var player = other.gameObject.GetComponent<Player>();
            if (player.hasSalad)
            {
                this.gameObject.GetComponentInParent<Customer>().ValidateRecievedSalad(player.mySalad, player);
            }
        }
//        if (player == null && OnRecieveSalad != null)
//        {
//            player = other.gameObject.GetComponent<Player>();
//            if (player.hasSalad) OnRecieveSalad(player.mySalad);
//        }
    }

//    private void OnTriggerExit2D(Collider2D other)
//    {
//        if (player?.gameObject == other.gameObject)
//        {
//            player = null;
//        }
//    }
}
 