using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainController : MonoBehaviour
{
    public void StartGame(){
        SceneManager.LoadScene(2);

    }

    public void QuitGame(){
        Application.Quit();
    }

    public void ShowTutorial(){
        SceneManager.LoadScene(1);
    }

    public void Return() {
        Debug.Log("stuff");
        SceneManager.LoadScene(0);
        
    }
}
