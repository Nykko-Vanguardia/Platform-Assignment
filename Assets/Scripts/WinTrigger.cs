using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject winPannel;

    void Start()
    {
        winPannel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.name != "Player") return;

        winPannel.SetActive(true);
        CharacterMovement character = other.GetComponent<CharacterMovement>();
        character.kill();
    }
}
