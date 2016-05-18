using UnityEngine;
using System.Collections;

public class BingoField : MonoBehaviour {

    bool check;
    int number, place;

    // Use this for initialization
    void Start() {
        //number = GameConfig.GiveNumber(1);
        check = false;
        place = int.Parse(GetComponent<TextMesh>().text);
    }

    // Update is called once per frame
    void Update() {
        number = GameConfig_Bingo.bingoArray[place - 1];
        GetComponent<TextMesh>().text = number.ToString();
        if (check) {
            GetComponent<TextMesh>().color = Color.red;
        } else {
            GetComponent<TextMesh>().color = Color.white;
        }
    }

    void GotHit() {
        if (!(GameConfig_Bingo.paused)) {
            check = !check;
            GameConfig_Bingo.checkArray[place - 1] = check;
            //Debug.Log("Field Got Hit");
    }
        }
}
