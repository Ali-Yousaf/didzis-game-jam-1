using UnityEngine;
using DG.Tweening;

public class UITextBounce : MonoBehaviour
{
    [SerializeField] private float bounceHeight = 10f;
    [SerializeField] private float duration = 1.5f;

    private RectTransform rectTransform;
    private Vector2 startPosition;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        startPosition = rectTransform.anchoredPosition;
    }

    private void Start()
    {
        rectTransform.DOAnchorPosY(startPosition.y + bounceHeight, duration)
            .SetEase(Ease.InOutSine)
            .SetLoops(-1, LoopType.Yoyo);
    }

    private void OnDestroy()
    {
        rectTransform.DOKill();
    }
}