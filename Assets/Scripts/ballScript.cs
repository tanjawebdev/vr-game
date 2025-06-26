using UnityEngine;
using UnityEngine.XR;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody))]
public class ballScript : MonoBehaviour
{
    [Tooltip("Drag your Ball prefab here")]
    public GameObject ballPrefab;

    private Vector3 _spawnPos;
    private Quaternion _spawnRot;

    void Awake()
    {
        _spawnPos = transform.position;
        _spawnRot = transform.rotation;
    }

    void Update()
    {
        // 1) VR “A” button (primaryButton on right controller)
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(
            InputDeviceCharacteristics.Right |
            InputDeviceCharacteristics.Controller,
            devices);

        foreach (var dev in devices)
        {
            bool primaryPressed;
            if (dev.TryGetFeatureValue(CommonUsages.primaryButton, out primaryPressed)
                && primaryPressed)
            {
                Respawn();
                return;
            }
        }
    }

    private void Respawn()
    {
        if (ballPrefab != null)
            Instantiate(ballPrefab, _spawnPos, _spawnRot);

        Destroy(gameObject);
    }
}