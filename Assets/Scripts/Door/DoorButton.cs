using System;
using UnityEngine;

public class DoorButton : MonoBehaviour
{
    [SerializeField] private Door door;

    [SerializeField] private ParticleSystem collectParticle;

    private SpriteRenderer sp;

    void Awake()
    {
        sp = GetComponent<SpriteRenderer>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        door.OpenDoor();
        sp.enabled = false;

        if(collectParticle != null)
            collectParticle.Play();

        AudioManager.Instance.PlaySFX(AudioManager.Instance.buttonCollectSFX);

        Destroy(gameObject, 0.5f);
    }
}