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
    private float horizontalMovement = 0f;
    private bool facingRight = true;
    private AudioSource soundeffect;
    public UnityEvent myEvents;
    private bool collided;
    private bool isDucking;

    Rigidbody2D rb;
    public Animator animator;
    //public new Animation animation;
    
    // Start is called before the first frame update
    private void Awake()
    {
        //healthBar = GetComponentInChildren<FloatingHealthBar>();
    }
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        soundeffect = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isDucking", isDucking);
        animator.SetFloat("Speed", Mathf.Abs(horizontalMovement));
        horizontalMovement = Input.GetAxisRaw("Horizontal") * speed;

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (collided)
            {
                soundeffect.Play();
                animator.SetTrigger("Jump");
                rb.velocity = new Vector2(rb.velocity.x, 10);
                collided = false;
            }
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            Debug.Log("pressing down");
            isDucking = true;
        }
        else
        {
            isDucking = false;
        }


        if (horizontalMovement > 0 && !facingRight)
        {
            Flip();
        }

        else if (horizontalMovement < 0 && facingRight)
        {
            Flip();
        }

    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(7 * horizontalMovement * Time.fixedDeltaTime, rb.velocity.y);
    }

    private void Flip()
    {
        facingRight = !facingRight;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
    
    void OnCollisionEnter2D(Collision2D col)
    {
        GameObject collidedObject = col.gameObject;

        // Now you can do something with the collided object
        // Debug.Log("Collided with: " + collidedObject.name);
        
        if (collidedObject.name.Contains("Grass"))
        {
            collided = true;
            // soundeffect.Play();
            // animator.SetTrigger("Jump");
        }
        else if (collidedObject.name.Contains("CLOUD"))
        {
            collided = true;
            // soundeffect.Play();
            // animator.SetTrigger("Jump");
        }
        else if (collidedObject.name.Contains("Rain"))
        {
            collided = true;
            // soundeffect.Play();
            Destroy(collidedObject);
            // animator.SetTrigger("Jump");
        }
        else if (collidedObject.name.Contains("Golden"))
        {
            SceneManager.LoadScene(3);
        }  

    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (myEvents == null)
        {

        }
        else
        {
            myEvents.Invoke();
        }
    }
    
}
