using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public void PlayTheGoddamnGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitThisStupidThing()
    {
        Debug.Log("Someone just tried to quit Your masterpiece");
        Application.Quit();
    }
}
