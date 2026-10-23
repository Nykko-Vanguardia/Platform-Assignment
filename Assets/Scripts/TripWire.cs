using UnityEngine;

public class TripWire : MonoBehaviour
{
    private Transform origin;
    private Transform laser;
    private bool reveal;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        origin = transform.Find("Origin");
        laser = transform.Find("Laser");
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(origin.position, origin.up, out hit, 20f))
        {
            if (hit.collider.CompareTag("Player"))
                hit.collider.GetComponent<Character>().kill("Hit tripwire, hint: LOOK AT GROUND!");
        }

        
    }

    void LateUpdate() {
        laser.GetComponent<MeshRenderer>().enabled = reveal;
        reveal = false;
    }

    public void Reveal() {
        reveal = true;
    }
}
