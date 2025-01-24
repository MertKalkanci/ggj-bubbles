using UnityEngine;

public class Misc
{
    public static bool IsInLayerMask(int layer, LayerMask mask) => (mask.value & (1 << layer)) != 0;
    public static void ToggleGameobjetActiveness(GameObject gameObject)
    {
        if (gameObject == null)
        {
            Debug.LogWarning("GameObject that tried to toggle is null!");
            return;
        }
        gameObject.SetActive(!gameObject.activeSelf);
    }
}