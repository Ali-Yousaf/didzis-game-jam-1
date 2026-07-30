using UnityEngine;

public class BorderFollowX : MonoBehaviour
{
    private Transform player;
    private float xOffset;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        xOffset = transform.position.x - player.position.x;
    }

    private void LateUpdate()
    {
        transform.position = new Vector3(
            player.position.x + xOffset,
            transform.position.y,
            transform.position.z
        );
    }
}