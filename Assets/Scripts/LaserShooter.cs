using System;
using UnityEngine;

public class LaserShooter : MonoBehaviour
{
    [SerializeField]
    private GameObject laser;
    private byte nextShot;
    private long lastShot;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nextShot = (byte)UnityEngine.Random.Range(1, 3);
        lastShot = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        Fire();
    }

    // Update is called once per frame
    void Update()
    {
        long now = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        if (now - lastShot <= nextShot) return;
        lastShot = now;
        nextShot = (byte)UnityEngine.Random.Range(1, 3);
        Fire();
    }

    private void Fire()
    {
        Vector3 spawnPosition = new Vector3(-0.36f, 3.22f, 121.53f);
        Quaternion spawnRotation = Quaternion.Euler(0f, 0f, -90f);
        Instantiate(laser, spawnPosition, spawnRotation);
    }
}
