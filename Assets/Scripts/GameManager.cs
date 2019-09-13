using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using System.Text;
using Boo.Lang.Environments;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public Transform customerPrefab;
    public Transform pickupPrefab;
    public GameObject endPanel;
    public Text winnerText;
    public Player player1;
    public Player player2;
    public int maxX;
    public int minX;
    public int maxY;
    public int minY;
    public Vector3 bottomRightBoundary;
    [SerializeField] [Range(1, 5)] private int noOfCustomers;
    public float startXOffset;
    public int space;
    public float delayBetweenCustomers;

    

    void Start()
    {
        for (int i = 0; i < noOfCustomers; i++)
        {
            Transform customer = Instantiate(customerPrefab, new Vector3((startXOffset + (space * i)), 25, 50), Quaternion.identity);
            customer.GetComponent<Customer>().id = i;
        }
    }

    public void SpawnCustomer(int id)
    {
        StartCoroutine(SpawnCustomerWithDelay(id));
    }
    
    Vector3 RandomPointInKitchen()
    {
        Vector3 randomizedPoint;
        randomizedPoint.x = Random.Range(minX, maxX);
        randomizedPoint.y = Random.Range(minY, maxY);
        randomizedPoint.z = 50;
        return randomizedPoint;
    }
    
    public void SpawnPickupFor(int playerId)
    {
        Transform pickup = Instantiate(pickupPrefab, RandomPointInKitchen(), Quaternion.identity);
        pickup.GetComponent<PickUp>().whoCanPickMeUp = playerId;
    }
    
    private IEnumerator SpawnCustomerWithDelay(int id)
    {
        yield return new WaitForSeconds(delayBetweenCustomers);
        Transform customer = Instantiate(customerPrefab, new Vector3((startXOffset + (space * id)), 25, 50), Quaternion.identity);
        customer.GetComponent<Customer>().id = id;
    }

    // Update is called once per frame
    void Update()
    {
        if (player1.timeRemaining < 0.1f && player2.timeRemaining < 0.1f)
        {
            player1.movementComponent.canMove = false;
            player2.movementComponent.canMove = false;
            
            endPanel.gameObject.SetActive(true);
            if (player1.Score > player2.Score) winnerText.text = "Player 1";
            else
            {
                winnerText.text = "Player 2";
            }

        }
    }

    public void OnClickRestart()
    {
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
    }
}
