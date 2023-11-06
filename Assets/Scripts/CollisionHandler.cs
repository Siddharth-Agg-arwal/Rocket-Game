using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{   
    [SerializeField] float LevelLoadDelay = 2f;
    [SerializeField] AudioClip ObstacleCollision;   
    [SerializeField] AudioClip LevelCompleted;
    [SerializeField] ParticleSystem ParticleCollision;   
    [SerializeField] ParticleSystem ParticleLevelCompleted;
    AudioSource audioSource;
    bool isTransitioning = false;

    void Start(){
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision other) {

        if(isTransitioning){
            return;
        }
        
        switch (other.gameObject.tag){
            case "Friendly":
                Debug.Log("This object is friendly.");
                break;

            case "Finish":
                StartSuccessSequence();
                break;

            // case "Fuel":
            //     Debug.Log("You picked up the fuel.");
            //     break;

            default:
                StartCrashSequence();
                break; 
        }
    }

    void StartSuccessSequence(){
        //todo add SFX upon crash
        //todo add particle effect on crash
        isTransitioning = true;
        ParticleLevelCompleted.Play();
        audioSource.Stop();
        audioSource.PlayOneShot(LevelCompleted);
        GetComponent<Movement>().enabled = false;
        Invoke("NextLevel", LevelLoadDelay);
    }

    void StartCrashSequence(){
        //todo add SFX upon crash
        //todo add particle effect on crash
        isTransitioning = true;
        ParticleCollision.Play();
        audioSource.Stop();
        audioSource.PlayOneShot(ObstacleCollision);
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", LevelLoadDelay);
    }

    void NextLevel(){
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentIndex + 1;

        if (nextSceneIndex >= SceneManager.sceneCountInBuildSettings){
            nextSceneIndex = 0;
        }
        
        SceneManager.LoadScene(nextSceneIndex);
    }

    void ReloadLevel(){
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentIndex);
    }
}
