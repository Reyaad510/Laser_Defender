using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{


    
public void LoadStartMenu()
    {
        SceneManager.LoadScene(0);
    }



public void LoadGame()
    {
        SceneManager.LoadScene("Game"); // Grabbing Scene named called "Game". Not best way if u change name later on
    }

public void LoadGameOver()
    {
        SceneManager.LoadScene("Game Over");
    }

public void QuitGame()
    {
        Application.Quit();
    }

}
