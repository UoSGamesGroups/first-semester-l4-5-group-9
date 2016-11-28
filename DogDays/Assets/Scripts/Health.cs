using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	SpriteRenderer sr;
    public Sprite BatteryOvercharge;
	public Sprite BatteryFull;
	public Sprite Battery2;
	public Sprite Battery1;
	public Sprite BatteryEmpty;


    // Use this for initialization
    void Start() { }

		public void updateHealth(int Number)
		    {

        if (Number == 4) 
            {
            sr = GetComponent<SpriteRenderer>();
            sr.sprite = BatteryOvercharge;
			// Destroy all game objects with 'BlockT' tag//
			Destroy (GameObject.FindWithTag("BlockT")); 
			//Destroy all game objects with 'ENEMY' tag
			GameObject[] enemies = GameObject.FindGameObjectsWithTag("ENEMY");
			foreach(GameObject ENEMY in enemies)
				GameObject.Destroy(ENEMY); 
			GameObject[] blocker = GameObject.FindGameObjectsWithTag("Blockers");
			foreach(GameObject Blockers in blocker)
				GameObject.Destroy(Blockers);
			//Destroy(GameObject.FindWithTag("Borders"));
            //Destroy(other.gameObject);
            //GameObject[] Borders = GameObject.FindGameObjectsWithTag("Borders");
            //foreach (GameObject Borders in Borders)
            //GameObject.Destroy(Borders);
        }

        if (Number == 3) 
            { 
				sr =GetComponent<SpriteRenderer> ();
				sr.sprite = BatteryFull;
			}

    
            if (Number == 2)
            {
                sr = GetComponent<SpriteRenderer>();
                sr.sprite = Battery2;
            }

        
            if (Number == 1)
            {
                sr = GetComponent<SpriteRenderer>();
                sr.sprite = Battery1;
            }

        
            if (Number == 0)
            {
                sr = GetComponent<SpriteRenderer>();
                sr.sprite = BatteryEmpty;
            }
        }

    // Update is called once per frame
    void Update() { }
}
