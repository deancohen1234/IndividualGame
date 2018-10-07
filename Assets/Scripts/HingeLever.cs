using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HingeLever : MonoBehaviour {

    public GyroRotationManager GRM;

    public GyroRotationManager.Ring m_RingType;

    public Transform m_Pivot;
    public float MaxRotationAmount = 40;

    public void SetLeverOrientation(Vector3 playerHandLocation)
    {
        //subtracting magic number to try and fix janky skip when at 0 degrees
        Vector3 difference = playerHandLocation - (m_Pivot.position - new Vector3(0, 0.5f, 0));

        float angle = -Vector3.SignedAngle(difference.normalized, Vector3.up, Vector3.right);
        //float angle = -AngleOverAxis(difference, Vector3.up, Vector3.right) * Mathf.Rad2Deg;
        //float angle = -Vector3.Angle(difference, Vector3.up);
        //Vector3 cross = Vector3.Cross(difference, Vector3.up);

        //if (cross.x < 0) angle = -angle;

        angle = Mathf.Clamp(angle, -MaxRotationAmount, MaxRotationAmount);

        Vector3 eulerRotation = new Vector3(angle, m_Pivot.eulerAngles.y, m_Pivot.eulerAngles.z);

        m_Pivot.rotation = Quaternion.Euler(eulerRotation);

        float normalizedRotationVal = Map(angle, -MaxRotationAmount, MaxRotationAmount, -1.0f, 1.0f);

        GRM.RotateLexiconRingByValue(m_RingType, normalizedRotationVal);
    }

    private float Map(float value, float startMin, float startMax, float endMin, float endMax)
    {
        float diff = (value - startMin) / (startMax - startMin);

        float newValue = (endMin * (1 - diff)) + (endMax * diff);

        return newValue;
    }

    private float AngleOverAxis(Vector3 from, Vector3 to, Vector3 axis)
    {
        //angle in radians
        float angle = Mathf.Acos(Vector3.Dot(from, to));
        Vector3 rv = Vector3.Cross(from, to).normalized * angle; // todo: zero cross?
        return Vector3.Dot(axis, rv);
    }

}
