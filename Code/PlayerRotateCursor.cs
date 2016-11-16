using UnityEngine;
using System.Collections;

public class PlayerRotateCursor : MonoBehaviour {
    Vector3 MousePosition;
    Camera Camera;
    Rigidbody2D Rigidbody;

	// Use this for initialization
	void Start () 
        {
        Camera = Camera.main;
        Rigidbody = this.GetComponent<Rigidbody2D>();
        }
	
	// Update is called once per frame
	void Update () 
        {
        MousePosition = Camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z - Camera.transform.position.z));
        Rigidbody.transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2((MousePosition.y - transform.position.y), (MousePosition.x - transform.position.x)) * Mathf.Rad2Deg);
	    }
}
