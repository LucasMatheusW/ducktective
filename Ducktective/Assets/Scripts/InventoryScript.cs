using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    public static InventoryScript instance;
    
    private void Awake() {
        if(instance == null)
        {
            instance = this;
        }    
    }

    public delegate void ItemAlterado();
    public event ItemAlterado itemAlteradoEvent;
    [SerializeField]
    private int quantSlots;

    public List<Item> items = new List<Item>();

    public void addItem(Item i)
    {
        items.Add(i);
        if(itemAlteradoEvent != null){
            itemAlteradoEvent();
        }
    }
}
