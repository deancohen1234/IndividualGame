using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRToNonVRTransfer : MonoBehaviour {

    public Transform m_DestinationTransform;
    private PhysicsManager m_PhysicsManager;
	// Use this for initialization
	void Start () {
        m_PhysicsManager = FindObjectOfType<PhysicsManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Pickupable"))
        {
            if (OVRInput.GetDown(OVRInput.Button.PrimaryThumbstick))
            {
                //transfer object to VR space
                other.transform.position = m_DestinationTransform.position;
                other.transform.localScale *= 8f;

                m_PhysicsManager.LockGravityObjects();

                for(int i = 0; i < other.transform.childCount; i++)
                {
                    Light l = other.transform.GetChild(i).gameObject.GetComponent<Light>();

                    if (l != null)
                    {
                        l.range *= 8f;
                    }
                }
            }
        }
    }
}
