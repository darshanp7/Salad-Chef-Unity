using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoppingBoard : MonoBehaviour
{
    private Player player;
    public Vegetable[] saladOnBoard;
    
    private void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Entered Chopping Area");
        if (player == null)
        {
            player = other.GetComponent<Player>();
            if (player.itemsCarrying.Count > 0)
            {
                player.canChop = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Exited Chopping Area");
        if (other.gameObject == player?.gameObject)
        {
            player.canPickUpSalad = false;
            player.canChop = false;
            player = null;
        }
    }
}
