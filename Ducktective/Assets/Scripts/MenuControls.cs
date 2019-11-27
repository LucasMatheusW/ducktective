using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControls : MonoBehaviour
{
    public void QuitGame(){
        Application.Quit();
    }

    public void NewGame(){
        BetweenScene.nextScene = "Case_1";
        SceneManager.LoadSceneAsync("Loading");        
    }

    public void MenuQuit(){
        BetweenScene.nextScene = "Menu";
        SceneManager.LoadSceneAsync("Loading");
    }
}
