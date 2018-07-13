using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LexiconRotater : MonoBehaviour {

    public Animator m_LeverAnimator;
    public Animator m_CageAnimator;

    public Transform m_SmallLexiconTransform;

    public float speed = 5;
    public bool m_IsCopy = false; //for the player viewport

    public AudioSource[] m_Sources;
    public AudioClip m_RotateLexiconSoundClip;

    public static bool m_LexiconNotLocked = false;
	// Use this for initialization
	void Start () {
        //EmmisiveHandler();
	}
	
	// Update is called once per frame
	void Update ()
    {
        InputManager();
    }

    private void InputManager()
    {
        if (m_LexiconNotLocked || m_IsCopy)
        {
            RotateLexicon();
        }
        /*
        if (OVRInput.Get(OVRInput.Button.One))
        {
            RotateLexicon();
        }*/
    }

    public void ToggleLexiconNotLocked()
    {
        m_LexiconNotLocked = !m_LexiconNotLocked;
        PlayAudio();
    }

    private void PlayAudio()
    {
        for (int i = 0; i < m_Sources.Length; i++)
        {
            AudioSource source = m_Sources[i];
            source.clip = m_RotateLexiconSoundClip;
            source.Play();
        }
    } 

    private void RotateLexicon()
    {
        Vector3 rot = transform.rotation.eulerAngles;

        if (Input.GetKeyDown(KeyCode.Semicolon))
        {
            m_LeverAnimator.SetTrigger("PullLever");
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            m_CageAnimator.SetTrigger("LowerCage");
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, m_SmallLexiconTransform.rotation, Time.deltaTime);
    }

    private void EmmisiveHandler()
    {
        //GetComponent<MeshRenderer>().material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
        //GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
    }
}
