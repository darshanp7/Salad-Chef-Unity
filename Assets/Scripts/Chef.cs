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
        if (Input.GetKeyDown(interactButton) && itemsCarrying.Count < carryingCapacity)
        {
            Debug.Log("Adding Vegetable to HUD");
            Item item = new Item();
            item.itemImage = vegetableAvailable.itemImage;
            item.itemName = vegetableAvailable.itemName;
            itemsCarrying.Push(item);
            for (int i = 0; i < itemsCarrying.Count; i++)
            {
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
        if (Input.GetKeyDown(interactButton) && itemsCarrying.Count > 0 && myPlate.vegsOnPlate < 1)
        {
            myPlate.vegsOnPlate += 1;
            var item = itemsCarrying.Pop();
            myPlate.itemOnPlate = item;
            plateSprite.sprite = item.itemImage;
            plateSprite.color = new Color(1,1,1,1);
            RemoveItem();
        }
    }

    private void RemoveItem()
    {
        for (int i = itemsHud.Count - 1; i >= 0; i--)
        {
            if (itemsHud[i].sprite != null)
            {
                itemsHud[i].color = new Color(1, 1, 1, 0);
                itemsHud[i].sprite = null;
                return;
            }
        }
    }

    void PickUpFromPlate()
    {
        if (Input.GetKeyDown(interactButton) && itemsCarrying.Count < 2 && myPlate.vegsOnPlate > 0)
        {
            Debug.Log("Picking up Vegetable from the plate.......");
            myPlate.vegsOnPlate -= 1;
            itemsCarrying.Push(myPlate.itemOnPlate);

            Debug.Log("items Hud count " + itemsHud.Count);
            int indexToAddItem = 0;
            for (int i = 0; i < itemsHud.Count; i++)
            {
                if (itemsHud[i].sprite == null)
                {
                    indexToAddItem = i;
                    break;
                }
            }
            itemsHud[indexToAddItem].sprite = myPlate.itemOnPlate.itemImage;
            itemsHud[indexToAddItem].color = new Color(1,1,1,1);
            
            plateSprite.sprite = null;
            plateSprite.color = new Color(1,1,1,0);
            myPlate.itemOnPlate = null;
        }
        else
        {
                Debug.Log("Cannot Pick up " + itemsCarrying.Count + " " + myPlate.vegsOnPlate);
        }
    }

    void StartChopping()
    {
        if (Input.GetKeyDown(chopButton) && itemsCarrying.Count > 0)
        {
            StartCoroutine(ChoppingInProgress());
        }
    }

    IEnumerator ChoppingInProgress()
    {
        movementComponent.canMove = false;
        canChop = false;
        choppingIndicator.gameObject.SetActive(true);
        yield return new WaitForSeconds(choppingTime);
        var item = itemsCarrying.Pop();
        myChopBoard.AddToSalad(item.itemName);
        RemoveItem();
        if (chopSprite.sprite == null) chopSprite.sprite = saladSprite;
        chopSprite.color = new Color(1,1,1,1);
        choppingIndicator.gameObject.SetActive(false);
        movementComponent.canMove = true;
        canChop = true;
    }

    void PickUpSalad()
    {
        if (Input.GetKeyDown(interactButton))
        {
            Debug.Log("Picking Up Salad");
            mySalad = myChopBoard.GetSalad();
            chopSprite.sprite = null;
            chopSprite.color = new Color(1,1,1,0);
            mySaladImage.color = new Color(1,1,1,1);
            hasSalad = true;
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

        if (canChop)
        {
            StartChopping();
        }

        if (canPickUpSalad)
        {
            PickUpSalad();
        }
    }

    
}
