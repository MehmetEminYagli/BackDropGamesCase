using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestInventory : MonoBehaviour
{

    public SCChestInventory chestInventoryUI;
    [SerializeField] ChestInventoryUIController chestinventoryUI;
    public Item itemobjects;
    private void Start()
    {
        chestinventoryUI = gameObject.GetComponent<ChestInventoryUIController>();
        chestInventoryUI.InitializeInventory();
        for (int i = 0; i < 3; i++)
        {
            GenerateItem();
        }
       
    }

    public List<GameObject> itemPrefabs = new List<GameObject>();

    public void GenerateItem()
    {
        
        int randomIndex = Random.Range(0, itemPrefabs.Count);
        GameObject selectedPrefab = itemPrefabs[randomIndex];

        GameObject spawnedItem = Instantiate(selectedPrefab, transform.position + new Vector3(0,100f,0f), Quaternion.identity);
        itemobjects = spawnedItem.GetComponent<Item>();
        if (chestInventoryUI.AddItem(spawnedItem.GetComponent<Item>().item))
        {
            chestinventoryUI.UpdateUI();


        }

     
    }

}


