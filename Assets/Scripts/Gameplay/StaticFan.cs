using UnityEngine;

public class StaticFan : MonoBehaviour
{
    [SerializeField] private string playerTag = "Player";
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private float fanSpeed = 1f,fanArea = 3f;
    [SerializeField] private Transform fanTransformWithDirection;
    private RaycastHit raycastHit;
    private Rigidbody playerRigidbody;

    void Start()
    {
        if(playerRigidbody == null)
        {
            playerRigidbody = GameObject.FindGameObjectWithTag(playerTag).GetComponent<Rigidbody>();
        }
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
