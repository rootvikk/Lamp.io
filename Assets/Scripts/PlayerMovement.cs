using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private InputController inputControls;

    private Vector2 inputVect;

    private Rigidbody2D playerRB;

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;

    private bool isGrounded;
    private void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();

        inputControls = new InputController();

        inputControls.Player.Move.performed += ctx => inputVect = ctx.ReadValue<Vector2>();
        inputControls.Player.Move.canceled += ctx => inputVect = Vector2.zero;

        inputControls.Player.Jump.performed += ctx => Jump();
    }

    private void OnEnable() => inputControls.Enable();
    private void OnDisable() => inputControls.Disable();

    private void Move()
    {
        playerRB.linearVelocity = new Vector2(inputVect.x * moveSpeed, playerRB.linearVelocity.y);
    }

    private void Jump()
    {
        if (isGrounded)
        {
            playerRB.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        
        if (collision.gameObject.CompareTag("Dead"))
        {
            SceneManager.LoadScene("LoseScreen");
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("End"))
        {
            SceneManager.LoadScene("Level2");
        }
    }
}
