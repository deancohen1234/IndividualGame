using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//TODO add more complexity to this, like animations and sound
[RequireComponent(typeof(AudioSource))]
public class MechanicalButton : MonoBehaviour {

    public UnityEvent OnButtonPressed;
    public UnityEvent OnButtonReset;
    public float m_WaitTime;
    public float m_AmountDepressed = .5f;
    public float m_ButtonMoveSpeed = 1f;

    private Vector3 m_StartingPosition;
    private Vector3 m_EndingPosition;
    private float m_StartPressTime;
    private bool m_IsPressed = false;

    private void Start()
    {
        m_StartingPosition = transform.position;
        m_EndingPosition = new Vector3(m_StartingPosition.x, m_StartingPosition.y - m_AmountDepressed, m_StartingPosition.z);
    }

    private void Update()
    {
        if (m_IsPressed)
        {
            float time = Mathf.PingPong((Time.time - m_StartPressTime) * m_ButtonMoveSpeed, 1);

            Vector3 desiredPos = Vector3.Lerp(m_StartingPosition, m_EndingPosition, time);

            transform.position = desiredPos;

            //this is where problem of ending is
            if ((Time.time - m_StartPressTime) * m_ButtonMoveSpeed >= 2) //if we have gone through one cycle of the pingpong
            {
                m_IsPressed = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (m_IsPressed)
        {
            return;
        }

        OnButtonPressed.Invoke();
        StartCoroutine(WaitForButtonReset());

        GetComponent<AudioSource>().Play();

        m_IsPressed = true;
        m_StartPressTime = Time.time;
    }

    private IEnumerator WaitForButtonReset()
    {
        yield return new WaitForSeconds(m_WaitTime);

        ResetButton();
    }

    private void ResetButton()
    {
        OnButtonReset.Invoke();
    }
}
