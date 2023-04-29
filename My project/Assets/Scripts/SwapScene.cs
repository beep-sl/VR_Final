using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwapScene : MonoBehaviour
{// Update is called once per frame
    private int index;

    void Start() {
        index = SceneManager.GetActiveScene().buildIndex;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) {
            SceneManager.LoadScene(index+1);
        }
    }
}
