using UnityEngine;

public class RotationPlatform : MovingPlatform
{
    private float rotSpeed;

    protected override void Start()
    {
        base.Start();
        rotSpeed = Random.Range(40, 55);
    }

    // Update is called once per frame
    void Update()
    {
        if (stop) return;
        transform.Rotate(Vector3.up * rotSpeed * Time.deltaTime);
    }
}
