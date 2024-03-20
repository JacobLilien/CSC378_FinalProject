using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{
    public float visibilityDuration = 2f; // Adjust this value to change the time interval
    private SpriteRenderer spriteRenderer;
    public PolygonCollider2D hitbox;
    public AudioSource lightningstrike;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        hitbox = GetComponent<PolygonCollider2D>();
        lightningstrike = GetComponent<AudioSource>();
        StartCoroutine(ToggleVisibility());
        
    }

    IEnumerator ToggleVisibility()
    {
        while (true)
        {
            spriteRenderer.enabled = true; // Show the sprite
            hitbox.enabled = true;
            lightningstrike.Play();
            yield return new WaitForSeconds(visibilityDuration);

            spriteRenderer.enabled = false; // Hide the sprite
            hitbox.enabled = false;
            yield return new WaitForSeconds(visibilityDuration * 3);
        }
    }

}
