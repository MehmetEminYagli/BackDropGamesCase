using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public SCInventory playerInventory;

    //yerden alma işlemi

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("item"))
        {
            if (playerInventory.AddItem(other.gameObject.GetComponent<Item>().item))
            {
                Destroy(other.gameObject);
            }
            else
            {
                Debug.Log("envanter dolu nesne eklenmedi");
            }
        }
    }
}
