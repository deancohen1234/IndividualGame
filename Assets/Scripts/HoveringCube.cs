using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoveringCube : MonoBehaviour {

    public float m_Frequency = 1.0f;
    public float m_Amplitude = 1.0f;

    private Vector3 m_StartingPosition;
    private float m_TimeOffset = 0;
	// Use this for initialization
	void Start ()
    {
        m_StartingPosition = transform.position;

        m_TimeOffset = Random.Range(-2.0f, 2.0f);
	}
	
	// Update is called once per frame
	void Update ()
    {
        float yVal = Mathf.Sin((Time.time + m_TimeOffset) * m_Frequency) * m_Amplitude;

        transform.position = new Vector3(m_StartingPosition.x, m_StartingPosition.y + yVal, m_StartingPosition.z);
	}
}
