using UnityEngine;
using System.Collections;

public class CreditCounter : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<TextMesh>().text = GameConfig_SlotMachine.credits.ToString();
    }
}
