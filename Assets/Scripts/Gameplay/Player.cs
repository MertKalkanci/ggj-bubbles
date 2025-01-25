using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int PopLayerIndex;
    private int NonPopLayerIndex;
    
    void Awake()
    {
        NonPopLayerIndex = LayerMask.NameToLayer("NonPop");
    }
    
    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer != NonPopLayerIndex)
        {
            Console.WriteLine("on collision entered by player");
            gameObject.SetActive(false);
        }
    }
    
}
