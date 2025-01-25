using UnityEngine;

public class LoadScene : MonoBehaviour
{
    [SerializeField] private string sceneName;
    public void Load()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}
