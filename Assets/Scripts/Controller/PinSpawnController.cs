using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinSpawnController : MonoBehaviour {

    private PinSpawnModel m_pinSpawnModel;
    private PinSpawnView m_pinSpawnView;

	// Use this for initialization
	void Start () {
        m_pinSpawnView = FindObjectOfType<PinSpawnView>();
        m_pinSpawnModel = FindObjectOfType<PinSpawnModel>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SpawnSelectedPin(string pinName) {

        GameObject pin = m_pinSpawnModel.GetPinGameObjectByName(pinName);
        if (pin) {
            m_pinSpawnView.SpawnPin(pin, pinName);
        }

        return;
    }

}
