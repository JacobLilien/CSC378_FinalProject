using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine;

public class ScaryBird : MonoBehaviour
{
    public int startPoint;
    public Transform[] points;
    public float speed;

    private int i;

    void Start()
    {
        transform.position = points[startPoint].position;

        // Debug start point position
        Debug.Log("Distance: " + Vector2.Distance(transform.position, points[i].position));
        Debug.Log("Start point position: " + points[startPoint].position);
    }

    void Update()
    {
        
        if (Vector2.Distance(transform.position, points[i].position) < 0.02f)
        {
            i++;
            if (i == points.Length)
            {
                i = 0;
            }

            // Debug next point position
            Debug.Log("Next point position: " + points[i].position);
        }

        Vector2 direction = ((Vector2)points[i].position - (Vector2)transform.position).normalized;

        // Calculate angle in degrees
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Rotate the bird to face the direction
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
    }
    
}

