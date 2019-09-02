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
            itemsCarrying.Push(vegetableAvailable);
            for (int i = 0; i < itemsCarrying.Count; i++) 
            { 
                if (itemsHud[i].sprite.Equals(null)) 
                { 
                    itemsHud[i].sprite = vegetableAvailable.Values.ElementAt(0); 
                    itemsHud[i].color = new Color(1,1,1,1);
                }
            }
        }
    }

    void Update()
    {
        if (canPickUpVegetable)
        {
            AddVegetable();
        }
    }

    
}
