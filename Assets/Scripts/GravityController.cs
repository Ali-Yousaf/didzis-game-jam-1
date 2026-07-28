using UnityEngine;
using DG.Tweening;

public class GravityController : MonoBehaviour
{
    [Header("Gravity")]
    [SerializeField] private float gravityStrength = 9.81f;

    [Header("UI")]
    [SerializeField] private RectTransform gravityArrow;
    [SerializeField] private float rotateDuration = 0.2f;

    private Vector3 originalScale;

    private void Awake()
    {
        originalScale = gravityArrow.localScale;
    }

    private void Start()
    {
        SetGravity(Vector2.down, 0f);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            SetGravity(Vector2.up, 180f);
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            SetGravity(Vector2.left, 270f);
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            SetGravity(Vector2.down, 0f);
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            SetGravity(Vector2.right, 90f);
        }
    }

    private void SetGravity(Vector2 direction, float rotation)
    {   
        PlayAudio();
        Physics2D.gravity = direction * gravityStrength;

        gravityArrow.DOKill();

        Sequence sequence = DOTween.Sequence();

        // Rotate
        sequence.Join(
            gravityArrow.DOLocalRotate(
                new Vector3(0f, 0f, rotation),
                rotateDuration,
                RotateMode.FastBeyond360
            ).SetEase(Ease.OutCubic)
        );

        // Small pop
        sequence.Join(
            gravityArrow.DOScale(originalScale * 1.05f, 0.08f)
                .SetEase(Ease.OutQuad)
        );

        sequence.Append(
            gravityArrow.DOScale(originalScale, 0.08f)
                .SetEase(Ease.InQuad)
        );
    }

    private void PlayAudio()
    {
        //AudioManager.Instance.PlayRandomizedPitchSFX(AudioManager.Instance.whooshSound);
    }
}