using UnityEngine;

public class WorldInteraction : MonoBehaviour
{
    //Bouncing
    [Header("Bouncing")]
    public LayerMask bounceLayer;
    Rigidbody2D rb;
    public float jumpForce;

    //AirFlow
    [Header("AirFlow")]
    public LayerMask airFlowLayer;
    public float airForce;

    //Deadly
    [Header("Deadly")]
    public LayerMask deadlyLayer;

    //Spawnpoint
    [Header("Spawnpoint")]
    public LayerMask checkPointLayer;

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
        else if(colliderMask == deadlyLayer)
        {
            LevelManager.Instance.RestartLevel();
        }
        else if(colliderMask == checkPointLayer)
        {
            LevelManager.Instance.spawnPoint = collision.gameObject.transform;
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