using UnityEngine;

public class Character : MonoBehaviour
{
    private byte health = 3;
    Vector3 reset;
    private CharacterController cc;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cc = GetComponent<CharacterController>();
        reset = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage() {
        health -= 1;
        Debug.Log("Took damage! Current health: " + health);

        if (health == 0) {
            kill("Died from 0 health");
        }
    }

    public void heal() {
        health += 1;
        Debug.Log("Gained Health! Current health: " + health);
    }

    public void kill(string reason) {
        cc.enabled = false;
        transform.position = reset;
        cc.enabled = true;
        health = 3;
        Debug.Log(reason);
    }
}
