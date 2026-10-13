using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets;

public class ShooterMode : MonoBehaviour
{
    [SerializeField]
    private byte shooterNumber = 1;
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private GameObject cansParent;

    private bool isActive = false;
    private float ogMoveSpeed;
    private float ogSprintSpeed;
    private float ogJumpHeight;

    private FirstPersonController activePlayer;
    private Camera camera;


    private bool hasWon = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!isActive) return;

        if (Keyboard.current.fKey.wasPressedThisFrame)
            Exit();

        if (Mouse.current.leftButton.wasPressedThisFrame)
            Shoot();

        foreach (Can can in cansParent.GetComponentsInChildren<Can>()) {
            if (!can.IsKnockedOver())
                return;
        }

        hasWon = true;
        Exit();
        Debug.Log("YOU BEAT SHOOTER" + shooterNumber);
        Destroy(transform.gameObject);
    }

    private void Shoot() {
        Bullet bulletInstance = Instantiate(bullet, camera.transform.position, camera.transform.rotation).GetComponent<Bullet>();
        bulletInstance.Fire(camera.transform.forward, camera.transform.position, activePlayer);
        
    }

    private void OnTriggerEnter(Collider other) {
        if (hasWon) return;
        if (other.name != "Capsule") return;

        FirstPersonController player = other.transform.parent.GetComponent<FirstPersonController>();
        ogMoveSpeed = player.MoveSpeed;
        ogSprintSpeed = player.SprintSpeed;
        ogJumpHeight = player.JumpHeight;

        player.MoveSpeed = 0;
        player.SprintSpeed = 0;
        player.JumpHeight = 0;
        activePlayer = player;
        camera = other.transform.parent.parent.Find("MainCamera").GetComponent<Camera>();

        isActive = true;
    }

    private void Exit() {
        activePlayer.MoveSpeed = ogMoveSpeed;
        activePlayer.SprintSpeed = ogSprintSpeed;
        activePlayer.JumpHeight = ogJumpHeight;
        activePlayer = null;

        isActive = false;
    }
}
