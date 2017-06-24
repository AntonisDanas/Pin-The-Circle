using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinSpawnView : MonoBehaviour {

    private GameObject m_pinSpawned;
    private string m_pinSpawnedName;

	// Use this for initialization
	void Start () {
        m_pinSpawned = null;
        m_pinSpawnedName = null;
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0) && m_pinSpawned) {
            m_pinSpawned.GetComponent<PinAbstract>().LaunchPin();
            m_pinSpawned = null;
            m_pinSpawnedName = null;
        }
	}

    public void SpawnPin(GameObject pin, string pinName) {
        if (pinName == m_pinSpawnedName) {
            return;
        }

        m_pinSpawnedName = pinName;

        if (m_pinSpawned)
            Destroy(m_pinSpawned);

        m_pinSpawned = Instantiate<GameObject>(pin,transform.position,Quaternion.identity);
    }
}
