using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void PlayGame(int difficulty)
    {
        switch (difficulty)
        {
            case 0: //budzet
                {
                    //TODO add difficulty
                    break;
                }
            case 1: //samofinansiranje
                {
                    //TODO: add difficulty
                    break;
                }
            case 2: //burzuj
                {
                    //TODO: add difficulty
                    break;
                }
                SceneManager.LoadSceneAsync("WorldScene");
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
