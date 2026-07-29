using UnityEngine;
using DG.Tweening;

public class FloatAnimation : MonoBehaviour
{
    [SerializeField] private float floatHeight = 0.15f;
    [SerializeField] private float duration = 1.5f;
    [SerializeField] private Ease ease = Ease.InOutSine;

    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.localPosition;

        transform.DOLocalMoveY(startPosition.y + floatHeight, duration)
            .SetEase(ease)
            .SetLoops(-1, LoopType.Yoyo);
    }

    private void OnDestroy()
    {
        transform.DOKill();
    }
}