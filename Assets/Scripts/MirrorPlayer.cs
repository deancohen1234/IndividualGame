using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this class move a dummy of the player in the copied Lexicon so it looks like the VRP is watching the NVRP
public class MirrorPlayer : MonoBehaviour {

    public Transform m_MainLexicon;
    public Transform m_NonVRPlayer;
    public Transform m_PlayerDummy;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 mainLexiconPlayerLocation = m_MainLexicon.InverseTransformPoint(m_NonVRPlayer.position);
        //Debug.Log("NonVR player position: " + mainLexiconPlayerLocation + "Dummy Position: " + m_PlayerDummy.localPosition);

        m_PlayerDummy.localPosition = mainLexiconPlayerLocation;
	}
}
