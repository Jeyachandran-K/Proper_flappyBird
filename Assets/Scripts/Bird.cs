using UnityEngine;
using UnityEngine.InputSystem;

public class Bird : MonoBehaviour
{

    private Rigidbody2D birdRigidbody2D;
    [SerializeField] private float speed;

    private void Awake()
    {
        birdRigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (Keyboard.current.spaceKey.isPressed)
        {
            birdRigidbody2D.AddForce(Vector2.up * speed * Time.fixedDeltaTime);
        }
    }
}
