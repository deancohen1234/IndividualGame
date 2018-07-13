using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapToPlace : MonoBehaviour {

    public Transform m_SnapTransform;
    // Use this for initialization
    private void OnTriggerEnter(Collider other)
    {
        NonVRInteractionManager m = GameObject.FindObjectOfType<NonVRInteractionManager>();
        m.DropObject();

        other.transform.position = m_SnapTransform.position;
        other.transform.rotation = m_SnapTransform.rotation;

        Rigidbody r = other.gameObject.GetComponent<Rigidbody>();

        if (r != null)
        {
            r.isKinematic = true;
            //r.isKinematic = false;
        }
    }
}
