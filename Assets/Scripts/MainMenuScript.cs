using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    public void PlayGame()
    {
        //TODO: Load home scene
        //SceneManager.LoadSceneAsync()
    }

    public void QuitGame()
    {
        Debug.Log("clicked");
        Application.Quit();
    }
}
