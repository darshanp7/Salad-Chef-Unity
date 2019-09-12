using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    private Player player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (player == null)
        {
            player = other.gameObject.GetComponent<Player>();
            player.canThrowSalad = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (player?.gameObject == other.gameObject)
        {
            player.canThrowSalad = false;
            player = null;
        }
    }
}
