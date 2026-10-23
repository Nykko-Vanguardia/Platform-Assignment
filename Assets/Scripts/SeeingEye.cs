using UnityEngine;

public class SeeingEye : MonoBehaviour
{
    [SerializeField]
    private float lightConeAngle = 15;
    [SerializeField]
    private float distance = 13f;
    [SerializeField]
    private float radius = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LayerMask tripWireLayer = LayerMask.GetMask("TripWire");
        RaycastHit[] hits = Physics.SphereCastAll(transform.position, radius, transform.forward, distance, tripWireLayer);

        foreach (RaycastHit hit in hits)
        {
            Vector3 hitPont = hit.point == Vector3.zero ? hit.collider.ClosestPoint(transform.position) : hit.point;
            Vector3 directionToObject = (hitPont - transform.position).normalized;

            float angletoObject = Vector3.Angle(transform.forward, directionToObject);

            if (angletoObject > lightConeAngle/2f) continue;

            TripWire tw = hit.transform.GetComponentInParent<TripWire>();
            if (tw != null) tw.Reveal();
        }
    }
}
