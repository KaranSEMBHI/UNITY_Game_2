using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    // Reference to the MeshRenderer component attached to this GameObject
    private MeshRenderer meshRenderer;

    // Speed at which the texture should be animated
    public float animationSpeed = 1f;

    // Called when the script instance is being loaded
    private void Awake()
    {
        // Get the MeshRenderer component attached to this GameObject
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Called every frame
    private void Update()
    {
        // Update the offset of the main texture based on the animation speed and time passed since the last frame
        meshRenderer.material.mainTextureOffset += new Vector2(animationSpeed * Time.deltaTime, 0);
    }
}
