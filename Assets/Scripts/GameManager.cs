using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    public Transform customerPrefab;
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
    
    private IEnumerator SpawnCustomerWithDelay(int id)
    {
        yield return new WaitForSeconds(delayBetweenCustomers);
        Transform customer = Instantiate(customerPrefab, new Vector3((startXOffset + (space * id)), 25, 50), Quaternion.identity);
        customer.GetComponent<Customer>().id = id;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
