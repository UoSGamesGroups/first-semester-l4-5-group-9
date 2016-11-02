using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	SpriteRenderer sr;
	public Sprite heart3;
	public Sprite heart2;
	public Sprite heart1;
	public Sprite heart0;


    // Use this for initialization
    void Start() { }

		public void updateHealth(int Number)
		{
            if (Number == 3) { 
				sr =GetComponent<SpriteRenderer> ();
				sr.sprite = heart3;
			}

    
            if (Number == 2)
            {
                sr = GetComponent<SpriteRenderer>();
                sr.sprite = heart2;
            }

        
            if (Number == 1)
            {
                sr = GetComponent<SpriteRenderer>();
                sr.sprite = heart1;
            }

        
            if (Number == 0)
            {
                sr = GetComponent<SpriteRenderer>();
                sr.sprite = heart0;
            }
        }

    // Update is called once per frame
    void Update() { }
}
