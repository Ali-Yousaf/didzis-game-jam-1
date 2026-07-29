using UnityEngine;

public class DoorButton : MonoBehaviour
{
    [SerializeField] private Door door;
    [SerializeField] private Sprite buttonPressedSprite;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private BoxCollider2D col;
    [SerializeField] private BoxCollider2D col2;

    private bool pressed = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (pressed || !collision.CompareTag("Player"))
            return;

        pressed = true;

        door.OpenDoor();

        spriteRenderer.sprite = buttonPressedSprite;

        col.offset = new Vector2(col.offset.x, 0.06f);
        col2.offset = new Vector2(col2.offset.x, -0.10f);
    }
}