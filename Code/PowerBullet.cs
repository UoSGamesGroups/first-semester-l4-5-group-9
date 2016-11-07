﻿using UnityEngine;
using System.Collections;

public class PowerBullet : MonoBehaviour 
{

	public float bulletSpeed = 10;
	public GameObject bulletPrefab;


	void Start () {}

    void Update() 
        {
        var moveBullet = new Vector3(2, 2, 0);
        transform.position += moveBullet * bulletSpeed * Time.deltaTime;

        //var moveBulletUp = new Vector3(0, 1, 0);
        //transform.position += moveBullet * bulletSpeed * Time.deltaTime;

        //var moveBulletDown = new Vector3(0, -1, 0);
        //transform.position += moveBullet * bulletSpeed * Time.deltaTime;
        }


        void OnBecameInvisible()
        {
		Destroy (gameObject);
    	}
}