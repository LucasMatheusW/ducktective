using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoaderControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene(BetweenScene.nextScene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
