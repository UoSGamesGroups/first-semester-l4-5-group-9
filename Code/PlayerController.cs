using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour 
{

    public float speed = 5;
    public GameObject bulletPrefab;
    public float front = 0.5f;

    //Win displayed when 100% collection achieved
    public Text WinText;
    //Collection Score In-Game Display
    public Text CollectCountText;
    //Collection Score
    private int CollectCount;
    
    
    //set score+text values to nil
    void Start() 
    {
        CollectCount = 0;
        updateCollectCountText ();
        WinText.text = "";
    }

    
    void Update() 
        {

        //Movement variables, 8 way
        var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        transform.position += move * speed * Time.deltaTime;
      

        //Shoot 'Bullet'  (right...)
        if (Input.GetKeyDown("space")) 
            {
            Physics2D.IgnoreCollision(bulletPrefab.GetComponent<Collider2D>(), bulletPrefab.GetComponent<Collider2D>());
            Instantiate(bulletPrefab, new Vector3(transform.position.x + front, transform.position.y, 0), Quaternion.identity);
            }
        }

    //Pick Up Memory
    void OnTriggerEnter2D(Collider2D other) 
        {
        if (other.gameObject.CompareTag("PickUp")) 
            {
            other.gameObject.SetActive(false);
            CollectCount = CollectCount + 1;
            updateCollectCountText ();
            }
        }
    
    //Score update on pick up. 
    void updateCollectCountText () 
        {
        CollectCountText.text = "Score: " + CollectCount.ToString();
        if (CollectCount >= 8) 
            {
            WinText.text = "WINNER!";
            }
        }
}
