using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float velocidade = 5f;
    public float forcaPulo = 8f;

    private Animator animator;
    private Rigidbody2D rb;
    private bool pulando = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float player = 0f;

        // Movimento para esquerda
        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
        {
            player = -1f;
        }

        // Movimento para direita
        if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
        {
            player = 1f;
        }

        // Movimento
        transform.Translate(Vector2.right * player * velocidade * Time.deltaTime);

        // Pulo
        if (Keyboard.current.spaceKey.wasPressedThisFrame && !pulando)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, forcaPulo);
            pulando = true;
        }

        // Animações
        if (pulando)
        {
            animator.Play("Jump_gangster");
        }
        else if (player != 0)
        {
            animator.Play("Walk_gangster");
        }
        else
        {
            animator.Play("idle_gangster");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (ContactPoint2D contact in collision.contacts)
        {
            if (contact.normal.y > 0.5f)
            {
                pulando = false;
                break;
            }
        }
    }
}


