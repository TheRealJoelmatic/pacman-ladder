using UnityEngine;

[RequireComponent(typeof(Movement))]
public class Pacman : MonoBehaviour
{
    public SpriteRenderer spriteRenderer { get; private set; }
    public new Collider2D collider { get; private set; }
    public Movement movement { get; private set; }

    public AudioSource EatPowerUp;
    public AudioSource Chump;
    public AudioSource Dieds;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider = GetComponent<Collider2D>();
        movement = GetComponent<Movement>();
    }

    private void Update()
    {
        // Set the new direction based on the current input
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) {
            movement.SetDirection(Vector2.up);
            if (FindObjectOfType<GameManager>().HasFire == true)
            {
                GetComponent<FireBall>().WayHeLooking(Vector2.up);
            }
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) {
            movement.SetDirection(Vector2.down);
            if (FindObjectOfType<GameManager>().HasFire == true)
            {
                GetComponent<FireBall>().WayHeLooking(Vector2.down);
            }
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) {
            movement.SetDirection(Vector2.left);
            if (FindObjectOfType<GameManager>().HasFire == true)
            {
                GetComponent<FireBall>().WayHeLooking(Vector2.left);
            }
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) {
            movement.SetDirection(Vector2.right);
            if (FindObjectOfType<GameManager>().HasFire == true)
            {
                GetComponent<FireBall>().WayHeLooking(Vector2.right);
            }
        }

        // Rotate pacman to face the movement direction
        float angle = Mathf.Atan2(movement.direction.y, movement.direction.x);
        transform.rotation = Quaternion.AngleAxis(angle * Mathf.Rad2Deg, Vector3.forward);
    }

    public void ResetState()
    {
        enabled = true;
        spriteRenderer.enabled = true;
        collider.enabled = true;
        movement.ResetState();
        gameObject.SetActive(true);
    }

    public void DeathSequence()
    {
        Dieds.Play();
        enabled = false;
        spriteRenderer.enabled = false;
        collider.enabled = false;
        movement.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PowerUp")
        {
            EatPowerUp.Play();
        }
        if (other.tag == "Normal_Pellits")
        {
            if (!Chump.isPlaying)
            {
                Chump.Play();
            }
        }
    }
    
}
