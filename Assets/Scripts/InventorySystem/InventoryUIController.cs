using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUIController : MonoBehaviour
{
    //bu kisimda da slotUI daki nesnelerin verilerini alıp atamasını yapacagim

    public List<SlotUI> uiList = new List<SlotUI>();

    [SerializeField] private Inventory userInventory;

    private void Start()
    {
        userInventory = GetComponent<Inventory>();
       
    }

    public void UpdateUI()
    {
        
        for (int i = 0; i < uiList.Count; i++)
        {
            //playerinventory scriptable nesne olan SCInventory den bilgileri çektigimiz atama.
            if (userInventory.playerInventory.inventorySlot[i].itemCount > 0) //eğer envanterde nesne var ise yapılacaklar
            {
                uiList[i].itemImage.sprite = userInventory.playerInventory.inventorySlot[i].item.itemIcon;
                //eger alınan nesne stacklenebiliyorsa arayuzde text'ine erisip sayisini arttiricaz
                if (userInventory.playerInventory.inventorySlot[i].item.canStackable == true)
                {
                    uiList[i].itemCountText.gameObject.SetActive(true);//bunu yapma sebebim eger stacklenmeyen bir nesne ise sayi yazmasina gerek yok 
                    uiList[i].itemCountText.text = userInventory.playerInventory.inventorySlot[i].itemCount.ToString();
                }
                else
                {
                    uiList[i].itemCountText.gameObject.SetActive(false);//bunu yapma sebebim eger stacklenmeyen bir nesne ise sayi yazmasina gerek yok 
                }
            }
            else
            {
                //diger butonların resimleri aynı olmaması için envanterde bos olan yerlerin imagelerini null yapmam gerekiyor
                uiList[i].itemImage.sprite = null;
                uiList[i].itemCountText.gameObject.SetActive(false); //ve bir bilgi olmadigi icin text nesnesinide kapatiyorum.
            }
        }
    }
}
