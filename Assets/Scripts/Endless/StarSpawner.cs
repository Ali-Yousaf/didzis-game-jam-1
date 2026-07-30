using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private GameObject starPrefab;

    [Header("Spawn")]
    [SerializeField] private float spawnDistance = 20f;
    [SerializeField] private Vector2 spacingRange = new Vector2(4f, 8f);

    [Header("Spawn Area")]
    [SerializeField] private float minY = -4f;
    [SerializeField] private float maxY = 4f;

    private float nextSpawnX;

    private void Start()
    {
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player").transform;

        nextSpawnX = player.position.x + spawnDistance;

        for (int i = 0; i < 10; i++)
        {
            SpawnStar();
        }
    }

    private void Update()
    {
        while (player.position.x + spawnDistance > nextSpawnX)
        {
            SpawnStar();
        }
    }

    private void SpawnStar()
    {
        Vector3 pos = new Vector3(
            nextSpawnX,
            Random.Range(minY, maxY),
            0f);

        Instantiate(starPrefab, pos, Quaternion.identity);

        nextSpawnX += Random.Range(spacingRange.x, spacingRange.y);
    }
}