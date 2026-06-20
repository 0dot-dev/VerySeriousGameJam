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
                rb.linearVelocity = transform.right * speed;
                Debug.Log(rb.linearVelocity);
            }
            else if(spinningSystem.wheelDirection == WheelDirection.left)
                rb.linearVelocity = -transform.right * speed;
            else
                rb.linearVelocity = Vector3.zero;
        }
    }
}