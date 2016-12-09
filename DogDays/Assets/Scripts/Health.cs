using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Health : MonoBehaviour {

    private Image sr;
    public Sprite BatteryOvercharge;
    public Sprite BatteryFull;
    public Sprite Battery2;
    public Sprite Battery1;
    public Sprite BatteryEmpty;


    // Use this for initialization
    void Start()
    {
        sr = GetComponent<Image>();
    }

    public void updateHealth(int Number) {

        if (Number == 4) {
            
            sr.sprite = BatteryOvercharge;
        }

        if (Number == 3) {
            sr.sprite = BatteryFull;
        }


        if (Number == 2) {
            sr.sprite = Battery2;
        }


        if (Number == 1) {
            sr.sprite = Battery1;
        }


        if (Number == 0) {
            sr.sprite = BatteryEmpty;
        }


    }

    // Update is called once per frame
    void Update() { }

    //IEnumerator Overcharge() 
    //    {
    //    yield return new WaitForSeconds(1);

    //    GameObject g = GameObject.Find("BATTERYGREEN");
    //    Health bScript = g.GetComponent<Health>();
    //    bScript.updateHealth(-1);
    //}
}