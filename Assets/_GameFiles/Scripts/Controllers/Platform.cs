using UnityEngine;

namespace TadPoleFramework
{
    public class Platform : MonoBehaviour
    {
        [HideInInspector]
        public Transform nextSpawnPoint;

        [HideInInspector] 
        public Renderer meshRenderer;

        public bool isInteractable; 

        public virtual void Awake()
        {
            nextSpawnPoint = transform.GetChild(0);
        }
    }
}