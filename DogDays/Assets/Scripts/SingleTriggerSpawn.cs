using UnityEngine;
using System.Collections;

public class SingleTriggerSpawn : MonoBehaviour {
    public Transform Spawnpoint1;
    public Transform Spawnpoint2;
    public Transform Spawnpoint3;
    public Transform Spawnpoint4;
    public Transform Spawnpoint5;
    public Transform Spawnpoint6;
    public Transform Spawnpoint7;
    public Transform Spawnpoint8;
    public Transform Spawnpoint9;
    public Transform Spawnpoint10;
    public GameObject Prefab;

    void Start() { }

    void Update() { }


    public void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") 
        {
            Object.Destroy(this.gameObject);

            Instantiate(Prefab, Spawnpoint1.position, Spawnpoint1.rotation);
            Instantiate(Prefab, Spawnpoint2.position, Spawnpoint2.rotation);
            Instantiate(Prefab, Spawnpoint3.position, Spawnpoint3.rotation);
            Instantiate(Prefab, Spawnpoint4.position, Spawnpoint4.rotation);
            Instantiate(Prefab, Spawnpoint5.position, Spawnpoint5.rotation);
            Instantiate(Prefab, Spawnpoint6.position, Spawnpoint6.rotation);
            Instantiate(Prefab, Spawnpoint7.position, Spawnpoint7.rotation);
            Instantiate(Prefab, Spawnpoint8.position, Spawnpoint8.rotation);
            Instantiate(Prefab, Spawnpoint9.position, Spawnpoint9.rotation);
            Instantiate(Prefab, Spawnpoint10.position, Spawnpoint10.rotation);
        }

    }
}
