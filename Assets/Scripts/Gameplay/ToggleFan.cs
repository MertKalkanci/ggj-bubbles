using UnityEngine;

public class ToggleFan : MonoBehaviour
{
    [SerializeField] private StaticFan fanBehaviour;
    public void EnableFan()
    {
        fanBehaviour.enabled = true;
    }
    public void DisableFan()
    {
        fanBehaviour.enabled = false;
    }
}
