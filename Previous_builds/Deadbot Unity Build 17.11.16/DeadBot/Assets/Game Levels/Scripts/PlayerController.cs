using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour 
{
	
    public float speed = 5;
    public float front = 0.5f;

    public bool moving = false;

    public GameObject bulletPrefab;
    public GameObject bulletPowerPrefab;                           
    public int ShootMode=0;

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

    //Fog Cover
    public int FogAmount = 1;
          
    
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

        // Shoot to Mouse Cursor
        if (Input.GetMouseButtonDown(0)) 
            {
            if (ShootMode == 0) 
                {
                Vector2 target = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
                Vector2 myPos = new Vector2(transform.position.x, transform.position.y);
                Vector2 direction = target - myPos;
                direction.Normalize();
                Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
                GameObject projectile = (GameObject)Instantiate(bulletPrefab, myPos, rotation);
                projectile.GetComponent<Rigidbody2D>().velocity = direction * speed;
                }
            if (ShootMode == 1) 
                {
                Vector2 target = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
                Vector2 myPos = new Vector2(transform.position.x, transform.position.y);
                Vector2 direction = target - myPos;
                direction.Normalize();
                Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
                GameObject projectile = (GameObject)Instantiate(bulletPowerPrefab, myPos, rotation);
                projectile.GetComponent<Rigidbody2D>().velocity = direction * speed;
                }
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

        // Bullet Power Up replaces regular shot with large shot
		if (other.gameObject.tag == "PowerUpBullet") 
		{
			Destroy (other.gameObject);
			updatePower(1);
            StartCoroutine("PowerUpBulletDuration");
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
    }

    // Removes Speed Power Up after 10 seconds
    IEnumerator PowerUpSpeedDuration() 
        {
        yield return new WaitForSeconds(10);
        speed = speed / 2;
        }
    // Removes Bullet Power Up after 10 seconds
     IEnumerator PowerUpBulletDuration() 
        {
        yield return new WaitForSeconds(10);
        updatePower(0);
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
        if (col.gameObject.tag == "ENEMY") 
            {
            FogAmount = FogAmount + 1;
            updatefog();
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

    void updatefog() 
        {
        GameObject g = GameObject.Find("FOG1");
        FogCover bScript = g.GetComponent<FogCover>();
        bScript.updateFog(FogAmount);
        }
    
	void updatePower(int power)
	    {
		ShootMode = power;
	    }
}