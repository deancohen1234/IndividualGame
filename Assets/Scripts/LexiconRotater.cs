using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//gets transform of minuature lexicon in VR cave and matches it RotateLexicon is set
public class LexiconRotater : MonoBehaviour {

    public Animator m_LeverAnimator;
    public Animator m_CageAnimator;

    public Transform m_SmallLexiconTransform;

    public float speed = 5;
    public bool m_IsCopy = false; //for the player viewport

    public AudioSource[] m_Sources;
    public AudioClip m_RotateLexiconSoundClip;

    public static bool m_LexiconLocked = true;
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
        //if Lexicon is copy, always rotate, if not then it must be unlocked to rotate
        if (!m_LexiconLocked || m_IsCopy)
        {
            RotateLexicon();
        }
    }

    //TODO make this not a toggle but a time to move
    public void ToggleLexiconNotLocked()
    {
        StartCoroutine(DelayLocking());
        PlayAudio();
    }

    //give lexicon x number of seconds to rotate then lock it
    private IEnumerator DelayLocking()
    {
        m_LexiconLocked = false;

        yield return new WaitForSeconds(4.5f);

        m_LexiconLocked = true;
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

        transform.rotation = Quaternion.Lerp(transform.rotation, m_SmallLexiconTransform.rotation, Time.deltaTime);
    }
}