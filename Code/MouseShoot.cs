//using UnityEngine;
//using System.Collections;

//public class MouseShoot : MonoBehaviour {


//    public GameObject bulletPrefab;
//    public GameObject bulletPowerPrefab;
//    public float speed = 10f;
//    public int ShootMode = 0;



//    // Use this for initialization
//    void Start() { }

//    // Update is called once per frame
//    void Update() {

//        if (Input.GetMouseButtonDown(0)) {
//            if (ShootMode == 0) {
//                Vector2 target = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
//                Vector2 myPos = new Vector2(transform.position.x, transform.position.y);
//                Vector2 direction = target - myPos;
//                direction.Normalize();
//                Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
//                GameObject projectile = (GameObject)Instantiate(bulletPrefab, myPos, rotation);
//                projectile.GetComponent<Rigidbody2D>().velocity = direction * speed;
//            }
//            if (ShootMode == 1) {
//                Vector2 target = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
//                Vector2 myPos = new Vector2(transform.position.x, transform.position.y);
//                Vector2 direction = target - myPos;
//                direction.Normalize();
//                Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
//                GameObject projectile = (GameObject)Instantiate(bulletPowerPrefab, myPos, rotation);
//                projectile.GetComponent<Rigidbody2D>().velocity = direction * speed;
//            }
//        }
//    }

//}