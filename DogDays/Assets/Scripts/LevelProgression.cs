using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelProgression : MonoBehaviour 
{
    //public string LoadNextLevel;

    // Use this for initialization
    void Start () {	}
	
	// Update is called once per frame
	void Update () {	}

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
