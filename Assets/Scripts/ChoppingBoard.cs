using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class ChoppingBoard : MonoBehaviour
{
    private Player player;
    public StringBuilder saladOnBoard;
    
    private void Start()
    {
        saladOnBoard = new StringBuilder();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (player == null)
        {
            player = other.GetComponent<Player>();
            if (player.itemsCarrying.Count > 0)
            {
                player.canChop = true;
            }

            
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (saladOnBoard.Length > 0 && player.itemsCarrying.Count == 0)
        {
            Debug.Log("Can pick up Salad");
            player.canPickUpSalad = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == player?.gameObject)
        {
            player.canPickUpSalad = false;
            player.canChop = false;
            player = null;
        }
    }
    public void AddToSalad(string vegetable)
    {
        saladOnBoard.Append(vegetable);
    }

    public StringBuilder GetSalad()
    {
        return saladOnBoard;
    }

    public void RemoveSaladFromChopBoard()
    {
        saladOnBoard.Clear();
    }
}
