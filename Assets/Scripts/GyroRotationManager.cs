using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroRotationManager : MonoBehaviour {

    public enum Ring {XRing, YRing, ZRing}

    public Transform XRing; //inside
    public Transform YRing; //outside
    public Transform ZRing; //middle

    public float m_SpinSpeed = 2f;

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
