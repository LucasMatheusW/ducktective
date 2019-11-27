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
            if (Input.GetKeyDown(KeyCode.Space) && fc.GetBooleanVariable("Var") == false)
            {   
                if(character.tag == "Character")
                {
                    fc.ExecuteBlock(character.GetComponent<CharDialog>().character.dialog);
                } else if(character.tag == "Item")
                {
                    fc.ExecuteBlock(character.GetComponent<ItemColected>().item.dialog);
                    character.GetComponent<Interact>().OnFocus();
                } 
            }   
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            fc.SetBooleanVariable("Var", true);
            PlayerMove.canvas.SetActive(true);
            PlayerMove.textarea.SetActive(false);
        }

        if(Input.GetKeyDown(KeyCode.Escape)){
            if(PlayerMove.canvas.activeSelf){
                PlayerMove.canvas.SetActive(false);
                PlayerMove.textarea.SetActive(false);
                fc.SetBooleanVariable("Var", false);
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
