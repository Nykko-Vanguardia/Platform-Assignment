using UnityEngine;
using UnityEngine.InputSystem;

public class VFXShowcase : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem[] effects;
    [SerializeField]
    private Transform[] cameraSpots;
    [SerializeField]
    private Camera showcaseCamera;
    [SerializeField]
    private bool replayWhenDone = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (!replayWhenDone) return;

        for (int i = 0; i < effects.Length; i++)
            Play(i);
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.digit1Key.wasPressedThisFrame) Show(0);
        if (Keyboard.current.digit2Key.wasPressedThisFrame) Show(1);
        if (Keyboard.current.digit3Key.wasPressedThisFrame) Show(2);

        if (!replayWhenDone) return;

        for (int i = 0; i < effects.Length; i++) {
            if (!effects[i].IsAlive(true))
                Play(i);
        }
    }

    private void Show(int index) {
        showcaseCamera.transform.SetPositionAndRotation(cameraSpots[index].position, cameraSpots[index].rotation);
        Play(index);
    }

    private void Play(int index) {
        effects[index].Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        effects[index].Play(true);
    }
}
