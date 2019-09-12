using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Chef : Player
{
    void AddVegetable()
    {
        if (GetAxisDown(interactAxis) && itemsCarrying.Count < carryingCapacity)
        {
            Debug.Log("Adding Vegetable to HUD");
            Item item = new Item();
            item.itemImage = vegetableAvailable.itemImage;
            item.itemName = vegetableAvailable.itemName;
            itemsCarrying.Push(item);
            for (int i = 0; i < itemsCarrying.Count; i++)
            {
                Debug.Log(itemsHud[i].sprite);
                if (itemsHud[i].sprite == null) 
                { 
                    itemsHud[i].sprite = vegetableAvailable.itemImage; 
                    itemsHud[i].color = new Color(1,1,1,1);
                }
            }
        }
    }

    void PlaceVegOnPlate()
    {
        if (GetAxisDown(interactAxis) && itemsCarrying.Count > 0 && myPlate.vegsOnPlate < 1)
        {
            myPlate.vegsOnPlate += 1;
            var item = itemsCarrying.Pop();
            myPlate.itemOnPlate = item;
            plateSprite.sprite = item.itemImage;
            plateSprite.color = new Color(1,1,1,1);
            Debug.Log(itemsHud.Count);
            for (int i = itemsHud.Count - 1; i >= 0; i--)
            {
                if (itemsHud[i].sprite != null)
                {
                    itemsHud[i].sprite = null;
                    itemsHud[i].color = new Color(1,1,1,0);
                    return;
                }
            }
        }
    }

    void PickUpFromPlate()
    {
        if (GetAxisDown(interactAxis) && itemsCarrying.Count < 2 && myPlate.vegsOnPlate > 0)
        {
            myPlate.vegsOnPlate -= 1;
            itemsCarrying.Push(myPlate.itemOnPlate);
            
            
            
            plateSprite.sprite = null;
            plateSprite.color = new Color(1,1,1,0);
            myPlate.itemOnPlate = null;
        }
    }

    void Update()
    {
        if (canPickUpVegetable)
        {
            AddVegetable();
        }

        if (canPlaceOnPlate)
        {
            PlaceVegOnPlate();
        }

        if (canPickUpFromPlate)
        {
            PickUpFromPlate();
        }
        
    }

    
}
