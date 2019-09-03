using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VegetableArea : MonoBehaviour
{
    private Player player;
    private Sprite vegetableSprite;
    private string vegetableName;

    private void Start()
    {
        vegetableSprite = this.GetComponent<SpriteRenderer>().sprite;
        vegetableName = this.gameObject.name;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Vegetable " + vegetableName + "other " + other.gameObject.name);
        if (player == null)
        {
            player = other.gameObject.GetComponent<Player>();
            player.canPickUpVegetable = true;
            player.vegetableAvailable.Add(this.vegetableName, this.vegetableSprite);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (player?.gameObject == other.gameObject)
        {
            player.canPickUpVegetable = false;
            player.vegetableAvailable.Clear();
            player = null;
        }
    }
}
