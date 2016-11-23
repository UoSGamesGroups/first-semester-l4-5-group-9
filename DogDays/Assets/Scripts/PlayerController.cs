using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour 
{
	
    public float speed = 5;

    public float front = 0.5f;


    public bool moving = false;


    public int PlayerHealth = 3;

    private int CollectCount;

    public int PlayerScore = 0;


    public Text WinText;

    public Text CollectCountText;

    public Text PlayerScoreText;

    public Text GameOverText;


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
        //Movement, using WASD
        if (Input.GetKey(KeyCode.W)) {
            transform.Translate(Vector3.up * speed * Time.deltaTime, Space.World);
            moving = true;
        }

        if (Input.GetKey(KeyCode.A)) {
            transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
            moving = true;
        }

        if (Input.GetKey(KeyCode.S)) {
            transform.Translate(Vector3.down * speed * Time.deltaTime, Space.World);
            moving = true;
        }

        if (Input.GetKey(KeyCode.D)) {
            transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
            moving = true;
        }

        if (Input.GetKey(KeyCode.W) != true && Input.GetKey(KeyCode.A) != true && Input.GetKey(KeyCode.S) != true && Input.GetKey(KeyCode.D) != true) {
            moving = false;
        }
    }
    
    //Memory Score Count
    public void updateScore(int Number) 
        {
        PlayerScore += Number;
        PlayerScoreText.text = "SCORE:" + PlayerScore.ToString();
        }

    //Pick Up Memory + Score count +1
    public void OnTriggerEnter2D(Collider2D other) 
        {
        if (other.gameObject.CompareTag("PickUp")) 
            {
            other.gameObject.SetActive(false);
            CollectCount = CollectCount + 1;
            updateCollectCountText ();
            }

        // Health Pack gives +1 Health -- no maximum health set.
        if (other.gameObject.tag == "PowerUpHealth") 
        {
            Destroy(other.gameObject);
            PlayerHealth = PlayerHealth + 1;
            updatehealth();
        }

        // Speed Power Up gives faster player movement
        if (other.gameObject.tag == "PowerUpSpeed") 
        {
            Destroy(other.gameObject);
            speed = speed * 2;
            StartCoroutine("PowerUpSpeedDuration");
        }

        //ZOMBIE KILLER 'item' pick up - kills zombies on collision
        if (other.gameObject.CompareTag("ZOMBIEKILLER")) 
        {
            Destroy(other.gameObject);
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("ENEMY");
            foreach (GameObject ENEMY in enemies)
            GameObject.Destroy(ENEMY);
            GameObject g = GameObject.Find("Player");
            PlayerController bScript = g.GetComponent<PlayerController>();
            bScript.updateScore(100);
        }
    }

    // Removes Speed Power Up after 10 seconds
    IEnumerator PowerUpSpeedDuration() 
        {
        yield return new WaitForSeconds(10);
        speed = speed / 2;
        }

    //Score update on pick up. 
    void updateCollectCountText () 
        {
        CollectCountText.text = "Memory saved: " + CollectCount.ToString();
        if (CollectCount >= 7) 
            {
            WinText.text = "MEMORY COMPLETE";
            }
        }


    
    void OnCollisionEnter2D(Collision2D col)
        //Enemy Collision with Player results in losing health
        {
        if (col.gameObject.tag == "ENEMY") 
            {
            PlayerHealth = PlayerHealth - 1;
            updatehealth();
            }
        
        //Game Over displayed if all health lost
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