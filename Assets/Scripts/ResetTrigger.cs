using UnityEngine;
using UnityEngine.InputSystem;

public class ResetTrigger : MonoBehaviour
{
    [SerializeField]
    Trigger trigger;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.rKey.wasPressedThisFrame)
            trigger.ResetAll();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.name != "Player") return;
        trigger.ResetAll();
    }
}
