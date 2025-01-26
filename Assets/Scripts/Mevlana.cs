using UnityEngine;

public class Mevlana : MonoBehaviour
{
    [SerializeField] private Vector3 axis = Vector3.forward;
    [SerializeField] private float speed;
    void Update()
    {
        transform.Rotate(axis, speed * Time.deltaTime);
    }
}
