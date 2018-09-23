using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionChanger : MonoBehaviour {

    public GameObject m_LightPrefab;
    public GameObject m_ParticlePrefab;
    public Color m_EndColor;
    public Color m_CompleteColor;
    public float m_ChangeSpeed = 1f;

    public float m_MagnitudeNeededForChange = 50f;
    // Use this for initialization
    private bool InContactWithLiquid = false;
    private Material m_ChangingObjectMaterial;

    private Rigidbody m_ChangingObjectRB; //used for shaking of object to make it light up
    private float m_CurrentMagnitude = 0;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (InContactWithLiquid)
        {
            float lerpVal = m_CurrentMagnitude / m_MagnitudeNeededForChange; //percentage of how close potion is from being done

            Color newColor = Color.Lerp(m_ChangingObjectMaterial.color, m_EndColor, lerpVal);
            m_ChangingObjectMaterial.color = newColor;

            float emission = lerpVal;
            Color baseColor = m_EndColor; //Replace this with whatever you want for your base color at emission level '1'
            Color finalColor = baseColor * Mathf.LinearToGammaSpace(emission);
            m_ChangingObjectMaterial.SetColor("_EmissionColor", finalColor);

            float magnitude = m_ChangingObjectRB.velocity.sqrMagnitude;
            m_CurrentMagnitude += magnitude;

            //once potion is complete in transformation
            if  (m_CurrentMagnitude >= m_MagnitudeNeededForChange)
            {
                ParticleSystem system = m_ChangingObjectRB.gameObject.GetComponentInChildren<ParticleSystem>();
                system.Emit(45);

                baseColor = m_CompleteColor; //Replace this with whatever you want for your base color at emission level '1'
                finalColor = baseColor * Mathf.LinearToGammaSpace(emission);
                m_ChangingObjectMaterial.SetColor("_EmissionColor", finalColor);

                ResetPotionSystem();
            }
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Pickupable"))
        {
            InContactWithLiquid = true;
            m_ChangingObjectMaterial = other.gameObject.GetComponent<MeshRenderer>().material;
            m_ChangingObjectMaterial.EnableKeyword("_EMISSION");

            m_ChangingObjectRB = other.gameObject.GetComponent<Rigidbody>();
            m_CurrentMagnitude = 0;

            if (other.gameObject.transform.childCount < 1)
            {
                Instantiate(m_LightPrefab, other.gameObject.transform.position, Quaternion.identity, other.gameObject.transform);
                Instantiate(m_ParticlePrefab, other.gameObject.transform.position, Quaternion.identity, other.gameObject.transform);
            }
        }
    }

    private void ResetPotionSystem()
    {
        if (m_ChangingObjectMaterial != null)
        {
            m_ChangingObjectMaterial = null;
            InContactWithLiquid = false;
        }
    }
}
