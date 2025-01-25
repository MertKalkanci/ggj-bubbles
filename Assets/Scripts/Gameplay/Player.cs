using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private UnityEvent onPlayerDeath, onPlayerFinish;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private LayerMask nonPopLayerMask, endKeyLayerMask;
    
    public void OnCollisionEnter(Collision other)
    {
        if (!Misc.IsInLayerMask(other.gameObject.layer, nonPopLayerMask))
        {
            if(Misc.IsInLayerMask(other.gameObject.layer, endKeyLayerMask))
            {
                onPlayerFinish.Invoke();
                return;
            }
            float time = audioSource.clip.length;
            Console.WriteLine("on collision entered by player");
            audioSource.Play();
            meshRenderer.enabled = false;
            StartCoroutine(DisableAfterTime(time));
        }
    }
    private IEnumerator DisableAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        onPlayerDeath.Invoke();
    }

}
