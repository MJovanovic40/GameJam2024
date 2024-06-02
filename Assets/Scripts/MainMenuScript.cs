using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void PlayGame(int difficulty)
    {
        StatsPersistManager.currentState = Player.PlayerState.InTown;
        switch (difficulty)
        {
            case 0: //budzet
                {
                    break;
                }
            case 1: //samofinansiranje
                {
                    StatsPersistManager.health = 60;
                    StatsPersistManager.stamina = 60;
                    StatsPersistManager.money = 0f;
                    StatsPersistManager.focus = 60;
                    break;
                }
            case 2: //burzuj
                {
                    StatsPersistManager.money = 1000000f;
                    break;
                }

        }
        Debug.Log("dosao");
        SceneManager.LoadSceneAsync("WorldScene");

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
