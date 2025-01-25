using UnityEngine;

public class Mevlana : MonoBehaviour
{
    [SerializeField] private float speed;
    void Update()
    {
        transform.Rotate(Vector3.forward, speed * Time.deltaTime);
    }
}
