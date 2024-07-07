using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public SCInventory playerInventory;
    InventoryUIController inventoryUI;

    private void Start()
    {
        inventoryUI = gameObject.GetComponent<InventoryUIController>();
        inventoryUI.UpdateUI();
    }

    //yerden alma işlemi
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("item"))
        {
            if (playerInventory.AddItem(other.gameObject.GetComponent<Item>().item))
            {
                Destroy(other.gameObject);
                //nesneyi aldigimde ui tarafinde de güncelleme islemi yapilsin
                inventoryUI.UpdateUI();
            }
           
        }
    }
}
