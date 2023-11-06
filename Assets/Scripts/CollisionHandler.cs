using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision other) {
        switch (other.gameObject.tag){
            
            case "Friendly":
                Debug.Log("This object is friendly.");
                break;

            case "Finish":
                NextLevel();
                // Debug.Log("Congrats, you finished!");
                break;

            case "Fuel":
                Debug.Log("you picked up the fuel");
                break;

            default:
                ReloadLevel();
                break; 
        }    

        void NextLevel(){
            int currentIndex = SceneManager.GetActiveScene().buildIndex;
            int nextSceneIndex = currentIndex + 1;

            if(nextSceneIndex == SceneManager.sceneCountInBuildSettings){
                nextSceneIndex = 0;
            }
            else{
                SceneManager.LoadScene(currentIndex+1);
            } 
        }

        void ReloadLevel(){
            int currentIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentIndex);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex());
            //SceneManager.LoadScene(0);
        }
    }
}
