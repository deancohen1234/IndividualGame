using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroGrabber : MonoBehaviour {

    public float m_RotationSpeed = 30f;

    private GameObject m_MovingRing;

    private void Update()
    {
        if (m_MovingRing == null) return;

        if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger))
        {
            float speedModifier = (float)OVRInput.Axis1D.PrimaryHandTrigger;
            if (m_MovingRing.name == "ZAxis_Ring")
            {
                /*angle = CalculateAngle(m_MovingRing.transform.position, transform.position, Vector3.up);
                m_MovingRing.transform.eulerAngles = new Vector3(m_MovingRing.transform.eulerAngles.x, -angle + 90, m_MovingRing.transform.eulerAngles.z);*/

                m_MovingRing.transform.Rotate(new Vector3(0, m_RotationSpeed * Time.deltaTime * speedModifier, 0));
            }
            else if(m_MovingRing.name == "YAxisRing")
            {
                /*angle = CalculateAngle(m_MovingRing.transform.position, transform.position, Vector3.forward);
                m_MovingRing.transform.rotation = Quaternion.Euler(new Vector3(angle, m_MovingRing.transform.eulerAngles.y, m_MovingRing.transform.eulerAngles.z));*/

                m_MovingRing.transform.Rotate(new Vector3(m_RotationSpeed * Time.deltaTime * speedModifier, 0, 0));
            }
            else
            {
                /*angle = CalculateAngle(m_MovingRing.transform.position, transform.position, Vector3.right);
                m_MovingRing.transform.eulerAngles = new Vector3(m_MovingRing.transform.eulerAngles.x, -angle + 90, m_MovingRing.transform.eulerAngles.z);*/

                m_MovingRing.transform.Rotate(new Vector3(0, m_RotationSpeed * Time.deltaTime * speedModifier, 0));
            }  
        }

        else if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
        {
            float speedModifier = (float)OVRInput.Axis1D.PrimaryIndexTrigger;
            if (m_MovingRing.name == "ZAxis_Ring")
            {
                /*angle = CalculateAngle(m_MovingRing.transform.position, transform.position, Vector3.up);
                m_MovingRing.transform.eulerAngles = new Vector3(m_MovingRing.transform.eulerAngles.x, -angle + 90, m_MovingRing.transform.eulerAngles.z);*/

                m_MovingRing.transform.Rotate(new Vector3(0, -m_RotationSpeed * Time.deltaTime * speedModifier, 0));
            }
            else if (m_MovingRing.name == "YAxisRing")
            {
                /*angle = CalculateAngle(m_MovingRing.transform.position, transform.position, Vector3.forward);
                m_MovingRing.transform.rotation = Quaternion.Euler(new Vector3(angle, m_MovingRing.transform.eulerAngles.y, m_MovingRing.transform.eulerAngles.z));*/

                m_MovingRing.transform.Rotate(new Vector3(-m_RotationSpeed * Time.deltaTime * speedModifier, 0, 0));
            }
            else
            {
                /*angle = CalculateAngle(m_MovingRing.transform.position, transform.position, Vector3.right);
                m_MovingRing.transform.eulerAngles = new Vector3(m_MovingRing.transform.eulerAngles.x, -angle + 90, m_MovingRing.transform.eulerAngles.z);*/

                m_MovingRing.transform.Rotate(new Vector3(0, -m_RotationSpeed * Time.deltaTime * speedModifier, 0));
            }
        }
    }
    // Use this for initialization
    private void OnTriggerStay(Collider other)
    {
        GameObject g = other.gameObject;

        if (g.tag == "GyroCircle")
        {
            /*Debug.Log(Vector3.Angle(transform.position, g.transform.position) * Mathf.Rad2Deg);

            if (OVRInput.Get(OVRInput.Button.Any))
            {
                g.transform.eulerAngles = new Vector3(g.transform.eulerAngles.x, Vector3.Angle(transform.position, g.transform.position) * Mathf.Rad2Deg, g.transform.eulerAngles.z);
            }*/
            m_MovingRing = g;
        }
    }

    private float CalculateAngle(Vector3 from, Vector3 to, Vector3 referenceAngle)
    {
        return Quaternion.FromToRotation(referenceAngle, to - from).eulerAngles.z;
    }
}
