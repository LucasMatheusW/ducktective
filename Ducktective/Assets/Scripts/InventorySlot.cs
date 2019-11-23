using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventorySlot : MonoBehaviour
{
    
    public Image icon;
    public Item item;

    public void addToSlot(Item i)
    {
        item = i;
        icon.sprite = item.icon;
        icon.enabled = true;
    }

    public void clear()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
    }

    public void useItem()
    {
        if(item != null)
        {
            item.Use();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        icon = transform.GetChild(0).GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
