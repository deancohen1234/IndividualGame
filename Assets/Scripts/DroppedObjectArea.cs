using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedObjectArea : MonoBehaviour {

    public Transform m_ReturnTransform;

    private void OnTriggerEnter(Collider other)
    {
        //if an object is pickupable and falls, send it back to workbench
        if (other.gameObject.GetComponent<OVRGrabbable>())
        {
            other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            other.transform.position = m_ReturnTransform.position;
        }
    }
}
