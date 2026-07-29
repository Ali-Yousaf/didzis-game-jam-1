using UnityEngine;

public class CollectibleStar : MonoBehaviour
{
    private SpriteRenderer sp;

    void Awake()
    {
        sp = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        StarsManager.Instance.CollectStar();
        sp.enabled = false;

        AudioManager.Instance.PlaySFX(AudioManager.Instance.starCollectSFX);

        Destroy(gameObject, 0.5f);
    }
}