﻿using UnityEngine;
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
