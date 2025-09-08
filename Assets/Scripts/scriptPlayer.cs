using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scriptPlayer : MonoBehaviour
{
    //general game variables
    public float movementSpeed;
    public float healthPoints;
    public float gemScore;

    //variables for player attack
    public Transform staff;
    public GameObject manaBlast;

    public int maxMana;
    public int currentMana;
    public int maxLightning;
    public int currentLightning;
    public float reloadTime;
    public bool isReloading = false;


    //variables for player jump
    Rigidbody2D playerRb;

    public float jumpForce;
    float groundCheckRadius = 1f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    bool grounded = false;

    //bools 
    bool facingRight = true;
    public bool isInClimbSpace;
    public bool talkingToNPC = false;
    public bool questComplete = false;


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    //set update not in line with time.deltaTime
    void FixedUpdate()
    {
        //player movements
        float move = Input.GetAxis("Horizontal");         //registers that move will equal players horizontal movement

        playerRb.velocity = new Vector2(move * movementSpeed, playerRb.velocity.y);       //player movement

        if (move > 0 && !facingRight)              //player facing left
        {
            flip();                            //flip
        }
        else if (move < 0 && facingRight)            //player facing right
        {
            flip();                            //flip
        }

        //player jump
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);    //grounded means that ground check is in contact with ground layer

        if (Input.GetAxis("Jump") > 0 && grounded)         //is the jump key pressed and is the character on the ground 
        {
            playerRb.AddForce(Vector2.up * jumpForce * Input.GetAxis("Jump"), ForceMode2D.Impulse);       //jump
        }

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -15, 130), Mathf.Clamp(transform.position.y, -100, 100), 0);    //level clamp 

        //climb 
        if (isInClimbSpace && Input.GetKey("up"))     //is player within the climb space with the up key pressed
        {
            transform.Translate(0, movementSpeed * Time.deltaTime, 0);      //get player to move up 
            playerRb.gravityScale = 0;                                      //set player gravity to 0 
        }
        else                               //not in climb space

        {
            playerRb.gravityScale = 10;                                     //set player gravity back to 10
        } 

        //attacks
        if (Input.GetKeyDown("c") && currentMana > 0)             //is the c key pressed down and does the player spell attack have ammo in it
        {
            Instantiate(manaBlast, staff.position, transform.rotation);       //spawn a projectile
            currentMana -= 1;                         //take 1 from player's current ammo
        }
        else if (currentMana <= 0)                //is the player's ammo down to 0
        {
            StartCoroutine(Reload());             //start reload function
            return;
        }
        if (isReloading)
        {
            return;
        }

        if (Input.GetKeyDown("escape"))     
        {
            SceneManager.LoadScene("SceneMainMenu");      
        }

        if (healthPoints <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("SceneLose");
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        grounded = true;  
    }
    IEnumerator Reload()
    {
        isReloading = true;              //is relaoding will be true

        Debug.Log("Reloading...");       //type 'reloading...' in the console

        yield return new WaitForSeconds(reloadTime);      //wait for the amount of time in the reloadTime

        currentMana = maxMana;     //currentMana will go back to maxMana 
        isReloading = false;       //is reloading is back to false
    }
    void OnCollisionEnter2D(Collision2D other)       
    {
        if (other.transform.tag == "Enemy")
        {
            healthPoints -= 1;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Gem")
        {
            gemScore += 1;
            Destroy(collision.gameObject);
        }
        if (collision.transform.tag == "Projectile")
        {
            Destroy(collision.gameObject);
            healthPoints -= 1;

        }
        if (collision.transform.tag == "Water")
        {
            Destroy(collision.gameObject);
            healthPoints -= 1;
        }
        if (collision.transform.tag == "NPC")
        {
            talkingToNPC = true;
        }
        if(collision.transform.tag == "Shovel")
        {
            questComplete = true;
            Destroy(collision.gameObject);
        }
        if (collision.transform.tag == "End")
        {
            SceneManager.LoadScene("SceneWin");
        }

    }
    void OnTriggerExit2D(Collider2D collision)
    {
       if (collision.transform.tag == "NPC")
        {
            talkingToNPC = false;
        } 
    }

    void flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, -180f, 0f);
    }
}
