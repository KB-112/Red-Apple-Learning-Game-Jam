using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerCameraController : MonoBehaviour
{
    public List<Transform> positiveDeadZones;
    public List<Transform> negativeDeadZones;
    public CinemachineVirtualCamera virtualCamera;
    public Transform playerTransform;

    private bool isInDeadZone = false;
    private float defaultBodySizeY = 0.5f;
    private float currentBodySizeY;

    private float defaultLookaheadTime = 0.5f;
    private float currentLookaheadTime;

    void Start()
    {
        currentBodySizeY = defaultBodySizeY;
        currentLookaheadTime = defaultLookaheadTime;
        UpdateCameraBodySize();
       // ShakeCamera(5,5);
     
    }

    void Update()
    {
        CheckDeadZone();
        AdjustCameraFollow();
        HandleBodySizeChange();

    }

    void CheckDeadZone()
    {
        if (playerTransform.position.x >= 0)
        {
            CheckDeadZoneInList(positiveDeadZones);
        }
        else
        {
            CheckNegativeDeadZone();
        }
    }

    void CheckDeadZoneInList(List<Transform> deadZones)
    {
        isInDeadZone = false;

        foreach (Transform deadZone in deadZones)
        {
            if (playerTransform.position.x >= deadZone.position.x)
            {
                isInDeadZone = true;
                return;
            }
        }
    }

    void CheckNegativeDeadZone()
    {
        isInDeadZone = false;

        foreach (Transform deadZone in negativeDeadZones)
        {
            if (playerTransform.position.x <= deadZone.position.x)
            {
                isInDeadZone = true;
                return;
            }
        }
    }

    void AdjustCameraFollow()
    {
        if (isInDeadZone)
        {
            virtualCamera.Follow = null;
        }
        else
        {
            virtualCamera.Follow = playerTransform;
        }
    }

    void HandleBodySizeChange()
    {
        if (Input.GetKey(KeyCode.W))
        {
            currentBodySizeY = 0.6f;
            UpdateCameraBodySize();
        }
        else if (Input.GetKey(KeyCode.S))
        {
            currentBodySizeY = 0.4f;
            UpdateCameraBodySize();
        }
        else
        {
            // Default size when neither W nor S is pressed
            currentBodySizeY = defaultBodySizeY;
            UpdateCameraBodySize();
        }
    }

    

    void UpdateCameraBodySize()
    {
        CinemachineFramingTransposer framingTransposer = virtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
        if (framingTransposer != null)
        {
            framingTransposer.m_ScreenY = currentBodySizeY;
        }
        else
        {
            Debug.LogWarning("CinemachineFramingTransposer component not found on Virtual Camera.");
        }
    }

    void UpdateLookAheadTime()
    {
        CinemachineFramingTransposer framingTransposer = virtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
        if (framingTransposer != null)
        {
            framingTransposer.m_LookaheadTime = currentLookaheadTime;
        }
        else
        {
            Debug.LogWarning("CinemachineFramingTransposer component not found on Virtual Camera.");
        }
    }

    void IncreaseOrthoGraphicSize()
    {
        virtualCamera.m_Lens.OrthographicSize = 5;
    }

    void ShakeCamera(float amplitude, float frequency)
    {
        CinemachineBasicMultiChannelPerlin noise = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        if (noise != null)
        {
            noise.m_AmplitudeGain = amplitude;
            noise.m_FrequencyGain = frequency;
        }
        else
        {
            Debug.LogWarning("CinemachineBasicMultiChannelPerlin component not found on Virtual Camera.");
        }
    }

}
