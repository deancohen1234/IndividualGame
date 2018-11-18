using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Recepticle : MonoBehaviour {

    public ParticleSystem m_OnHitSystem;
    public float m_DelaySeconds = 3f;

    public Canvas m_UICanvas;
    public Canvas m_VRUICanvas;
    // Use this for initialization
    void Start ()
    {
		
	}

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.GetComponentInChildren<Light>() != null)
        {
            Debug.Log(other.name + gameObject.name);
            StartCoroutine(DelayFinish(other.gameObject));
        }
    }

    //waits for x seconds so particle system can finish playing and make ending better
    private IEnumerator DelayFinish(GameObject infusedObject)
    {
        m_OnHitSystem.Emit(2000);

        yield return new WaitForSeconds(m_DelaySeconds);

        //level is complete
        infusedObject.SetActive(false);
        m_UICanvas.gameObject.SetActive(true);
        m_VRUICanvas.gameObject.SetActive(true);

        yield return new WaitForSeconds(m_DelaySeconds);

        SceneManager.LoadScene("Main Menu");
    }
}
