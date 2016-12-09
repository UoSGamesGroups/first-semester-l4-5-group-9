using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    public Camera cam;
    public float camZ;

	// Use this for initialization
	void Start () {
        cam = Camera.main;
        camZ = cam.transform.position.z;
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.position;
        pos.z = camZ;
        cam.transform.position = pos;
	}
}
