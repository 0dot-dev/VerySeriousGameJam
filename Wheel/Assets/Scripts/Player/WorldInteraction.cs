using UnityEngine;

public class WorldInteraction : MonoBehaviour
{
    public LayerMask bounceLayer;

    Rigidbody2D rb;

    public float jumpForce;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int colliderMask = 1 << collision.gameObject.layer;

        if (bounceLayer == colliderMask)
        {

            //rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);

            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }
}
