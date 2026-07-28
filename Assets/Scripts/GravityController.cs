using UnityEngine;
using DG.Tweening;

public class GravityController : MonoBehaviour
{
    [SerializeField] private float gravityStrength = 9.81f;
    [SerializeField] private RectTransform gravityArrow;
    [SerializeField] private float rotateDuration = 0.25f;

    private float targetZ = 0f;

    private void Start()
    {
        SetGravity(Vector2.down, 0f);
    }

    private void Update()
    {
        ApplyGravity();
    }

    private void ApplyGravity()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            SetGravity(Vector2.up, 180f);
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            SetGravity(Vector2.left, 90f);
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            SetGravity(Vector2.down, 0f);
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            SetGravity(Vector2.right, 270f);
        }
    }

    private void SetGravity(Vector2 direction, float rotation)
    {
        Physics2D.gravity = direction * gravityStrength;

        gravityArrow.DOKill();
        gravityArrow.DOLocalRotate(
            new Vector3(0f, 0f, rotation),
            rotateDuration,
            RotateMode.FastBeyond360
        ).SetEase(Ease.OutCubic);
    }
}