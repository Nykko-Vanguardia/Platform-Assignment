using UnityEngine;
using StarterAssets;

public class Bullet : MonoBehaviour
{
    private const float bulletSpeed = 40f;
    private const float bulletLifeTime = 5f;

    private long spawnTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }


    // Update is called once per frame
    void Update()
    {

    }

    public void Fire(Vector3 forward, Vector3 startingPosition, FirstPersonController activePlayer) {
        transform.position = startingPosition;
        transform.gameObject.GetComponent<Rigidbody>().linearVelocity = forward * bulletSpeed;

        Collider collider = transform.gameObject.GetComponent<Collider>();

        foreach (Collider c in activePlayer.GetComponentsInChildren<Collider>())
            Physics.IgnoreCollision(collider, c);

        Destroy(transform.gameObject, bulletLifeTime);
    }
}
