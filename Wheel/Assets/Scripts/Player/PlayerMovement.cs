using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public SpinningSystem spinningSystem;

    Rigidbody2D rb;
    public float speed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if(spinningSystem != null)
        {
            if(spinningSystem.wheelDirection == WheelDirection.right)
            {
                rb.AddForce(Vector2.right * speed);         
            }
            else if(spinningSystem.wheelDirection == WheelDirection.left)
            {
                rb.AddForce(-Vector2.right * speed);
            }
            else
            {
                rb.linearVelocityX = Mathf.Lerp(rb.linearVelocity.x, 0, 5f * Time.deltaTime);
            }

            if (rb.linearVelocityX > speed)
                rb.linearVelocityX = speed;
        }
    }
}