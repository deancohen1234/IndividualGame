using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//one time action, meaning lever is reset after each pull
public class Lever : MonoBehaviour {

    public UnityEvent m_OnLeverPulled;

	// Use this for initialization
	void Start () {
		
	}

    //called usually from another script with a raycast to trigger events linked to this lever
    public void PullLever()
    {
        m_OnLeverPulled.Invoke();
        GetComponent<Animator>().SetTrigger("PullLever");
    }
}
