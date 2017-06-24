using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSelector : MonoBehaviour {

    public GameObject buttonPrefab;

    private PinSpawnModel m_pinSpawnModel;
    private PinSpawnController m_pinSpawnController;

	// Use this for initialization
	void Start () {
        m_pinSpawnModel = FindObjectOfType<PinSpawnModel>();
        m_pinSpawnController = FindObjectOfType<PinSpawnController>();
        for (int i = 0; i < m_pinSpawnModel.GetPinCount(); i++) {
            GameObject button = Instantiate(buttonPrefab) as GameObject;
            button.transform.SetParent(transform);            
            Image imageComponent = button.GetComponent<Image>();
            imageComponent.type = Image.Type.Simple;
            imageComponent.sprite = m_pinSpawnModel.GetPinPreview(i);    
            RectTransform rectTransform = button.GetComponent<RectTransform>();
            rectTransform.localScale = new Vector3(1f, 1f, 1f);
            Button buttonComponent = button.GetComponent<Button>();
            string pinName = m_pinSpawnModel.GetPinName(i);
            buttonComponent.onClick.AddListener(delegate {
                ButtonListener(pinName); });
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void ButtonListener(string call) {
        print("called");
        print(call);
        if (call != null)
            m_pinSpawnController.SpawnSelectedPin(call);
    }
}
