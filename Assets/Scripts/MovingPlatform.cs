using UnityEngine;
public class MovingPlatform : MonoBehaviour {
    protected bool stop = false;
    protected Quaternion resetRotation;
    protected Vector3 resetPosition;

    protected virtual void Start() {
        resetPosition = transform.position;
        resetRotation = transform.rotation;
    }

    public virtual void Stop() {
        stop = true;
    }

    public virtual void ResetPlatform() {
        transform.position = resetPosition;
        transform.rotation = resetRotation;
        stop = false;
    }
}
