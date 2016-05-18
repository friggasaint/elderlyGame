using UnityEngine;
using System.Collections;

public class SlotButton_Stop : MonoBehaviour {

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
    void GotHit() {
        GameObject.Find("Main Camera").SendMessage("hitStop");
    }
}
