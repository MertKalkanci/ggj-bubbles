using UnityEngine;

public class ToggleFan : MonoBehaviour
{
    [SerializeField] private StaticFan fanBehaviour;
    public void Toggle()
    {
        fanBehaviour.enabled = !fanBehaviour.enabled;
    }
}
