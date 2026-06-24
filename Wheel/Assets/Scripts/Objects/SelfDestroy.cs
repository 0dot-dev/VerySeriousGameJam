using System.Collections;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    public LayerMask destroyLayers;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int colliderMask = 1 << collision.gameObject.layer;

        if(colliderMask == destroyLayers)
            Destroy(gameObject);
    }

}
