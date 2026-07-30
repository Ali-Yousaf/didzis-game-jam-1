using UnityEngine;

public class PortalController : MonoBehaviour
{
    public Transform destinationPortal;
    private GameObject player;


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if(Vector2.Distance(player.transform.position, transform.position) > 0.5f)
            {
                player.transform.position = destinationPortal.transform.position;
                AudioManager.Instance.PlaySFX(AudioManager.Instance.teleportSFX);
            }
        }
    }
}
