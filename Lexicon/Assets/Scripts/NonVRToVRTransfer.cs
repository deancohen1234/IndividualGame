using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonVRToVRTransfer : MonoBehaviour {

    public Transform m_ObjectDestinationTransform;

    private PhysicsManager m_PhysicsManager;

	// Use this for initialization
	void Start ()
    {
        m_PhysicsManager = FindObjectOfType<PhysicsManager>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Pickupable"))
        {
            Debug.Log("Working");

            if (Input.GetKey(KeyCode.V))
            {
                //transfer object to VR space
                if (other.gameObject.GetComponent<Rigidbody>() != null)
                {
                    other.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                }
                m_PhysicsManager.UnlockGravityObjects(); //make sure gravity of world

                other.transform.position = m_ObjectDestinationTransform.position;
                other.transform.localScale *= 0.125f;

                for (int i = 0; i < other.transform.childCount; i++)
                {
                    Light l = other.transform.GetChild(i).gameObject.GetComponent<Light>();

                    if (l != null)
                    {
                        l.range *= 0.125f;
                    }
                }
            }
        }
    }
}
