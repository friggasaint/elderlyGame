using UnityEngine;
using System.Collections;

public class PauseButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void GotHit() {
        GameConfig_Bingo.paused = !GameConfig_Bingo.paused;
        if (GameConfig_Bingo.paused) {
            GetComponent<TextMesh>().color = Color.red;
        } else {
            GetComponent<TextMesh>().color = Color.white;
        }
    }
}
