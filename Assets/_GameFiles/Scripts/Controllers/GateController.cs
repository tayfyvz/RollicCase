using System;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace TadPoleFramework
{
    public class GateController : Platform
    {
        public event Action OnContinueLevelEvent;
        public event Action OnFailLevelEvent;

        [SerializeField] private int counter;

        [SerializeField] private TextMeshProUGUI goalCounterText;

        [SerializeField] private Animator animator;
        
        [SerializeField] private GameObject road;
        private int _collectLimit;
        public override void Awake()
        {
            base.Awake();
            isInteractable = true;
            
        }
        public void SetCollectLimit(int newLimit)
        {
            _collectLimit = newLimit;
        }
        public void SetUpperCubeColor(Color newColor)
        {
            road.GetComponent<Renderer>().sharedMaterial.color = newColor;

        }
        public void SetPosition(float lengthOfRoad)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y,
                ((lengthOfRoad) * 5f));
        }
        public void SetCounter()
        {
            goalCounterText.text = counter + " / " + _collectLimit;
        }
        public void IncreaseCounter()
        {
            counter++;
            goalCounterText.text = counter + " / " + _collectLimit;
        }

        public void CheckLevelStatus()
        {
            if (counter >= _collectLimit)
            {
                ContinueLevel();
            }
            else
            {
                OnFailLevelEvent?.Invoke();
            }
        }
        private void ContinueLevel()
        {
            road.SetActive(true);
            animator.SetTrigger("OpenGate");
            road.transform.DOMoveY(0, .3f).SetEase(Ease.OutBounce).OnComplete(() =>
            {
                road.GetComponent<BoxCollider>().isTrigger = false;
                OnContinueLevelEvent?.Invoke();
            });
        }
    }
}