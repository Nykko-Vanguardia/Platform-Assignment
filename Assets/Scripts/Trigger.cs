using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class Trigger : MonoBehaviour
{
    [SerializeField]
    private GameObject platformParent;
    private List<MovingPlatform> platforms = new List<MovingPlatform>();
    private ushort count = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (Transform platform in platformParent.transform) {
            MovingPlatform movingPlatform = platform.GetComponent<MovingPlatform>();
            if (movingPlatform == null)
                continue;

            platforms.Add(movingPlatform);
        }

    }

    // Update is called once per frame
    void Update() 
    {
        if (Keyboard.current.qKey.wasPressedThisFrame)
            Press();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.name != "Player") return;
        Press();
    }

    private void Press() {
        if (count == platforms.Count) {
            ResetAll();
            return;
        }

        platforms[count].Stop();
        count += 1;

    }

    public void ResetAll() {
        foreach(MovingPlatform platform in platforms) {
            platform.ResetPlatform();
        }

        count = 0;
    }
}
