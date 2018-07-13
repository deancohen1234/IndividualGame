using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRInteractionManager : MonoBehaviour {

    private PhysicsManager m_PhysicsManager;
	// Use this for initialization
	void Start ()
    {
        m_PhysicsManager = GameObject.FindObjectOfType<PhysicsManager>();
	}
	
	// Update is called once per frame
	void Update () {
        InputManager();
	}

    private void InputManager()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            m_PhysicsManager.UnlockGravityObjects();
        }
        if (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) >= .95f)
        {
            m_PhysicsManager.UnlockGravityObjects();
        }
        if (Input.GetKeyDown(KeyCode.RightAlt))
        {
            m_PhysicsManager.LockGravityObjects();
        }
        if (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) >= .95f)
        {
            m_PhysicsManager.LockGravityObjects();
        }
    }
}
