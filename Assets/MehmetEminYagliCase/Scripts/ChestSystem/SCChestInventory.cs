using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ChestInventory", menuName = "Scriptable/ChestInventory")]
public class SCChestInventory : ScriptableObject
{
    public List<ChestSlot> inventorySlot = new List<ChestSlot>();

    int stackLimit = 4; // stacklanabilir nesne en fazla kaç adet stacklenebilir limiti

    public void InitializeInventory()
    {
        
        inventorySlot.Clear();
        for (int i = 0; i < 9; i++)
        {
            inventorySlot.Add(new ChestSlot());
        }
    }

    public bool AddItem(SCItem item)
    {
        foreach (ChestSlot slot in inventorySlot)
        {
            //burada da envanter'e ekleme fonksiyonunu yapıyoruz
            if (slot.item == item)//slotta daha önce o item var mı yok mu ona bak tuttuğu item ile yerden alınan item eşitse 
            {
                if (slot.item.canStackable) //yerden alınan item stacklanebiliyor mu ona bak
                {
                    if (slot.itemCount < stackLimit) //ve stack limittden küçük ise oraya ekle değilse yeni slot'a ekleme yapılacak
                    {
                        slot.itemCount++;
                        if (slot.itemCount >= stackLimit)
                        {
                            slot.isFull = true;
                        }
                        return true;
                    }
                }
            }
            //yerden aldığı nesne ile diyelim ki slottaki ilk nesne ile aynı değil o zaman bir yanındaki slot'a ekleme yap
            else if (slot.itemCount == 0)
            {
                slot.AddItemToSlot(item);
                return true; //döngüden çıkma işlemini yapmaz isek her slot'a aynı nesneyi ekliyor
            }
        }
        //nesneyi envanter'e ekleme islemi basarili ise true deger dondur ve nesneyi destory et 
        //eger envanterde yeteri kadar alan yok ise ekleme islemi yapma false deger dondur ve nesneyi yok ETME
        return false;
    }
}

[System.Serializable]
public class ChestSlot
{
    public bool isFull;
    public int itemCount;
    public SCItem item;


    public void AddItemToSlot(SCItem itemSlot)
    {
        item = itemSlot;
        if (item.canStackable == false)
        {
            isFull = true;

        }
        itemCount++;


    }
}
