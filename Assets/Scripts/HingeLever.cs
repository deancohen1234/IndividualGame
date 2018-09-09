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
        Vector3 difference = playerHandLocation - m_Pivot.position;
        //using Vector3.up because transform.up is rotated
        //float angle = -Vector3.SignedAngle(difference, Vector3.up, Vector3.right);
        float angle = -Vector3.Angle(difference, Vector3.up);
        Vector3 cross = Vector3.Cross(difference, Vector3.up);

        if (cross.x < 0) angle = -angle;

        Debug.Log(cross); 
        //angle += 90;

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

}
