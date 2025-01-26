using UnityEngine;

public class SkipScene : MonoBehaviour
{
    [SerializeField] private LoadScene loadScene;
    [SerializeField] private KeyCode skipKey = KeyCode.Space;
    void Update()
    {
        if(Input.GetKeyDown(skipKey))
        {
            loadScene.Load();
        }
    }
}
