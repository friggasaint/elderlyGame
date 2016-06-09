using UnityEngine;
using System.Collections;

public class GameConfig_Slice : MonoBehaviour {

    AndroidJavaClass jc;
    string javaMessage = "";
    public static int score;
    private bool standing = true;
    private bool freeze = false;
    private bool wasFreeze = false;
    private int w = 250;
    private int h = 50;
    public string stringToEdit = "Please Take a Sip.";
    private GUIStyle guiStyle;
    // Use this for initialization
    void Start () {
        // Acces the android java receiver we made
        jc = new AndroidJavaClass("de.tum.far.receiver.MyReceiver");
        // We call our java class function to create our MyReceiver java object
        //jc.CallStatic("createInstance");
		guiStyle = new GUIStyle();
    }
	
	// Update is called once per frame
	void Update () {
        javaMessage = jc.GetStatic<string>("text");
        if (javaMessage.Equals("true")) {
            standing = false;
            Debug.Log("standing = false");
        }

        if (!standing && javaMessage.Equals("false")) {
            standing = true;
            freeze = false;
            Debug.Log("standing = true");
        }

        if( score != 0 && score%20 == 0 && !wasFreeze){
            freeze = true;
            wasFreeze = true;
        }

        if (score%20 == 19)
            wasFreeze = false;

        if (freeze) {
            Time.timeScale = 0.0f;
        } else {
            Time.timeScale = 1.0f;
        }
	
	}
    void OnGUI() {
        if (freeze) {

			guiStyle.fontSize = 90;
			guiStyle.normal.textColor = Color.red;
			GUI.Label(new Rect((Screen.width - w) / 2 - 250, (Screen.height - h) / 2, 70, 30), stringToEdit, guiStyle);
			//GUI.Box(new Rect((Screen.width - w) / 2 - 250, (Screen.height - h) / 2, 750, 90), new GUIContent(""));
        }
    }
}
