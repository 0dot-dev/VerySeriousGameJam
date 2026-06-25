using UnityEngine;

public class Canon : MonoBehaviour
{
    Animator anim;

    public GameObject canonBall;
    public Transform spawnPoint;

    public float canonBallSpeed;
    public float timeBtwShoot;
    float currentTime;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if(currentTime < timeBtwShoot)
        {
            currentTime += Time.deltaTime;
        }
        else
        {
            anim.SetTrigger("Launch");

            Rigidbody2D ballRb = Instantiate(canonBall, spawnPoint.position, Quaternion.identity).GetComponent<Rigidbody2D>();
            ballRb.AddForce(transform.right * canonBallSpeed);

            currentTime = 0;
        }
    }
}
