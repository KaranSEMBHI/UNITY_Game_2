using UnityEngine;

public class Player : MonoBehaviour
{
    // Reference to the SpriteRenderer component attached to this GameObject
    private SpriteRenderer spriteRenderer;

    // Array of sprites to animate the player
    public Sprite[] sprites;

    // Index to keep track of the current sprite
    private int spriteIndex;

    // Vector representing the direction in which the player is moving
    private Vector3 direction;

    // Gravity affecting the player's vertical movement
    public float gravity = -9.8f;

    // Strength of the player's jump
    public float jumpStrength = 5f;

    // Called when the script instance is being loaded
    private void Awake()
    {
        // Get the SpriteRenderer component attached to this GameObject
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Called when the script instance is first enabled
    private void Start()
    {
        // Invoke the method to animate the sprite repeatedly with a delay
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }

    // Called every time the script instance is enabled
    private void OnEnable()
    {
        // Reset the player's position and direction when the script is enabled
        ResetPlayer();
    }

    // Reset player position and direction
    private void ResetPlayer()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }

    // Called every frame
    private void Update()
    {
        // Check for player input to initiate a jump
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Jump();
        }

        // Check for the escape key to temporarily pause the game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            FindObjectOfType<GameManager>().TempPause();
        }

        // Apply gravity to the player's vertical movement
        direction.y += gravity * Time.deltaTime;

        // Move the player based on the calculated direction and time passed since the last frame
        transform.position += direction * Time.deltaTime;
    }

    // Method to handle player jump
    private void Jump()
    {
        // Set the upward direction with the specified jump strength
        direction = Vector3.up * jumpStrength;
    }

    // Method to animate the player's sprite
    private void AnimateSprite()
    {
        // Increment the sprite index
        spriteIndex++;

        // Wrap around to the first sprite if the index exceeds the number of sprites
        if (spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }

        // Set the current sprite based on the index
        spriteRenderer.sprite = sprites[spriteIndex];
    }

    // Called when the Collider2D enters another Collider2D trigger zone
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check the tag of the collided GameObject and call appropriate methods in GameManager
        if (other.gameObject.tag == "obstacle")
        {
            FindObjectOfType<GameManager>().GameOver();
        }
        else if (other.gameObject.tag == "scoring")
        {
            FindObjectOfType<GameManager>().IncreaseScore();
        }
    }
}
