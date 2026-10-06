using UnityEngine.InputSystem;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    float horizontal, vertical;
    [SerializeField]
    CharacterController characterController;
    [SerializeField]
    Camera camera;
    float y;
    const float gravity = -20f;
    const float jumpHeight = 1f;
    private byte health = 3;
    Vector3 reset;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        reset = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Keyboard.current.dKey.isPressed ? 1f : (Keyboard.current.aKey.isPressed ? -1f : 0f);
        float vertical = Keyboard.current.wKey.isPressed ? 1f : (Keyboard.current.sKey.isPressed ? -1f : 0f);

        if (characterController.isGrounded && y < 0) y = -2f;
        if (characterController.isGrounded && Keyboard.current.spaceKey.wasPressedThisFrame)
            y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        y += gravity * Time.deltaTime;

        if (transform.position.y <= -5f)
            kill();

        characterController.Move(new Vector3(horizontal, y, vertical) * 5 * Time.deltaTime);
        Vector3 pos = transform.position;
        camera.transform.position = new Vector3(pos.x, pos.y + 5, pos.z - 10);
    }

    public void takeDamage() {
        health -= 1;
        if (health == 0) {
            kill();
        }
        Debug.Log("Took damage! Current health: " + health);
    }

    public void heal() {
        health += 1;
        Debug.Log("Gained Health! Current health: " + health);
    }

    public void kill() {
        characterController.enabled = false;
        transform.position = reset;
        health = 3;
        characterController.enabled = true;
    }
}
