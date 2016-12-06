using UnityEngine;
using System.Collections;

public class KeyDoorUnlock : MonoBehaviour 
{

    // Use this for initialization
    void Start() {    }

    // Update is called once per frame
    void Update() {    }

    public void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Key1") {
            Destroy(other.gameObject);
            Destroy(GameObject.FindWithTag("Door1"));
        }

        if (other.gameObject.tag == "Key2") {
            Destroy(other.gameObject);
            Destroy(GameObject.FindWithTag("Door2"));
        }

        if (other.gameObject.tag == "Key3") {
            Destroy(other.gameObject);
            Destroy(GameObject.FindWithTag("Door3"));
        }

        if (other.gameObject.tag == "Key4") {
            Destroy(other.gameObject);
            Destroy(GameObject.FindWithTag("Door4"));
        }

        if (other.gameObject.tag == "Key5") {
            Destroy(other.gameObject);
            Destroy(GameObject.FindWithTag("Door5"));
        }

        if (other.gameObject.tag == "KeySurprise") {
            Destroy(other.gameObject);
            Destroy(GameObject.FindWithTag("DoorSurprise"));
        }
    }
}