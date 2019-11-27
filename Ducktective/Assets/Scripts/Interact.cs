using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public float radius = 0.5f;
    public bool isFocus = false;
    public bool interacted = false;
    
    public virtual void doAction()
    {
        Debug.Log("Interacted w/ "+transform.name);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if (isFocus && !interacted)
        {
            doAction();
            interacted = true;
        }
    }

    public void OnFocus() {
        isFocus = true;
        interacted = false;
    }
}
