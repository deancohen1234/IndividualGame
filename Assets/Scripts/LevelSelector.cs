using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//goes on non-vr player to select scenes from main menu
public class LevelSelector : MonoBehaviour {

    public Camera m_ControllingCamera;

	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TrySelect();
        }
	}

    void TrySelect()
    {
        Ray ray = new Ray(m_ControllingCamera.transform.position, m_ControllingCamera.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            LevelSpecifier ls = hit.collider.gameObject.GetComponent<LevelSpecifier>();

            if (ls != null)
            {
                ls.GotoScene();
            }
        }
    }
}
