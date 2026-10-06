using UnityEngine;

public class Health : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name != "Player") return;

        CharacterMovement character = other.GetComponent<CharacterMovement>();
        character.heal();
        Destroy(transform.gameObject);
    }
}
