using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class playerDeath : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

private void OnCollisionEnter2D (Collision2D collision) {

if(collision.gameObject.CompareTag("evil")){
    Die();
    RestartLevel();
}

}

private void Die(){
rb.bodyType = RigidbodyType2D.Static;
animator.SetTrigger("death");

}

private void RestartLevel(){
SceneManager.LoadScene(SceneManager.GetActiveScene().name);
}

}