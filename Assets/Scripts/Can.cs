using UnityEngine;

public class Can : MonoBehaviour
{
    [SerializeField]
    private float fallThresholdAngle = 45f;

    [SerializeField]
    private bool Moves = false;
    [SerializeField]
    private float moveDistance = 20f;
    [SerializeField]
    private float moveSpeed = 3f;
    [SerializeField]
    private float direction = 1;

    private Vector3 startPosition;
    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate() {
        if (IsKnockedOver()) Moves = false;
        if (!Moves) return;

        float shift = Mathf.PingPong(Time.time * moveSpeed, moveDistance) - (moveDistance / 2f);
        Vector3 targetPosition = startPosition + (transform.right * shift * direction);

        rb.MovePosition(targetPosition);
    }

    public bool IsKnockedOver() {
        float currentTiltAngle = Vector3.Angle(transform.up, Vector3.up);

        if (currentTiltAngle > fallThresholdAngle)
            return true;
        else
            return false;
    }

    void OnCollisionEnter(Collision other) {
        if (!Moves) return;
        if (other.gameObject.GetComponent<Bullet>() == null) return;

        Moves = false;
    }
}
