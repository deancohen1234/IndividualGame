using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsManager : MonoBehaviour {

    public Transform m_Lexicon;

    private List<Rigidbody> m_GravityAffectedRigidbodys;

    private bool m_GravityObjectsFree = false;
	// Use this for initialization
	void Awake ()
    {
        m_GravityAffectedRigidbodys = new List<Rigidbody>();
        GameObject[] gravityAffectedObjects = GameObject.FindGameObjectsWithTag("GravityAffectedObject");

        for (int i = 0; i < gravityAffectedObjects.Length; i++)
        {
            Rigidbody rb = gravityAffectedObjects[i].GetComponent<Rigidbody>();

            if (rb == null)
            {
                continue;
            }

            m_GravityAffectedRigidbodys.Add(rb);
            rb.gameObject.transform.parent = m_Lexicon; // so when the Lexicon is moving it can't whack the crap out of the objects
        }

        Debug.Log(m_GravityAffectedRigidbodys.Count);
	}
	
	void FixedUpdate () //for physics stuff
    {
        if (!m_GravityObjectsFree)
        {
            foreach (Rigidbody r in m_GravityAffectedRigidbodys)
            {
                Vector3 downVector = m_Lexicon.forward; //m_Lexicon.forward is the downward vector to the lexicon
                downVector *= -9.8f; //gravity modifier

                r.AddForce(downVector, ForceMode.Acceleration);
            }
        }     
	}

    public void UnlockGravityObjects() //means gravity objects are affected by th world gravity, not the lexicon's
    {
        foreach (Rigidbody r in m_GravityAffectedRigidbodys)
        {
            r.useGravity = true;
            m_GravityObjectsFree = true;
        }
    }

    public void LockGravityObjects() //means gravity objects are affected by the lexicon's gravity, not the world's
    {
        foreach (Rigidbody r in m_GravityAffectedRigidbodys)
        {
            r.useGravity = false;
            m_GravityObjectsFree = false;
        }
    }
}
