using UnityEngine;
using System.Collections;

public class ZOMBIE2Controller : MonoBehaviour {

    public int ZOMBIEHealth = 1;
    bool alive = false;
    public float ZOMBIESpeed = 1f;
    public Transform Target;


    void Start() {
        Target = GameObject.FindWithTag("Player").transform;
    }


    void Update() {
        //following if function: if ZOMBIE not destroyed, track and move to player.
        if (alive == true) {
            // build an angle between Zombie and the player.

            // get a vector that points between this zombie and the target
            Vector2 diff = Target.position - transform.position;
            // find the angle of that vector
            float angle = (Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg) - 90f;
            // build a quaternion to represent that rotation
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            // and apply it over time with a spherical linear interpolation
            transform.rotation = Quaternion.Slerp(transform.rotation, q, 0.5f);
        }

        //following if function: if ZOMBIE not at player position, continue towards player.
        if (Vector3.Distance(transform.position, Target.position) > 0) {
            transform.position += transform.up * (ZOMBIESpeed * Time.deltaTime);
        }

    }

    void OnBecameVisible() {
        alive = true;
    }
}