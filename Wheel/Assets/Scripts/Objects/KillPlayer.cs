using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Kill();
        }
    }

    public void Kill()
    {
        anim.SetTrigger("Killing");
    }
}
