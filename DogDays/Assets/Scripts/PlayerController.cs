using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public float speed = 5;
    public float front = 0.5f;


    public bool moving = false;
    public bool alive = true;


    public int PlayerHealth = 3;
    public int PlayerScore = 0;
    private int CollectCount;


    public Text WinText;
    public Text CollectCountText;
    public Text PlayerScoreText;
    public Text GameOverText;
    public Text TryAgainText;
    public Text PressContinueText;

    public CanvasGroup GameOverCanvas;
    public CanvasGroup VictoryCanvas;
    public Health healthScript;
    public Renderer rend;

    public Animator anim;

    public enum PlayerState
    {
        normal,
        overcharge,
        godmode,
        dead
    }

    public PlayerState playerState = PlayerState.normal;

    //set score+text values to nil
    void Start() {
        rend = GetComponent<Renderer>();
        playerState = PlayerState.normal;
        PlayerScore = 0;
        CollectCount = 0;
        updateCollectCountText();
        WinText.text = "";
        GameOverText.text = "";
        TryAgainText.text = "";
        PressContinueText.text = "";
    }


    void Update()
    {
        #region Movement
        moving = false;

        if (Input.GetKey(KeyCode.W) && alive)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime, Space.World);
            moving = true;
            anim.SetFloat("YSpeed", 1.0f);
        } 

        if (Input.GetKey(KeyCode.A) && alive)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
            moving = true;
            anim.SetFloat("XSpeed", -1.0f);
        }

        if (Input.GetKey(KeyCode.S) && alive)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime, Space.World);
            moving = true;
            anim.SetFloat("YSpeed", -1.0f);
        }

        if (Input.GetKey(KeyCode.D) && alive)
        {
            anim.SetFloat("XSpeed", 1.0f);
            transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
            moving = true;
        }

        if ( !moving )
        {
            anim.SetFloat("XSpeed", 0.0f);
            anim.SetFloat("YSpeed", 0.0f);
        }
#endregion

#region PlayerState
        switch (playerState)
        {
            case PlayerState.normal:
                healthScript.updateHealth(PlayerHealth);
                break;

            case PlayerState.overcharge:
                StartCoroutine(Overcharge());
                break;

            case PlayerState.godmode:  //use for testing
                healthScript.updateHealth(999);
                break;

            case PlayerState.dead:
                StartCoroutine(Dead());
                break;
        }

        if (PlayerHealth == 4)
            playerState = PlayerState.overcharge;

    }

    IEnumerator Overcharge() {
        healthScript.updateHealth(4);
        yield return new WaitForSeconds(2);
        playerState = PlayerState.normal;
        healthScript.updateHealth(3);
        PlayerHealth = 3;
    }

    IEnumerator Dead() {
        healthScript.updateHealth(0);
        alive = false;
        yield return new WaitForSeconds(1);
        rend.enabled = false;
        GameOverCanvas.alpha = 1;
        GameOverText.text = "PLAYER DEAD.";
        yield return new WaitForSeconds(2);
        TryAgainText.text = "Press 'R' to try again";
        if (Input.GetKey(KeyCode.R))
        {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    #endregion

    //Memory Score Count
    public void updateScore(int Number) 
    {
        PlayerScore += Number;
        PlayerScoreText.text = "SCORE:" + PlayerScore.ToString();
    }

    //Pick Up Memory + Score count +1
    public void OnTriggerEnter2D(Collider2D other) {
        //if (other.gameObject.CompareTag("PickUp")) 
        //    {
        //    other.gameObject.SetActive(false);
        //    CollectCount = CollectCount + 1;
        //    updateCollectCountText ();
        //    }

        // Health Pack gives +1 Health -- no maximum health set.
        //if (other.gameObject.tag == "PowerUpHealth") 
        //{
        //    Destroy(other.gameObject);
        //    PlayerHealth = PlayerHealth + 1;
        //    updatehealth();
        //}

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
            other.gameObject.SetActive(false);
            PlayerHealth = PlayerHealth + 1;
            CollectCount = CollectCount + 1;
            updateCollectCountText();
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("ENEMY");
            foreach (GameObject ENEMY in enemies)
            GameObject.Destroy(ENEMY);
            GameObject g = GameObject.Find("Player");
            PlayerController bScript = g.GetComponent<PlayerController>();
            bScript.updateScore(100);
            //healthScript.updateHealth(PlayerHealth); // make sure to call last, so health changed before updating
            //playerState = PlayerState.overcharge;
        }
    }

    // Removes Speed Power Up after 10 seconds
    IEnumerator PowerUpSpeedDuration() {
        yield return new WaitForSeconds(10);
        speed = speed / 2;
    }

    // IEnumerator Overcharge()
    //{
    //     yield return new WaitForSeconds(2);

    //     PlayerHealth = PlayerHealth -1;
    // }

    //Score update on pick up. 
    void updateCollectCountText() {
        CollectCountText.text = "Memory saved: " + CollectCount.ToString();
        if (CollectCount > 7) {
            VictoryCanvas.alpha = 1;
            WinText.text = "All Crystals Collected. Memory Saved. Proceed to Next Level.";
            Destroy(GameObject.FindWithTag("FinalDoor"));
        }
    }



    void OnCollisionEnter2D(Collision2D col)
        //Enemy Collision with Player results in losing health
    {
        if (col.gameObject.tag == "ENEMY") 
        {
            PlayerHealth = PlayerHealth - 1;
            healthScript.updateHealth(PlayerHealth);
        }
        else if (col.gameObject.tag == "SPIKEWALL") 
        {
            PlayerHealth = PlayerHealth - 1;
            healthScript.updateHealth(PlayerHealth);
        }

        //Game Over displayed if all health lost
        if (PlayerHealth <= 0) 
        {
            playerState = PlayerState.dead;
        }
    }
}