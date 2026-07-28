using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class GravityController : MonoBehaviour
{
    [SerializeField] private float gravityStrength = 9.81f;
    [SerializeField] private RectTransform gravityArrow;
    [SerializeField] private float rotateDuration = 0.25f;

    // 0 = Down, 1 = Left, 2 = Up, 3 = Right
    private int gravityIndex = 0;

    private void Start()
    {
        ApplyGravity();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            gravityIndex++;

            if (gravityIndex > 3)
                gravityIndex = 0;

            ApplyGravity();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            gravityIndex--;

            if (gravityIndex < 0)
                gravityIndex = 3;

            ApplyGravity();
        }
    }

    private void ApplyGravity()
    {
        float targetZ = 0f;

        switch (gravityIndex)
        {
            case 0: // Down
                Physics2D.gravity = new Vector2(0f, -gravityStrength);
                targetZ = -90f;
                break;

            case 1: // Left
                Physics2D.gravity = new Vector2(-gravityStrength, 0f);
                targetZ = 180f;
                break;

            case 2: // Up
                Physics2D.gravity = new Vector2(0f, gravityStrength);
                targetZ = 90f;
                break;

            case 3: // Right
                Physics2D.gravity = new Vector2(gravityStrength, 0f);
                targetZ = 0f;
                break;
        }

        gravityArrow.DOKill();
        gravityArrow.DOLocalRotate(
            new Vector3(0f, 0f, targetZ),
            rotateDuration,
            RotateMode.FastBeyond360
        ).SetEase(Ease.OutCubic);
    }
}