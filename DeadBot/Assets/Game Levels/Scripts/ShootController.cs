using UnityEngine;
using System.Collections;

public class ShootController : MonoBehaviour {

	public float bulletSpeed = 10;
    public GameObject bulletPrefab;


    void Start () {
	
	}
	
	void Update () {

        var moveBullet = new Vector3(2, -1, 0);
        transform.position += moveBullet * bulletSpeed * Time.deltaTime;

        //var moveBulletLeft = new Vector3 (-2, 0, 0);
        //transform.position +=moveBulletLeft * bulletSpeed * Time.deltaTime;

        //var moveBulletRight = new Vector3 (2, 0, 0);
        //transform.position += moveBulletRight * bulletSpeed * Time.deltaTime;

        //var moveBulletUp = new Vector3(0, 2, 0);
        //transform.position += moveBulletUp * bulletSpeed * Time.deltaTime;

        //var moveBulletDown = new Vector3(0, -2, 0);
        //transform.position += moveBulletDown * bulletSpeed * Time.deltaTime;

    }

	void OnBecameInvisible(){
		Destroy (gameObject);
	
	
	}
}
