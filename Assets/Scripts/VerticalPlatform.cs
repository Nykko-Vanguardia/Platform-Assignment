using UnityEngine;

public class VerticalPlatform : MovingPlatform
{

    [SerializeField]
    short direction = 1;
    short ogDirection;
    const float BOUND = 5;
    const float MOVSPEED = 7.5f;

    protected override void Start() {
        base.Start();
        ogDirection = direction;
    }

    public override void ResetPlatform()
    {
        base.ResetPlatform();
        direction = ogDirection;
    }

    // Update is called once per frame
    void Update()
    {
        if (stop) return;
        var pos = transform.position;
        if (pos.y >= BOUND || pos.y <= BOUND * -1) {
            direction *= -1;
        }

        transform.Translate(new Vector3(0, MOVSPEED * direction, 0) * Time.deltaTime);
    }
}
