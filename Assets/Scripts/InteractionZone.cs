using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionZone : MonoBehaviour {

    //TODO make this more generic and not specifically linked to the transfer
    public Animator m_Animator;

    private void OnTriggerEnter(Collider other)
    {
        m_Animator.SetBool("IsCageOpen", true);
    }

    private void OnTriggerExit(Collider other)
    {
        m_Animator.SetBool("IsCageOpen", false);
    }
}
