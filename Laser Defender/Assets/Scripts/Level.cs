using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{

    [SerializeField] float delayInSeconds = 2f;


    
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
        // certain amount of settings before displaying Game Over
        StartCoroutine(WaitAndLoad());    
    }

IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene("Game Over");
    }

public void QuitGame()
    {
        Application.Quit();
    }

}
