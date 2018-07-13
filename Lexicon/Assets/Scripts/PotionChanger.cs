using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionChanger : MonoBehaviour {

    public GameObject m_LightPrefab;
    public Color m_EndColor;
    public float m_ChangeSpeed = 1f;
    // Use this for initialization
    private bool InContactWithLiquid = false;
    private Material m_ChangingObjectMaterial;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (InContactWithLiquid)
        {
            Color newColor = Color.Lerp(m_ChangingObjectMaterial.color, m_EndColor, Time.deltaTime * m_ChangeSpeed);
            m_ChangingObjectMaterial.color = newColor;
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Pickupable"))
        {
            InContactWithLiquid = true;
            m_ChangingObjectMaterial = other.gameObject.GetComponent<MeshRenderer>().material;

            if (other.gameObject.transform.childCount < 1)
            {
                Instantiate(m_LightPrefab, other.gameObject.transform.position, Quaternion.identity, other.gameObject.transform);
            }
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (m_ChangingObjectMaterial != null)
        {
            m_ChangingObjectMaterial = null;
            InContactWithLiquid = false;
        }
    }
}
