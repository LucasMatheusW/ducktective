using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.UI;

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
                    if(character.GetComponent<ItemColected>().item.id == 0){
                        fc.ExecuteBlock("FoundScisors");
                    } else if(character.GetComponent<ItemColected>().item.id == 1){
                        fc.ExecuteBlock("FoundIceCream");
                    }
                    character.GetComponent<Interact>().OnFocus();
                } 
            }   
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            fc.SetBooleanVariable("Var", true);
            PlayerMove.canvas.GetComponent<Canvas>().targetDisplay = 0;
            PlayerMove.textarea.SetActive(false);
            GameObject [] slots = GameObject.FindGameObjectsWithTag("Slot");
            foreach (GameObject s in slots)
            {
                s.GetComponent<Button>().enabled = true;
            }
        }

        if(Input.GetKeyDown(KeyCode.Escape)){
            if(PlayerMove.canvas.GetComponent<Canvas>().targetDisplay == 0){
                PlayerMove.canvas.GetComponent<Canvas>().targetDisplay = 1;
                PlayerMove.textarea.SetActive(false);
                fc.SetBooleanVariable("Var", false);
                GameObject [] slots = GameObject.FindGameObjectsWithTag("Slot");
                foreach (GameObject s in slots)
                {
                    s.GetComponent<Button>().enabled = false;
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
