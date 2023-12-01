using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Pipes : MonoBehaviour
{
    // Speed at which the pipes move to the left
    public float speed = 5f;

    // Variable to store the left edge position based on the screen
    private float leftEdge;

    // Called when the script instance is being loaded
    private void Start()
    {
        // Calculate the left edge position based on the screen
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
    }

    // Called every frame
    private void Update()
    {
        // Move the pipes to the left based on the speed and time passed since the last frame
        transform.position += Vector3.left * speed * Time.deltaTime;

        // Check if the pipes have moved beyond the left edge
        if (transform.position.x < leftEdge)
        {
            // Destroy the GameObject when it's beyond the left edge
            Destroy(gameObject);
        }
    }
}
