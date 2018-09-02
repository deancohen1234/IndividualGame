using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRToNonVRTransfer : MonoBehaviour {

    public Transform m_DestinationTransform;
    private PhysicsManager m_PhysicsManager;
    private GameObject m_ObjectOnReceptacle;
	// Use this for initialization
	void Start () {
        m_PhysicsManager = FindObjectOfType<PhysicsManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay(Collider other)
    {
        m_ObjectOnReceptacle = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        m_ObjectOnReceptacle = null;
    }

    public void TryTransferObject()
    {
        if (m_ObjectOnReceptacle == null)
        {
            return;
        }

        if (m_ObjectOnReceptacle.layer == LayerMask.NameToLayer("Pickupable"))
        {
            //transfer object to VR space
            m_ObjectOnReceptacle.transform.position = m_DestinationTransform.position;
            m_ObjectOnReceptacle.transform.localScale *= 8f;

            m_PhysicsManager.LockGravityObjects();

            for (int i = 0; i < m_ObjectOnReceptacle.transform.childCount; i++)
            {
                Light l = m_ObjectOnReceptacle.transform.GetChild(i).gameObject.GetComponent<Light>();

                if (l != null)
                {
                    l.range *= 8f;
                }
            }
            
        }
    }
}
