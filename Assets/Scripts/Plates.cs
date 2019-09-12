using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plates : MonoBehaviour
{
    private Player player;
    internal int vegsOnPlate;
    internal Item itemOnPlate;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (player == null)
        {
            player = other.gameObject.GetComponent<Player>();
            if (player.itemsCarrying.Count > 0)
            {
                player.canPlaceOnPlate = true;
            }

            if (vegsOnPlate > 0)
            {
                Debug.Log("Can Pick up from Plate");
                player.canPickUpFromPlate = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (player?.gameObject == other.gameObject)
        {
            Debug.Log("Cannot Pickup From Plate");
            player.canPlaceOnPlate = false;
            player.canPickUpFromPlate = false;
            player = null;
        }
    }
}
