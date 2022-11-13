using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace TadPoleFramework
{
    public class CollectorController : MonoBehaviour
    {
        public event Action OnSuccesEvent;
        
        [SerializeField] private Rigidbody myRb;
        [SerializeField] private float horiztontalSpeed = 10f;
        [SerializeField] private float verticalSpeed = 10f;
        private bool canMove = false;
        private bool canRun = false;
        private float horizontal;
        private Vector3 mousePosition;

        private void Awake()
        {
            myRb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            if (canMove)
            {
                //Horizontal Calc
                if (Input.GetMouseButtonDown(0))
                {
                    mousePosition = Input.mousePosition;
                }
                else if (Input.GetMouseButton(0))
                {

                    horizontal = (Input.mousePosition.x - mousePosition.x) / Screen.width * 2.5f;
                    mousePosition = Input.mousePosition;
                }
                else
                {
                    horizontal = 0;
                }   
            }
        }
        private void FixedUpdate()
        {
            if (canMove)
            {
                //Vertical Calc
                float verticalActualSpeed = (verticalSpeed * Time.fixedDeltaTime);
                if (!canRun)
                {
                    verticalActualSpeed = 0f;
                }

                //applying speeds to transform
                myRb.MovePosition(new Vector3(Mathf.Clamp(transform.position.x + (horizontal * horiztontalSpeed * Time.fixedDeltaTime), -2.5f, 2.5f),
                    transform.position.y, transform.position.z + verticalActualSpeed));
            }
        }
        public void EnableMovement()
        {
            canMove = true;
            canRun = true;
        }
        public void DisableMovement()
        {
            canMove = false;
            canRun = false;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Gate"))
            {
                other.gameObject.tag = "Untagged";
                DisableMovement();
                StartCoroutine(WaitForGateControl(other));
            }
            else if (other.gameObject.CompareTag("LevelEnd"))
            {
                other.gameObject.tag = "Untagged";
                DisableMovement();
                transform.DOMove(new Vector3(0, transform.position.y, transform.position.z + 13), 1.5f).SetEase(Ease.Linear).OnComplete((
                    () =>
                    {
                        OnSuccesEvent?.Invoke();
                    }));
            }
        }

        IEnumerator WaitForGateControl(Collider gate)
        {
            yield return new WaitForSeconds(2f);
            gate.GetComponentInParent<GateController>().CheckLevelStatus();
        }
    }
}
