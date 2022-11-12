using System;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace TadPoleFramework
{
    public class GateController : Platform
    {
        public event Action OnCollectorEnterEvent;
        [SerializeField] private int goal;
        [SerializeField] private int counter;

        [SerializeField] private TextMeshProUGUI goalCounterText;

        [SerializeField] private GameObject road;
        public override void Awake()
        {
            base.Awake();
            isInteractable = true;
            meshRenderer = road.GetComponent<Renderer>();
        }

        public void IncreaseCounter()
        {
            counter++;
            goalCounterText.text = counter + " / " + goal;
        }

        public void ContinueLevel()
        {
            road.SetActive(true);
            road.transform.DOMoveY(0, .3f).SetEase(Ease.Linear).OnComplete(() =>
            {
                road.GetComponent<BoxCollider>().isTrigger = false;
            });
        }
    }
}