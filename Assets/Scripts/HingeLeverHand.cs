using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO remove the need for this script
//can only move one lever at a time
public class HingeLeverHand : MonoBehaviour {

    public OVRInput.Axis1D m_TriggerAxis;

    private HingeLever m_GrabbedHingeLever = null;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        float input = OVRInput.Get(m_TriggerAxis);

        if (m_GrabbedHingeLever != null)
        { 

            //if player lets go of button/lever, then release lever from grip
            if (input <= .5f)
            {
                m_GrabbedHingeLever = null;
                return;
            }

            //player is grabbing lever
            m_GrabbedHingeLever.SetLeverOrientation(transform.position);

        }
	}

    private void OnTriggerStay(Collider other)
    {
        //if we hit lever
        if (other.gameObject.GetComponent<HingeLever>())
        {
            if (m_GrabbedHingeLever == null)
            {
                m_GrabbedHingeLever = other.gameObject.GetComponent<HingeLever>();
            }
        }
    }
}
