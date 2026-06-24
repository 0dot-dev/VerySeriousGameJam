using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public SpinningSystem spinningSystem;

    [HideInInspector]
    public bool isBeingPushed;

    Rigidbody2D rb;
    public float speed;
    public float maxSpeed;

    public SpriteRenderer texture;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        maxSpeed = speed;
    }

    private void FixedUpdate()
    {
        if(spinningSystem != null)
        {
            if(spinningSystem.wheelDirection == WheelDirection.right)
            {            
                texture.flipX = true;
                rb.AddForce(Vector2.right * speed);         
            }
            else if(spinningSystem.wheelDirection == WheelDirection.left)
            {
                texture.flipX = false;
                rb.AddForce(-Vector2.right * speed);
            }
            else
            {
                if(!isBeingPushed)
                    rb.linearVelocityX = Mathf.Lerp(rb.linearVelocity.x, 0, 5f * Time.deltaTime);
            }

            if (rb.linearVelocityX > maxSpeed)
                rb.linearVelocityX = maxSpeed;
        }
    }
}