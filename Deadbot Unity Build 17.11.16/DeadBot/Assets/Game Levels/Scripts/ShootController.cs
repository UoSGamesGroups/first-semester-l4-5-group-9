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

    }

	void OnBecameInvisible(){
		Destroy (gameObject);
	
	
	}
}
