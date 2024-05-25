using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextPopup : MonoBehaviour {

    public float destroyTimer;
    public TextMeshPro theTextPopup;

    // Update is called once per frame
    void Update() {
        Destroy (this.gameObject, destroyTimer);
    }

    public void StartPopup (string text) {
        theTextPopup.text = text;
    }
}
