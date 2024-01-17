using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class Item : ScriptableObject
{
    public Sprite itemSpirite;
    public string itemName;
    public int dropChance;


    public Item(string itemName, int dropChance){
        this.itemName = itemName;
        this.dropChance = dropChance;
    }
}
