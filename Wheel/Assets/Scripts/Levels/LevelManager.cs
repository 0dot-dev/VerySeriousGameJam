using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    public GameObject player;
    Rigidbody2D rb;
    public Transform spawnPoint;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        rb = player.GetComponent<Rigidbody2D>();
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void RestartLevel()
    {
        rb.linearVelocity = Vector3.zero;
        player.transform.position = spawnPoint.position;
    }
}
