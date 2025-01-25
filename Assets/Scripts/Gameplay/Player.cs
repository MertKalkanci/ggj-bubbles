using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private LayerMask nonPopLayerMask;
    
    public void OnCollisionEnter(Collision other)
    {
        if (!Misc.IsInLayerMask(other.gameObject.layer, nonPopLayerMask))
        {
            Console.WriteLine("on collision entered by player");
            gameObject.SetActive(false);
        }
    }
    
}
