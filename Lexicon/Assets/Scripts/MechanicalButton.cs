using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MechanicalButton : MonoBehaviour {

    public UnityEvent OnButtonPressed;
    public UnityEvent OnButtonReset;
    public float m_WaitTime;
    // Use this for initialization
    private void OnTriggerEnter(Collider other)
    {
        OnButtonPressed.Invoke();
        StartCoroutine(WaitForButtonReset());
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
