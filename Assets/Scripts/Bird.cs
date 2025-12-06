using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bird : MonoBehaviour
{
    public static Bird Instance { get; private set; }

    private const float GRAVITY_NORMAL = 1f;
    public enum State 
    { 
        WaitingToStart,
        Play,
        GameOver,
    }


    public event EventHandler OnHittingPipe;
    public event EventHandler OnPlayState;
    public event EventHandler OnPassingPipe;

    private Rigidbody2D birdRigidbody2D;
    private State state;

    [SerializeField] private float speed;

    private void Awake()
    {
        Instance = this;
        birdRigidbody2D = GetComponent<Rigidbody2D>();
        state = State.WaitingToStart;
        birdRigidbody2D.gravityScale = 0f;

    }

    private void FixedUpdate()
    {
        switch (state)
        {
            case State.WaitingToStart:
                
                if (Keyboard.current.spaceKey.isPressed)
                {
                    birdRigidbody2D.gravityScale = GRAVITY_NORMAL;
                    state = State.Play;
                    OnPlayState?.Invoke(this,EventArgs.Empty); 
                    
                }
                break;
            case State.Play:
                if (Keyboard.current.spaceKey.isPressed)
                {
                    birdRigidbody2D.AddForce(Vector2.up * speed * Time.fixedDeltaTime);
                }
                break;
            case State.GameOver: break;
                default:
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        Pipe pipe = collision2D.collider.GetComponentInParent<Pipe>();
        if (pipe != null)
        {
            state=State.GameOver;
            OnHittingPipe?.Invoke(this, EventArgs.Empty);
        }
    }
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.gameObject.TryGetComponent(out Pipe pipe))
        {
            OnPassingPipe?.Invoke(this, EventArgs.Empty);
        }
    }
}
