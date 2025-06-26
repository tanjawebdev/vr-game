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
        // 1) VR “X” button (primaryButton on left controller)
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(
            InputDeviceCharacteristics.Left |
            InputDeviceCharacteristics.Controller,
            devices);

        foreach (var dev in devices)
        {

            bool primaryPressed;
            if (dev.TryGetFeatureValue(CommonUsages.primaryButton, out primaryPressed)
                && primaryPressed)
            {
                Debug.Log("respawning now");
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