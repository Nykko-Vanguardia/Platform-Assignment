using UnityEngine;

public class HorizontalPlatform : MovingPlatform
{
    [SerializeField]
    short direction = 1;
    short ogDirection;
    const float BOUND = 10;
    const float MOVSPEED = 7.5f;
    private Vector3 reset;

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
        if (pos.x >= BOUND || pos.x <= BOUND * -1) {
            direction *= -1;
        }

        transform.Translate(new Vector3(MOVSPEED * direction, 0, 0) * Time.deltaTime);
    }

}
