using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private float _shakeDuration;

    public float ShakeAmount = 0.7f;
    public float DecreaseFactor = 1.0f;

    private Vector3 _originalPosition;

    private void Awake()
    {
        _originalPosition = transform.localPosition;
    }
    private void Update()
    {
        if (_shakeDuration > 0)
        {
            transform.localPosition = _originalPosition + Random.insideUnitSphere * ShakeAmount;
            _shakeDuration -= Time.deltaTime * DecreaseFactor;
        }
        else
        {
            _shakeDuration = 0f;
            transform.localPosition = _originalPosition;
        }
    }

    public void StartShake(float duration)
    {
        _originalPosition = transform.localPosition;
        _shakeDuration = duration;
    }
}
