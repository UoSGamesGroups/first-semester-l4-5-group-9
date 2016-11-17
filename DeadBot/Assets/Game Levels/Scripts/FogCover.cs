using UnityEngine;
using System.Collections;

public class FogCover : MonoBehaviour 
{

    SpriteRenderer sr;
    public Sprite Fog1;
    public Sprite Fog2;
    public Sprite Fog3;
    public Sprite Fog4;
    public Sprite Fog5;



    // Use this for initialization
    void Start() { }

    public void updateFog(int Number) 
        {

        if (Number == 1) 
            {
            sr = GetComponent<SpriteRenderer>();
            sr.sprite = Fog1;
            }

        if (Number == 2) 
            {
            sr = GetComponent<SpriteRenderer>();
            sr.sprite = Fog2;
            }


        if (Number == 3) 
            {
            sr = GetComponent<SpriteRenderer>();
            sr.sprite = Fog3;
            }


        if (Number == 4) 
            {
            sr = GetComponent<SpriteRenderer>();
            sr.sprite = Fog4;
            }


        if (Number == 5) 
            {
            sr = GetComponent<SpriteRenderer>();
            sr.sprite = Fog5;
            }
        }

    // Update is called once per frame
    void Update() { }
}
