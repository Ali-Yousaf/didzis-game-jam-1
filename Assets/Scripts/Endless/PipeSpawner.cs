using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private GameObject pipePrefab;

    [Header("Spawn")]
    [SerializeField] private float spawnDistance = 20f;
    [SerializeField] private float spacing = 8f;

    [Header("Position")]
    [SerializeField] private float minY = -4f;
    [SerializeField] private float maxY = 4f;

    [Header("Random Scale")]
    [SerializeField] private Vector2 randomWidth = new Vector2(0.8f, 2.5f);
    [SerializeField] private Vector2 randomHeight = new Vector2(2f, 8f);

    private float nextSpawnX;

    private void Start()
    {
        nextSpawnX = player.position.x + spawnDistance;

        for (int i = 0; i < 8; i++)
            SpawnPipe();
    }

    private void Update()
    {
        if (player.position.x + spawnDistance >= nextSpawnX)
        {
            SpawnPipe();
        }
    }

    private void SpawnPipe()
    {
        Vector3 pos = new Vector3(
            nextSpawnX,
            Random.Range(minY, maxY),
            0f);

        GameObject pipe = Instantiate(pipePrefab, pos, Quaternion.identity);

        float width = Random.Range(randomWidth.x, randomWidth.y);
        float height = Random.Range(randomHeight.x, randomHeight.y);

        pipe.transform.localScale = new Vector3(width, height, 1f);

        nextSpawnX += spacing;
    }
}