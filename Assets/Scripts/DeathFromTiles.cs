using UnityEngine;

public class DeathFromTiles : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            print("PLAYED DIED");
        }
    }
}
