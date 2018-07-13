using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recepticle : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.GetComponentInChildren<Light>() != null)
        {
            other.gameObject.transform.GetChild(0).GetComponent<Light>().intensity = 0;

            NonVRInteractionManager nm = FindObjectOfType<NonVRInteractionManager>();
            nm.OpenCage();
        }
    }
}
