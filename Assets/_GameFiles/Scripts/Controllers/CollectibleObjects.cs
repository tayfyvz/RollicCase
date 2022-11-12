using System;
using System.Collections.Generic;
using Lean.Common;
using UnityEngine;

namespace TadPoleFramework
{
    public class CollectibleObjects : MonoBehaviour
    {
        // private List<float> _angleList = new List<float>
        // {
        //     0,
        //     -30,
        //     30,
        //     -60,
        //     60
        // };
        //
        // private void FixedUpdate()
        // {
        //
        //     for (int i = 0; i < _angleList.Count; i++)
        //     {
        //         bool isHitted = CloseDistRaycast(_angleList[i]);
        //         if (isHitted)
        //         {
        //             Debug.Log("Entered");
        //             gameObject.AddComponent<Rigidbody>();
        //             gameObject.GetComponent<Rigidbody>().collisionDetectionMode =
        //                 CollisionDetectionMode.ContinuousDynamic;
        //             gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
        //
        //             _angleList.Clear();
        //             Destroy(this);
        //             break;
        //         }
        //     }
        // }
        //
        // bool CloseDistRaycast(float angle)
        // {
        //     RaycastHit target = AlwaysRayLauncher(angle);
        //     if (target.transform != null)
        //     {
        //         return true;
        //     }
        //
        //     return false;
        // }
        //
        // private RaycastHit AlwaysRayLauncher(float angle)
        // {
        //     RaycastHit hit;
        //     var direction = Quaternion.AngleAxis(angle, transform.up) * transform.forward;
        //     Debug.DrawRay(transform.position, direction, Color.red, 5);
        //
        //     // if (Physics.Raycast(transform.position, Vector3.back, out hit, .7f, 1 << 9 | 1 << 10))
        //     if (Physics.Raycast(transform.position, direction, out hit, .4f, 1 << 8))
        //     {
        //         GetComponent<LeanConstrainToCollider>().enabled = true;
        //         GetComponent<LeanConstrainToCollider>().Collider = hit.collider;
        //         return hit;
        //     }
        //     else
        //         return hit;
        // }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("BallCounter"))
            {
                other.GetComponentInParent<GateController>().IncreaseCounter();
            }
        }
    }
}