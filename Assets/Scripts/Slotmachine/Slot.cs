using UnityEngine;
using System.Collections;

public class Slot : MonoBehaviour {


    public struct colData {
        string colName;
        string slotName;
        public colData(string col, string slot) {
            this.colName = col;
            this.slotName = slot;
        }
        public string getColName() {
            return this.colName;
        }
        public string getSlotName() {
            return this.slotName;
        }

    }
    

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void setRunning(bool bl) {
        gameObject.GetComponent<BoxCollider>().enabled = !bl;
    }

    //Send col obj name to Game Config
    void OnTriggerEnter(Collider col) {
        transform.root.SendMessage("setColName", new colData(col.gameObject.name, transform.name));
        //transform.parent.gameObject.transform.parent.transform.SendMessage("setColName", thisColData);
        //Debug.Log(transform.name);
    }
}
