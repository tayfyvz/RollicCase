using System;
using UnityEngine;

namespace TadPoleFramework
{
    public class PlatformController : Platform
    {
        public override void Awake()
        {
            base.Awake();
            meshRenderer = transform.GetChild(1).GetComponent<Renderer>();
            isInteractable = false;
        }
    }
}