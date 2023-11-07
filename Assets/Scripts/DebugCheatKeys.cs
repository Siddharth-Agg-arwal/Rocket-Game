using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugCheatKeys : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        LoadNextLevel();
    }

    void LoadNextLevel(){

        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int nextScene = currentScene + 1;

        if(nextScene >= SceneManager.sceneCountInBuildSettings){
            nextScene = 0;
        }

        if(Input.GetKey(KeyCode.L)){
            SceneManager.LoadScene(nextScene);
        }
    }
}
