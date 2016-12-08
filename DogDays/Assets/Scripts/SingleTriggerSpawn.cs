using UnityEngine;
using System.Collections;

public class SingleTriggerSpawn : MonoBehaviour {
    public Transform Spawnpoint1;

    public GameObject Prefab;

    void Start() { }

    void Update() { }


    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")    //on player collision with trigger
        {
            Instantiate(Prefab, Spawnpoint1.position, Spawnpoint1.rotation);         //enemy prefab is spawned at set location
            
            Object.Destroy(this.gameObject);         //trigger is destroyed, so cannot be re-triggered
        }

    }
}
