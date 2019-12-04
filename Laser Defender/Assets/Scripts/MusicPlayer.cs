using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MusicPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        SetUpSingleton();
    }

    private void SetUpSingleton()
    {
        // saying if already one then destroy new one thats trying to come along, if there isnt already one then dont destroy. Used because when changing scenes the music will restart, this will prevent that from happening by destroying the new ones that try to play and allows the first one to continue playing
        if (FindObjectsOfType(GetType()).Length > 1) // GetType is getting the type of our class(this case being Music Player)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
