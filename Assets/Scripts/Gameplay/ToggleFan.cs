using UnityEngine;

public class ToggleFan : MonoBehaviour
{
    [SerializeField] private GameObject water;
    [SerializeField] private StaticFan fanBehaviour;
    public void EnableFan()
    {
        fanBehaviour.enabled = true;
        water.SetActive(true);
    }
    public void DisableFan()
    {
        fanBehaviour.enabled = false;
        water.SetActive(false);
    }
}
