using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class DialogScript : MonoBehaviour
{
    private bool isOnDialogArea;
    private bool isPaused;
    [SerializeField]
    private Flowchart fc;
    [SerializeField]
    private GameObject character;
    // Start is called before the first frame update
    void Start()
    {
        isOnDialogArea = false;
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                isPaused = false;
            } else {
                isPaused = true;
                fc.ExecuteBlock("PauseMenu");
            }
        }
        if (isOnDialogArea)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {   
                if(character.tag == "Clyde")
                {
                    fc.ExecuteBlock("ClydeDialog");
                }
                if(character.tag == "Tesoura")
                {
                    fc.ExecuteBlock("FoundScisors");
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
