using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class loadBluetooth : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void GotHit() {
        SceneManager.LoadScene("Scenes/BluetoothTest");
        //Debug.Log("scenereload");
    }
}
