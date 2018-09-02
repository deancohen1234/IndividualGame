using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroRotationManager : MonoBehaviour {

    public enum Ring {XRing, YRing, ZRing}

    public Transform XRing; //inside
    public Transform YRing; //outside
    public Transform ZRing; //middle

    public Transform m_LexiconTransform;

    public float m_SpinSpeed = 2f;

    private Vector3 m_RotationVector;
    // Use this for initialization
    void Start ()
    {
        m_RotationVector = Vector3.zero;
        m_LexiconTransform.eulerAngles = m_RotationVector;
	}
	
	// Update is called once per frame
	void Update ()
    {
   
		/*if (Input.GetKey(KeyCode.A))
        {
            YRing.Rotate(new Vector3(0, 2f, 0));
        }
        if (Input.GetKey(KeyCode.S))
        {
            ZRing.Rotate(new Vector3(2f, 0, 0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            XRing.Rotate(new Vector3(0, 2f, 0));
        }

        Quaternion q = XRing.rotation;
        //q *= ZRing.rotation;
        //q *= XRing.rotation;
        m_LexiconTransform.rotation = q;*/

    }

    //value for rotation will be normalized (-1, 1)
    public void RotateLexiconRing(Ring r, float neg)
    {
        if (r == Ring.XRing)
        {
            XRing.Rotate(new Vector3(0, 2f * neg, 0));
        }
        else if (r == Ring.YRing)
        {
            YRing.Rotate(new Vector3(0, 2f * neg, 0));
        }
        else if  (r == Ring.ZRing)
        {
            ZRing.Rotate(new Vector3(2f * neg, 0, 0));
        }
    }

    public void RotateLexiconRingByValue(Ring r, float val)
    {
        if (r == Ring.XRing)
        {
            XRing.Rotate(new Vector3(0, val * m_SpinSpeed, 0));
        }
        else if (r == Ring.YRing)
        {
            YRing.Rotate(new Vector3(0, val * m_SpinSpeed, 0));
        }
        else if (r == Ring.ZRing)
        {
            ZRing.Rotate(new Vector3(val * m_SpinSpeed, 0, 0));
        }
    }
}
