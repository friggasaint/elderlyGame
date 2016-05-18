﻿using UnityEngine;
using System.Collections;

public class BroadcastReceiver : MonoBehaviour {

    AndroidJavaClass jc;
    string javaMessage = "";

    void Start() {
        // Acces the android java receiver we made
        jc = new AndroidJavaClass("de.tum.far.receiver.MyReceiver");
        // We call our java class function to create our MyReceiver java object
        jc.CallStatic("createInstance");
    }

    void Update() {
        // We get the text property of our receiver
        javaMessage = jc.GetStatic<string>("text");
        Debug.Log(javaMessage);
        GetComponent<TextMesh>().text = javaMessage;
    }
}
