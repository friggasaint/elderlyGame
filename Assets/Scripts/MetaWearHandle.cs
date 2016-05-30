using UnityEngine;
using System.Collections;

public class MetaWearHandle : MonoBehaviour {
    AndroidJavaClass jc;
    string javaMessage = "";
    private bool standing = true;
    private bool freeze = false;
    private bool wasFreeze = false;
    private int w = 250;
    private int h = 50;
    private GUIStyle guiStyle;
    public string stringToEdit = "Please Take a Sip.";
    // Use this for initialization
    void Start() {
        // Acces the android java receiver we made
        try {
            jc = new AndroidJavaClass("de.tum.far.receiver.MyReceiver");
        } catch (System.Exception) {

            //throw;
        }
        
        // We call our java class function to create our MyReceiver java object
        //jc.CallStatic("createInstance");
        guiStyle = new GUIStyle();
    }

    // Update is called once per frame
    void Update() {
        try {
            javaMessage = jc.GetStatic<string>("text");
        } catch (System.NullReferenceException ex) {
            //Debug.Log(ex.ToString());
            javaMessage = "no device connected";
            //throw;
        }
        
        if (javaMessage.Equals("true")) {
            standing = false;
            //Debug.Log("standing = false");
        }

        //just took a sip
        if (!standing && javaMessage.Equals("false")) {
            standing = true;
            freeze = false;
            transform.SendMessage("sendSipConformation");
            //Debug.Log("standing = true");
        }


        //stop time while waiting for Sip
        if (freeze) {
            Time.timeScale = 0.0f;
        } else {
            Time.timeScale = 1.0f;
        }

    }
    void OnGUI() {
        if (freeze) {
            guiStyle.fontSize = 50;
            GUI.Label(new Rect((Screen.width - w) / 2 - 100, (Screen.height - h) / 2, 70, 30), stringToEdit, guiStyle);
            GUI.Box(new Rect((Screen.width - w) / 2 - 100, (Screen.height - h) / 2, 440, 60), new GUIContent(""));
        }
    }

    public void  needSipFreeze() {
        freeze = true;
        wasFreeze = true;
    }

    public void unFreeze() {

    }

}
