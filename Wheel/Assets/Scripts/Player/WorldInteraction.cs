using UnityEngine;

public class WorldInteraction : MonoBehaviour
{
    //Bouncing
    [Header("Bouncing")]
    public LayerMask bounceLayer;
    Rigidbody2D rb;
    public float jumpForce;

    [Header("AirFlow")]
    public LayerMask airFlowLayer;
    public float airForce;

    //NextLevel
    [Header("Destiny")]
    public LayerMask destinyLayer;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int colliderMask = 1 << collision.gameObject.layer;

        if (colliderMask == bounceLayer)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
        else if (colliderMask == destinyLayer)
        {
            LevelManager.Instance.NextLevel();
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        int colliderMask = 1 << collision.gameObject.layer;

        if (colliderMask == airFlowLayer)
        {
            PlayerMovement playerMov = GetComponent<PlayerMovement>();
            playerMov.isBeingPushed = true;
            playerMov.maxSpeed += airForce;

            AirFlow airFlow = collision.GetComponent<AirFlow>();

            if (airFlow != null)
            {
                if (airFlow.facing == AirFlowFacing.right)
                    rb.AddForce(transform.right * airForce);
                else if (airFlow.facing == AirFlowFacing.left)
                    rb.AddForce(-transform.right * airForce);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        int colliderMask = 1 << collision.gameObject.layer;

        if (colliderMask == airFlowLayer)
        {
            PlayerMovement playerMov = GetComponent<PlayerMovement>();
            playerMov.isBeingPushed = false;
            playerMov.maxSpeed -= airForce;
        }
    }
}