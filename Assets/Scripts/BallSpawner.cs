using UnityEngine;
using UnityEngine.XR;
using System.Collections.Generic;

public class BallSpawner : MonoBehaviour
{
    public GameObject ballPrefab;

    private Vector3 spawnPos;
    private Quaternion spawnRot;

    private GameObject currentBall; // holds the last spawned ball

    void Start()
    {
        spawnPos = transform.position;
        spawnRot = transform.rotation;
    }

    void Update()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(
            InputDeviceCharacteristics.Left | InputDeviceCharacteristics.Controller,
            devices);

        foreach (var dev in devices)
        {
            bool primaryPressed;
            if (dev.TryGetFeatureValue(CommonUsages.primaryButton, out primaryPressed)
                && primaryPressed)
            {
                SpawnBall();
                return;
            }
        }
    }

    private void SpawnBall()
    {
        if (currentBall != null)
        {
            Destroy(currentBall);
        }

        currentBall = Instantiate(ballPrefab, spawnPos, spawnRot);
    }
}
