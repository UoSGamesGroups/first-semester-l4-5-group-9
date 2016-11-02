using UnityEngine;
using System.Collections;

public class ZOMBIEController : MonoBehaviour {

    public int ZOMBIEHealth = 100;
    bool alive = false;
    public float ZOMBIESpeed = -1f;
    public Transform Target;
    


    void Start() 
        {
        Target = GameObject.FindWithTag("Player").transform;
        }
     

    void Update() 
    {
        if (ZOMBIEHealth <= 0) 
            {
            Destroy (gameObject);

            GameObject g = GameObject.Find("Player");
            PlayerController bScript = g.GetComponent<PlayerController>();
            bScript.updateScore(100);
            }

        if (alive == true) 
            {
            transform.LookAt(Target.position);
            transform.Rotate(new Vector3(0, 90, 0), Space.Self);
            }

        if (Vector3.Distance(transform.position, Target.position) > 0) 
            {
            transform.Translate(new Vector3(ZOMBIESpeed * Time.deltaTime, 0, 0));
            }
      }


    void OnCollisionEnter2D(Collision2D coll) 
        {
            if (coll.gameObject.tag == "BULLET") 
            {
                ZOMBIEHealth -= 35;
            }
        }



    void OnBecameVisible() {
            alive = true;
        }

        void OnBecameInvisible() {
            if (alive == true) {
                Destroy(gameObject);
            }
        }
    }
