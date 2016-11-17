using UnityEngine;
using System.Collections;

public class ZOMBIEController : MonoBehaviour {

    public int ZOMBIEHealth = 100;
    bool alive = false;
    public float ZOMBIESpeed = 1f;
    public Transform Target;
   

    void Start() 
        {
        Target = GameObject.FindWithTag("Player").transform;
        }
     
        
    void Update() 
    {
        
        if (ZOMBIEHealth < 0) 
            {
            Destroy (gameObject);

            GameObject g = GameObject.Find("Player");
            PlayerController bScript = g.GetComponent<PlayerController>();
            bScript.updateScore(100);
            }


        if (alive == true) 
        {
            // build an angle between Zombie and the player.

            // get a vector that points between this zombie and the target
            Vector2 diff = Target.position - transform.position;
            // find the angle of that vector
            float angle = (Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg) + 90f;
            // build a quaternion to represent that rotation
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            // and apply it over time with a spherical linear interpolation
            transform.rotation = Quaternion.Slerp(transform.rotation, q, 0.5f);
        }


       if (Vector3.Distance(transform.position, Target.position) > 0) 
          {
            transform.position += transform.up * (ZOMBIESpeed * Time.deltaTime);
          }

    }


	void OnCollisionEnter2D(Collision2D coll) 
	{
		if (coll.gameObject.tag == "BULLET") 
		{
			ZOMBIEHealth -= 35;
		}
        if (coll.gameObject.tag == "BULLETPOWER") 
        {
            ZOMBIEHealth -= 105;
        }
	}



    void OnBecameVisible() 
        {
            alive = true;
        }

        void OnBecameInvisible() 
        {
            if (alive == true) 
            {
                Destroy(gameObject);
            }
        }
}
