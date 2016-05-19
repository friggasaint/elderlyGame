using UnityEngine;
using System.Collections;

public class GameConfig_Bingo : MonoBehaviour {

    public static int[] bingoArray = new int[25];
    public static bool[] checkArray = new bool[25];
    public static bool paused;
    public float timer;
    public static float timeleft;
    private bool waitSip;
    int temp;
    bool numberFree;
    // Use this for initialization
    void Start() {
        //init
        numberFree = true;
        paused = false;
        timeleft = timer;
        waitSip = false;

        //Debug.Log(bingoArray.Length);
        // Create new set of Numbers
        for (int i = 0; i < bingoArray.Length; i++) {

            // init CheckArray
            checkArray[i] = false;

            temp = GiveNumber((i/5)+1);
            for (int k = 0; k < i; k++) {
                if (temp == bingoArray[k])
                {
                    numberFree = false;
                }
            }
            //Debug.Log("Checkpoint: "+temp);
            if (numberFree) {
                bingoArray[i] = temp;
                Debug.Log(bingoArray[i]);
            } else {
                i = i - 1;
                numberFree = true;
            }

        }

    }

    // Update is called once per frame
    void Update() {
        timeleft -= Time.deltaTime;

        if (checkWinCondition()) {
            GameObject.Find("Button Win").GetComponent<TextMesh>().text = "Win Yes";
            //Debug.Log("Winner");
        }

        if (timeleft <= 0) {
            transform.SendMessage("needSipFreeze");
            waitSip = true;
            paused = true;
        }
    }

    public static int GiveNumber(int row) {
        int i = 0;
        switch (row) {
            case 1:
                i = (int)Random.Range(1f, 15f);
                break;
            case 2:
                i = (int)Random.Range(16f, 30f);
                break;
            case 3:
                i = (int)Random.Range(31f, 45f);
                break;
            case 4:
                i = (int)Random.Range(46f, 60f);
                break;
            case 5:
                i = (int)Random.Range(61f, 75f);
                break;
            default:
                break;
        }
        return i;
    }

    bool checkWinCondition() {
        bool win = false;
        if (checkArray[0] && checkArray[1] && checkArray[2] && checkArray[3] && checkArray[4] ||
            checkArray[5] && checkArray[6] && checkArray[7] && checkArray[8] && checkArray[9] ||
            checkArray[10] && checkArray[11] && checkArray[12] && checkArray[13] && checkArray[14] ||
            checkArray[15] && checkArray[16] && checkArray[17] && checkArray[18] && checkArray[19] ||
            checkArray[20] && checkArray[21] && checkArray[22] && checkArray[23] && checkArray[24] ||
            checkArray[0] && checkArray[5] && checkArray[10] && checkArray[15] && checkArray[20] ||
            checkArray[1] && checkArray[6] && checkArray[11] && checkArray[16] && checkArray[21] ||
            checkArray[2] && checkArray[7] && checkArray[12] && checkArray[17] && checkArray[22] ||
            checkArray[3] && checkArray[8] && checkArray[13] && checkArray[18] && checkArray[23] ||
            checkArray[4] && checkArray[9] && checkArray[14] && checkArray[19] && checkArray[24] ||
            checkArray[0] && checkArray[6] && checkArray[12] && checkArray[18] && checkArray[24] ||
            checkArray[20] && checkArray[16] && checkArray[12] && checkArray[8] && checkArray[4]) {
            win = true;
        }
        return win;
    }

    public void sendSipConformation() {
        if (waitSip) {
            waitSip = false;
            paused = false;
            timeleft = timer;
            }
    }
}
