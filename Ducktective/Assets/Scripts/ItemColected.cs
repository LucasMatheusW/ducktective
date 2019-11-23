using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class ItemColected : Interact
{
    
    public Item item;
    public CircleCollider2D collider;
    
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<CircleCollider2D>();
        collider.radius = base.radius;
        collider.isTrigger = true;
        gameObject.tag = "Item";
    }

    public override void doAction(){
        base.doAction();
        collect();
    }

    public void collect(){
        InventoryScript.instance.addItem(item);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }
}
