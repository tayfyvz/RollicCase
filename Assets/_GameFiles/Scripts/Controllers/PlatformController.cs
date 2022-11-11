using System;
using UnityEngine;

namespace TadPoleFramework
{
    public class PlatformController : MonoBehaviour
    {
        [HideInInspector]
        public Transform nextSpawnPoint;

        [HideInInspector] public Renderer meshRenderer;

        private void Awake()
        {
            nextSpawnPoint = transform.GetChild(0);
            meshRenderer = transform.GetChild(1).GetComponent<Renderer>();
        }
    }
}