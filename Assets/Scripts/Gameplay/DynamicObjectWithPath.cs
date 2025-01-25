using UnityEngine;

public class DynamicObjectWithPath : MonoBehaviour
{
    [SerializeField] private float pathPeriod;
    [SerializeField] private Transform position1,position2;
    [SerializeField] private Rigidbody rb;

    private void FixedUpdate()
    {
        float t = Mathf.Cos(Mathf.PI * (Time.time / pathPeriod)) / 2 + 0.5f;
        rb.MovePosition(Vector3.Lerp(position1.position, position2.position, t));
    }
}
