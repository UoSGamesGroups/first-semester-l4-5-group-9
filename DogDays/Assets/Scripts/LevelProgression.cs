using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelProgression : MonoBehaviour 
{
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Player") 
        {
            int CurrentScene = SceneManager.GetActiveScene().buildIndex;
            if (CurrentScene < SceneManager.sceneCountInBuildSettings)
                SceneManager.LoadScene(CurrentScene + 1);
        }
    }
}
