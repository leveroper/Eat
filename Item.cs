using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public int id;
    public Sprite icon;
    public ItemType type; 
    public int eventID; //айди вызываемоего евента при использовании
}
public enum ItemType
{
    none, food
}
