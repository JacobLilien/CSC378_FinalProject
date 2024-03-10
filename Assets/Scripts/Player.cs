using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    public float health, maxHealth = 10f;
    //[Serialized Field] FloatingHealthBar healthBar;

    public float speed = 40f;
    private float horizontalMovement = 10f;

    private AudioSource soundeffect;
    public UnityEvent myEvents;

    private bool isJumping = false;
    private bool facingRight = true;
    private bool isDucking;

    public Rigidbody2D rb;
    public Animator animator;

    public CircleCollider2D normalHitbox;
    public CapsuleCollider2D duckingHitbox;

    
    private void Awake()
    {
        //healthBar = GetComponentInChildren<FloatingHealthBar>();
    }
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        soundeffect = GetComponent<AudioSource>();
        normalHitbox = GetComponent<CircleCollider2D>();
        duckingHitbox = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isDucking", isDucking);
        animator.SetFloat("Speed", Mathf.Abs(horizontalMovement));
        float yvelocity = rb.velocity.y;
        Debug.Log(yvelocity);


        if (Input.GetKeyDown(KeyCode.UpArrow) && isJumping == false && Mathf.Abs(yvelocity) < 1)
        {
            Jump();
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            setDuck();
        }

        else
        {
            setNormal();
        }

    }

    void FixedUpdate()
    {
        setLeftRightMovement();
    }

    void setLeftRightMovement()
    {
        rb.velocity = new Vector2(7 * horizontalMovement * Time.fixedDeltaTime, rb.velocity.y);
        horizontalMovement = Input.GetAxisRaw("Horizontal") * speed;
        
        if (horizontalMovement > 0 && !facingRight)
        {
            Flip();
        }

        else if (horizontalMovement < 0 && facingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    void Jump()
    {
        soundeffect.Play();
        animator.SetTrigger("Jump");
        rb.velocity = new Vector2(rb.velocity.x, 10);
        isJumping = true;
    }

    void setDuck()
    {
        isDucking = true;
        duckingHitbox.enabled = true;
        normalHitbox.enabled = false;
    }

    void setNormal()
    {
        isDucking = false;
        normalHitbox.enabled = true;
        duckingHitbox.enabled = false;
    }
    
    void OnCollisionEnter2D(Collision2D col)
    {
        GameObject collidedObject = col.gameObject;
        
        if (collidedObject.name.Contains("Grass"))
        {
            isJumping = false;
        }
        else if (collidedObject.name.Contains("CLOUD"))
        {
            isJumping = false;
        }
        else if (collidedObject.name.Contains("Rain"))
        {
            isJumping = false;
            Destroy(collidedObject);
        }
        else if (collidedObject.name.Contains("Golden"))
        {
            SceneManager.LoadScene(3);
        }  

    }
    
}
