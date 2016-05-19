using UnityEngine;
using System.Collections;

public class TimerCounter : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<TextMesh>().text = GameConfig_Bingo.timeleft.ToString();
    }
}
