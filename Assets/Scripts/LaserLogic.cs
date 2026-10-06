using UnityEngine;

public class LaserLogic : MonoBehaviour
{
    private float movementSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        movementSpeed = UnityEngine.Random.Range(10, 20);
        float rotation = UnityEngine.Random.Range(-10, 10);
        transform.Rotate(Vector3.forward, rotation);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, 0, -1 * movementSpeed * Time.deltaTime));
        if (transform.position.z <= 10)
            Destroy(transform.gameObject);
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.name != "Player") return;

        CharacterMovement character = other.GetComponent<CharacterMovement>();
        character.takeDamage();
    }
}
