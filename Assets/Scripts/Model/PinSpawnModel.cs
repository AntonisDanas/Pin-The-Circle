using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PinTypeTemplate {
    public GameObject pinType;
    public Sprite previewSprite;
    public string pinName;
}

public class PinSpawnModel : MonoBehaviour {

    [SerializeField] private List<PinTypeTemplate> m_pinTypes;

    public int GetPinCount() {
        return m_pinTypes.Count;
    }

    /* probably not needed
    public List<Sprite> GetAllPinPreviews() {
        List<Sprite> sprites = new List<Sprite>();
        for(int i = 0; i < m_pinTypes.Count; i++) {
            sprites.Add(m_pinTypes[i].previewSprite);
        }
        return sprites;
    }
    */

    public Sprite GetPinPreview(int pinIndex) {
        if (pinIndex >= m_pinTypes.Count)
            return null;

        return m_pinTypes[pinIndex].previewSprite;
    }

    public GameObject GetPinPrefab(int pinIndex) {
        if (pinIndex >= m_pinTypes.Count)
            return null;

        return m_pinTypes[pinIndex].pinType;
    }

    public string GetPinName(int pinIndex) {
        if (pinIndex >= m_pinTypes.Count)
            return null;

        return m_pinTypes[pinIndex].pinName;
    }

    public GameObject GetPinGameObjectByName(string pinName) {
        foreach (PinTypeTemplate pin in m_pinTypes) {
            if (pinName == pin.pinName) {
                return pin.pinType;
            }
        }
        return null;
    }
}
