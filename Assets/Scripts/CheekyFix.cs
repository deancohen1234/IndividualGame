using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheekyFix : MonoBehaviour {

    public GameObject m_OVRCameraRig;
	// Use this for initialization
	void Start () {
        StartCoroutine(WaitToSetActive());
	}

    private IEnumerator WaitToSetActive()
    {
        yield return new WaitForSeconds(1.5f);
        m_OVRCameraRig.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
