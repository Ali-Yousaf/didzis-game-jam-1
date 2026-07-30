using UnityEngine;
using DG.Tweening;
using System.Collections;

public class CameraEffects : MonoBehaviour
{
    public static CameraEffects Instance;

    [Header("References")]
    [SerializeField] private Camera cam;

    [Header("Freeze")]
    [SerializeField] private float freezeDuration = 0.05f;

    [Header("Shake")]
    [SerializeField] private float shakeDuration = 0.15f;
    [SerializeField] private float shakeStrength = 0.18f;
    [SerializeField] private int shakeVibrato = 18;

    private Vector3 defaultPos;

    private void Awake()
    {
        Instance = this;

        if (cam == null)
            cam = Camera.main;
    }

    public void GravityImpact()
    {
        StartCoroutine(FreezeFrame());

        cam.transform.DOKill();

        Vector3 currentPos = cam.transform.localPosition;

        cam.transform.DOShakePosition(
            shakeDuration,
            shakeStrength,
            shakeVibrato,
            90f,
            false,
            true
        ).OnComplete(() =>
        {
            cam.transform.localPosition = currentPos;
        });
    }

    private IEnumerator FreezeFrame()
    {
        Time.timeScale = 0f;

        yield return new WaitForSecondsRealtime(freezeDuration);

        Time.timeScale = 1f;
    }
}