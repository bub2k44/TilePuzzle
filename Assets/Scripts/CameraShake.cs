using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float shakeMagnitude = 0.05f, shakeTime = 0.05f;

    private Vector3 _cameraInitialPosition;
    private Camera _mainCamera;

    private void Awake()
    {
        _mainCamera = FindObjectOfType<Camera>();
    }

    public void ShakeCamera()
    {
        _cameraInitialPosition = _mainCamera.transform.position;
        InvokeRepeating("StartCameraShake", 0f, 0.005f);
        Invoke("StopCameraShake", shakeTime);
    }

    private void StartCameraShake()
    {
        //float cameraShakeOffsetX = Random.value * shakeMagnitude * 2 - shakeMagnitude;
        //float cameraShakeOffsetY = Random.value * shakeMagnitude * 2 - shakeMagnitude;
        float cameraShakeOffsetX = 2 * shakeMagnitude * 2 - shakeMagnitude;
        float cameraShakeOffsetY = 2 * shakeMagnitude * 2 + shakeMagnitude;
        Vector3 cameraIntermediatePosition = _mainCamera.transform.position;
        cameraIntermediatePosition.x += cameraShakeOffsetX;
        cameraIntermediatePosition.y += cameraShakeOffsetY;
        _mainCamera.transform.position = cameraIntermediatePosition;
    }

    private void StopCameraShake()
    {
        CancelInvoke("StartCameraShake");
        _mainCamera.transform.position = _cameraInitialPosition;
    }
}
