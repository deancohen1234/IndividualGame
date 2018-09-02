using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO merge this with the snap to place script to make a circlecage class
public class NonVRToVRTransfer : MonoBehaviour {

    public Transform m_ObjectDestinationTransform;

    private PhysicsManager m_PhysicsManager;

    private GameObject m_ObjectToTransfer;

	// Use this for initialization
	void Start ()
    {
        m_PhysicsManager = FindObjectOfType<PhysicsManager>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Pickupable"))
        {
            //set object to transfer so lever can control it
            m_ObjectToTransfer = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //object has left plate so there is nothing to transfer
        if (m_ObjectToTransfer)
        {
            m_ObjectToTransfer = null;
        }
    }

    public void TransferObjectToVR()
    {
        if (m_ObjectToTransfer == null)
        {
            return;
        }

        if (m_ObjectToTransfer.gameObject.GetComponent<Rigidbody>() != null)
        {
            m_ObjectToTransfer.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }

        m_PhysicsManager.UnlockGravityObjects(); //make sure gravity of world

        m_ObjectToTransfer.transform.position = m_ObjectDestinationTransform.position;
        m_ObjectToTransfer.transform.localScale *= 0.125f;

        for (int i = 0; i < m_ObjectToTransfer.transform.childCount; i++)
        {
            Light l = m_ObjectToTransfer.transform.GetChild(i).gameObject.GetComponent<Light>();

            if (l != null)
            {
                l.range *= 0.125f;
            }
        }
    }

}
