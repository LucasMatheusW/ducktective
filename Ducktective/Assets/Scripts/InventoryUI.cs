using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    
    public Transform outer;
    public GameObject UI;
    public InventorySlot[] slots;
    
    void genUI(){
        for(int i = 0; i < slots.Length; i++)
        {
            if (i < InventoryScript.instance.items.Count)
            {
                slots[i].addToSlot(InventoryScript.instance.items[i]);
            } else {
                slots[i].clear();
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        InventoryScript.instance.itemAlteradoEvent += genUI; 
        slots = outer.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
