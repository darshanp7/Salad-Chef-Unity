using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PickUp : MonoBehaviour
{
    public Sprite[] sprites;
    public int bonusScore;
    public int bonusTime;
    public float bonusSpeed;
    
    PickUps myPickupType;
    private Player player;
    internal int whoCanPickMeUp;
    private int randomPickupType;
        
    public void Start()
    {
        randomPickupType = Random.Range(0, 3);
        myPickupType = (PickUps) randomPickupType;
        //Setting the scale, as sprites used are of not uniform dimentions
        switch (myPickupType)
        {
            case PickUps.Score: this.transform.localScale = new Vector3(0.5f, 0.5f, 1.0f); break;
            case PickUps.Speed: this.transform.localScale = new Vector3(1.6f, 1.6f, 1.0f); break;
            case PickUps.Time: this.transform.localScale = new Vector3(2.0f, 2.0f, 1.0f); break;
        }

        GetComponent<SpriteRenderer>().sprite = sprites[randomPickupType];
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        player = other.gameObject.GetComponent<Player>();
        if (whoCanPickMeUp == player.playerId)
        {
            switch (myPickupType)
            {
                case PickUps.Score:
                    player.Score += bonusScore;
                    break;
                case PickUps.Speed:
                    player.movementComponent.speed += bonusSpeed;
                    break;
                case PickUps.Time:
                    player.timeRemaining += bonusTime;
                    break;
            }
        }
        Destroy(gameObject);
    }
}
enum PickUps
{
    Speed, Time, Score
}
