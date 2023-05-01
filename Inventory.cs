using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private SlotInfo[] slots;
    [SerializeField] private List<ItemSlot> itemInInventory;
    [SerializeField] private Item[] itemDatabase;
    public static Inventory instance = null;

    private void Start()
    {
        RenderItem();
        SetSlotIndex();

        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }
    void SetSlotIndex()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].SetIndex(i + 1);
        }
    } //расставить номера слотам инвентар€ 
    void RenderItem()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (!slots[i].CheckIsFull())
            {
                slots[i].SlotImage.enabled = false;
            }
            else
            {
                slots[i].SlotImage.enabled = true;
            }
        }
    } //если в €чейке ничего нет то убирает изображение
    public void AddItem(int id)
    {
        for (int i = 0; i < itemDatabase.Length; i++)
        {
            if (itemDatabase[i].id == id)
            {
                Item iteminDatabase = itemDatabase[i];
                ItemSlot inventoryItem;
                SlotInfo slotInfo = CheckEmptySlot();
                if (slotInfo)
                {
                    inventoryItem.ItemSource = iteminDatabase;
                    inventoryItem.SlotIndex = slotInfo.GetIndex();
                    slotInfo.SetFull(true);
                    itemInInventory.Add(inventoryItem);
                    slotInfo.SlotImage.sprite = inventoryItem.ItemSource.icon;
                    slotInfo.SpawnItem();
                    RenderItem();
                }
                else
                {
                    Debug.Log("Ќедосаточно места");
                }

            }

        }
    } //добавить айтем
    public SlotInfo CheckEmptySlot()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].CheckIsFull() == false)
            {
                return slots[i];
            }
        }
        return null;

    } //вернуть свободный слот
    private SlotInfo FindSlotByIndex(int index)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].GetIndex() == index)
            {
                return slots[i];
            }
        }
        return null;
    } //найти слот по индексу
    public void UseItem(int index)
    {
        for (int i = 0; i < itemInInventory.Count; i++)
        {
            if (itemInInventory[i].SlotIndex == index)
            {
                ItemSlot itemSlot = itemInInventory[i];

                for (int _i = 0; _i < EventManager.instance.Events.Length; _i++)
                {
                    if (EventManager.instance.Events[_i].EventID == itemSlot.ItemSource.eventID)
                    {
                        EventManager.instance.InvokeEvent(_i);
                        DeleteItem(itemSlot.SlotIndex);
                    }
                }
            }
        }
    } //использование айтема
    public void DeleteItem(int index)
    {
        for (int i = 0; i < itemInInventory.Count; i++)
        {
            if (itemInInventory[i].SlotIndex == index)
            {
                FindSlotByIndex(itemInInventory[i].SlotIndex).ClearSlot();
                itemInInventory.RemoveAt(i);
                RenderItem();
            }
        }      
    } //удалить предмет из €чейки
}
[System.Serializable]
public struct ItemSlot
{
    public Item ItemSource;
    public int SlotIndex;
}
