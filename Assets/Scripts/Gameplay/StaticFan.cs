using UnityEngine;

public class StaticFan : MonoBehaviour
{
    [SerializeField] private Rigidbody playerRigidbody;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private float fanSpeed = 1f,fanArea = 3f;
    [SerializeField] private Transform fanTransformWithDirection;
    private RaycastHit raycastHit;

    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (Physics.SphereCast(fanTransformWithDirection.position, fanArea, fanTransformWithDirection.forward,out raycastHit))
        {
            if(Misc.IsInLayerMask(raycastHit.collider.gameObject.layer, playerLayer))
            {
                playerRigidbody.linearVelocity = Vector3.Lerp(playerRigidbody.linearVelocity, fanTransformWithDirection.forward * fanSpeed, Time.fixedDeltaTime);
            }
        }
    }
}
