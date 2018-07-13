using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonVRInteractionManager : MonoBehaviour {

    [Header("Main Attributes")]
    public Camera m_NonVRCamera;
    public Animator m_CageAnimator;
    public Animator m_CircleCageAnimator;
    public Animator m_LeverAnimator;
    public float m_InteractDistance = 2f;

    [Header("Pickup Properties")]
    public float m_CarryDistance = 2f;
    public float m_ThrowStrength = 200f;
    public float m_LerpSpeedMultiplier = 3f;

    private bool m_IsCarryingObject;
    private GameObject m_CarriedObject;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1"))
        {
            TryInteract(); // sends out raycast to attempt to interact with anything
        }

        if (Input.GetButtonDown("Fire2"))
        {
            DropObject(); //attempts to drop an object if the player is carrying it
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            m_CircleCageAnimator.SetTrigger("OpenCircleCage");
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            m_CircleCageAnimator.SetTrigger("CycleCircleCage");
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            m_CircleCageAnimator.SetTrigger("CloseCircleCage");
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (m_IsCarryingObject) //if player is carrying object, lerp its position to be infront of the player by the specified carry distance
        {
            if (m_CarriedObject == null) //if for some reason the carried object becomes null, go through the drop object and bail out of function
            {
                DropObject();
                return;
            }

            Transform cot = m_CarriedObject.transform; //cot = carriedobject transform

            Vector3 desiredPos = m_NonVRCamera.transform.position + (m_NonVRCamera.transform.forward * m_CarryDistance); //make a desired position directly infront of player plus some distance away from their face
            Vector3 nextPos = Vector3.Lerp(cot.position, desiredPos, Time.deltaTime * m_LerpSpeedMultiplier); //get lerp vector through cot's current position, the desired position, and time * a speed multiplier

            cot.position = nextPos; //set new position
        }
	}

    private void TryInteract()
    {
        RaycastHit hit;
        Ray ray = new Ray(m_NonVRCamera.transform.position, m_NonVRCamera.transform.forward);  //shoot ray out of players's face

        if (Physics.Raycast(ray, out hit, m_InteractDistance))
        {
            LayerMask mask = hit.collider.gameObject.layer; //make reference to layer mask, for easier use in if statement
            if (mask == LayerMask.NameToLayer("Cage"))
            {
                OpenCage();
            }

            else if (mask == LayerMask.NameToLayer("Pickupable"))
            {
                PickupObject(hit.collider.gameObject); // go through pickup process
            }

            else if (mask == LayerMask.NameToLayer("Lever"))
            {
                m_LeverAnimator.SetTrigger("PullLever");
            }
        }
    }

    public void OpenCage()
    {
        m_CageAnimator.SetTrigger("LowerCage");      
    }

    private void PickupObject(GameObject obj)
    {
        Debug.Log("Picking Up Object");

        m_IsCarryingObject = true; // for lerping object around
        obj.GetComponent<Rigidbody>().isKinematic = true; // locks object in place so it won't fall

        m_CarriedObject = obj; //sets carried object so it can be lerped
    }

    public void DropObject()
    {
        Debug.Log("Dropping Object");

        m_IsCarryingObject = false; //sets false so carrying object function won't try and lerp it

        if (m_CarriedObject == null) //if we try and drop object, but there is no object to drop, bail out of function
        {
            return;
        }

        Rigidbody rb = m_CarriedObject.GetComponent<Rigidbody>();

        rb.isKinematic = false; // let gravity affect it
        rb.AddForce(m_NonVRCamera.transform.forward * m_ThrowStrength); //throw object after you drop it

        m_CarriedObject = null; // unset carried object

    }
}
