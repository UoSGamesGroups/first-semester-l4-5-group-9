using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour 
{

    public float speed = 5;
    public GameObject bulletPrefab;
    //public GameObject bulletLeftPrefab;
    //public GameObject bulletRightPrefab;  
    //public GameObject bulletUpPrefab;    
    //public GameObject bulletDownPrefab;  
    public float front = 0.5f;

    //Win displayed when 100% collection achieved
    public Text WinText;
    //Collection Score In-Game Display
    public Text CollectCountText;
    //Collection Score
    private int CollectCount;

    //Score
    public int PlayerScore = 0;
    //Player Score In-Game Display
    public Text PlayerScoreText;

    //Game Over message Displayed
    public Text GameOverText;

    //Player Health
    public int PlayerHealth = 3;

    //1 left 2 right 3 up 4 down
    public int Direction = 0;
      
    
    //set score+text values to nil
    void Start() 
    {
        PlayerScore = 0;
        CollectCount = 0;
        updateCollectCountText ();
        WinText.text = "";
        GameOverText.text = "";
    }


    void Update() 
        {
        //Movement variables, 8 way
        var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        transform.position += move * speed * Time.deltaTime;


        //if (Input.GetKey("left")) { Direction = 1; }
        //if (Input.GetKey("right")) { Direction = 2; }
        //if (Input.GetKey("up")) { Direction = 3; }
        //if (Input.GetKey("down")) { Direction = 4; }


        //Shoot 'Bullet'  


        if (Input.GetKeyDown("space")) 
            {
             Physics2D.IgnoreCollision(bulletPrefab.GetComponent<Collider2D>(), bulletPrefab.GetComponent<Collider2D>());
             Instantiate(bulletPrefab, new Vector3(transform.position.x + front, transform.position.y, 0), Quaternion.identity);

            //if (Direction == 1) {
            //    Physics2D.IgnoreCollision(bulletLeftPrefab.GetComponent<Collider2D>(), bulletLeftPrefab.GetComponent<Collider2D>());
            //    Instantiate(bulletLeftPrefab, new Vector3(transform.position.x + front, transform.position.y, 0), Quaternion.identity);
            //}

            //if (Direction == 2) {
            //    Physics2D.IgnoreCollision(bulletRightPrefab.GetComponent<Collider2D>(), bulletRightPrefab.GetComponent<Collider2D>());
            //    Instantiate(bulletRightPrefab, new Vector3(transform.position.x + front, transform.position.y, 0), Quaternion.identity);
            //}

            //if (Direction == 3) {
            //    Physics2D.IgnoreCollision(bulletUpPrefab.GetComponent<Collider2D>(), bulletUpPrefab.GetComponent<Collider2D>());
            //    Instantiate(bulletUpPrefab, new Vector3(transform.position.x + front, transform.position.y, 0), Quaternion.identity);
                //}

                //if (Direction == 4) {
                //    Physics2D.IgnoreCollision(bulletDownPrefab.GetComponent<Collider2D>(), bulletDownPrefab.GetComponent<Collider2D>());
                //    Instantiate(bulletDownPrefab, new Vector3(transform.position.x + front, transform.position.y, 0), Quaternion.identity);
                //  }


            }
        }
    

    public void updateScore(int Number) 
        {
        PlayerScore += Number;
        PlayerScoreText.text = "SCORE:" + PlayerScore.ToString();
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
        CollectCountText.text = "Memory saved: " + CollectCount.ToString();
        if (CollectCount >= 16) 
            {
        WinText.text = "MEMORY COMPLETE";
            }
        }


    //Enemy Collision Detection. results in losing health
    void OnCollisionEnter2D(Collision2D col) 
        {
        if (col.gameObject.tag == "ENEMY") 
            {
            PlayerHealth = PlayerHealth - 1;
            updatehealth();
            } 
        if (PlayerHealth <= 0) 
            {
            GameOverText.text = "DEADBOT DEAD.";
            }
        }

    //calls to 'battery' graphic in unity. updates to lower health when damaged.
    void updatehealth() 
        {
        GameObject g = GameObject.Find("BATTERYGREEN");
        Health bScript = g.GetComponent<Health>();
        bScript.updateHealth(PlayerHealth);
        }
}
