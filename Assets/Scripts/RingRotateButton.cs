using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingRotateButton : MonoBehaviour {

    public GyroRotationManager m_GRM;
    public GyroRotationManager.Ring m_RingType;
    public float m_Negative = 1;

    // Use this for initialization
    private void OnTriggerStay(Collider other)
    {
        m_GRM.RotateLexiconRing(m_RingType, m_Negative);
    }
}
