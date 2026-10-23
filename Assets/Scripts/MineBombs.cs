using UnityEngine;

public class MineBombs : MonoBehaviour
{
    [SerializeField]
    private Character player;
    [SerializeField]
    private float moveSpeed = 5f;
    [SerializeField]
    private float moveDistance = 15f;
    private float radius;
    private int direction;
    private Vector3 startPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        radius = GetComponent<SphereCollider>().radius;
        direction = Random.Range(0, 2) >= 0.5 ? 1 : -1;
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        float shift = Mathf.PingPong(Time.time * moveSpeed, moveDistance) - (moveDistance / 2f);
        Vector3 targetPosition = startPosition + (transform.right * shift * direction);
        transform.position = targetPosition;

        LayerMask playerLayer = LayerMask.GetMask("Player");
        bool isPlayerClose = Physics.CheckSphere(transform.position, radius * 1.1f, playerLayer);

        if (isPlayerClose) {
            player.kill("Died from mine!");
            Destroy(this.gameObject);
        }
    }
}
