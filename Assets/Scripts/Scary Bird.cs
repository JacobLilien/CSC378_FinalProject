using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
    }
}

