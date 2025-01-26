using UnityEngine;

public class Music : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    private static Music instance;
    void Start()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        audioSource.Play();
    }
}
