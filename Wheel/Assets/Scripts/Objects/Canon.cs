using UnityEngine;

public enum CanonFacing
{
    right,
    left,
    up,
    down
}

public class Canon : MonoBehaviour
{
    public CanonFacing facing;

    public GameObject canonBall;
    public float canonBallSpeed;
    public float timeBtwShoot;
    float currentTime;

    private void Update()
    {
        if(currentTime < timeBtwShoot)
        {
            currentTime += Time.deltaTime;
        }
        else
        {
            Rigidbody2D ballRb = Instantiate(canonBall, transform.position, Quaternion.identity).GetComponent<Rigidbody2D>();

            switch (facing)
            {
                case(CanonFacing.left):
                    ballRb.AddForce(-transform.right * canonBallSpeed);
                    break;
                case(CanonFacing.right):
                    ballRb.AddForce(transform.right * canonBallSpeed);
                    break;
                case(CanonFacing.up):
                    ballRb.AddForce(transform.up * canonBallSpeed);
                    break;
                case (CanonFacing.down):
                    ballRb.AddForce(-transform.up * canonBallSpeed);
                    break;
            }

            currentTime = 0;
        }
    }
}
