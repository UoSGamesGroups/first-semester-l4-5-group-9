using UnityEngine;
using System.Collections;

public class ZOMBIESpawner : MonoBehaviour {

    public GameObject ZOMBIEPrefab;
    public int timer = 0;
    public int spawnRate = 30;


    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void FixedUpdate() {

        timer = timer + 1;
        if (timer > spawnRate) {
            spawnRate = Random.Range(150, 180);

            Instantiate(ZOMBIEPrefab, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
            timer = 0;
        }

    }
}