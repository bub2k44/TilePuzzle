using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float shakeMagnitude = 0.05f, shakeTime = 0.05f;

    private Vector3 cameraInitialPosition;

    private Camera mainCamera;

    private void Awake()
    {
        mainCamera = FindObjectOfType<Camera>();
    }

    public void ShakeCamera()
    {
        cameraInitialPosition = mainCamera.transform.position;

        InvokeRepeating("StartCameraShake", 0f, 0.005f);
        Invoke("StopCameraShake", shakeTime);
    }

    private void StartCameraShake()
    {
        float cameraShakeOffsetX = 2 * shakeMagnitude * 2 - shakeMagnitude;
        float cameraShakeOffsetY = 2 * shakeMagnitude * 2 + shakeMagnitude;

        Vector3 cameraIntermediatePosition = mainCamera.transform.position;

        cameraIntermediatePosition.x += cameraShakeOffsetX;
        cameraIntermediatePosition.y += cameraShakeOffsetY;

        mainCamera.transform.position = cameraIntermediatePosition;
    }

    private void StopCameraShake()
    {
        CancelInvoke("StartCameraShake");

        mainCamera.transform.position = cameraInitialPosition;
    }
}