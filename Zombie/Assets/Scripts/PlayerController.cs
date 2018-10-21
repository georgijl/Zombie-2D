using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float startSpeed;
    public float acceleration = 0.05f;
    public float jumpForce;
    
    public bool isDead;
    public int boxes;

    public AudioClip dieSound;
    public AudioClip jumpSound;

    public GameManager manager;

    public Text boxesCounter;
    private AudioSource audioSrc;
    private Animator playerAnimator;
    private bool isOnGround = true;
    // Use this for initialization
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        playerAnimator = GetComponent<Animator>();
        Vector2 speed = rb.velocity;
        speed.x = startSpeed;
        rb.velocity = speed;
    }

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetButtonDown("Jump") && isOnGround)
        {
            Jump();
        }
    }
    public void FixedUpdate()
    {
        Move();
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        string tag = collision.gameObject.tag;
        isOnGround = false; 
        if(tag == "Floor")
        {
            isOnGround = true;
            playerAnimator.SetBool("Walk", isOnGround);
        }
        else if(tag == "Enemies")
        {
            Die();
        }

     
    }
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Box"))
        {
            boxes++;
            SpriteRenderer spriteRend = collider.GetComponent<SpriteRenderer>();
            spriteRend.enabled = false;
            boxesCounter.text = boxes.ToString();
        }
    }
    public void OnCollisionStay2D(Collision2D collision)
    {

    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        
    }
    private void Jump()
    {
        rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        isOnGround = false;
        playerAnimator.SetBool("Walk", false);
        audioSrc.PlayOneShot(jumpSound, 1);
    }
    private void Move()
    {
        Vector2 newSpeed = rb.velocity;
        newSpeed.x += acceleration;
        rb.velocity = newSpeed;
    }
    private void Die()
    {
        isDead = true;
        audioSrc.PlayOneShot(dieSound);
        playerAnimator.SetTrigger("Die");
        manager.ShowreplayButton();
    }
}

