using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class DialogScript : MonoBehaviour
{
    private bool isOnDialogArea;
    [SerializeField]
    private Flowchart fc;
    [SerializeField]
    private GameObject character;
    // Start is called before the first frame update
    void Start()
    {
        isOnDialogArea = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isOnDialogArea)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {   
                if(character.tag == "Clyde")
                {
                    fc.ExecuteBlock("ClydeDialog");
                }  
                if(character.tag == "Item")
                {
                    if(character.GetComponent<ItemColected>().item.nome == "tesoura"){
                        fc.ExecuteBlock("FoundScisors");
                    } else if(character.GetComponent<ItemColected>().item.nome == "sorvete"){
                        fc.ExecuteBlock("FoundIceCream");
                    }
                    character.GetComponent<Interact>().OnFocus();
                } 
            }   
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Ducktective"))
        {
            isOnDialogArea = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.CompareTag("Ducktective"))
        {
            isOnDialogArea = false;
        }
    }
}
