using UnityEngine;
using System.Collections;

public class HighscoreCounter : MonoBehaviour {
	private int highscore = GameConfig_SlotMachine.credits;
	// Use this for initialization
	void Start () {
		GetComponent<TextMesh>().text = GameConfig_SlotMachine.credits.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
		if(highscore < GameConfig_SlotMachine.credits){
			highscore = GameConfig_SlotMachine.credits;
			GetComponent<TextMesh>().text = highscore.ToString();
		}
    }
}
