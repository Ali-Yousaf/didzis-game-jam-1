using UnityEngine;

public class DestroyBehindPlayer : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float destroyDistance = 25f;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (transform.position.x < player.position.x - destroyDistance)
        {
            Destroy(gameObject);
        }
    }
}