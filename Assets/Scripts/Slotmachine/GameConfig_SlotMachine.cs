using UnityEngine;
using System.Collections;

public class GameConfig_SlotMachine : MonoBehaviour {

    public static int credits;
    private int winCredits;
    private int reelsRunningCount;

    // buttons
    private bool buttonStart;
    private bool buttonStop;
    private bool checkWin;

    // handles
    private GameObject reel0;
    private GameObject reel1;
    private GameObject reel2;
    private GameObject reel3;
    private GameObject reel4;

    // slots
    private string slotColName0;
    private string slotColName1;
    private string slotColName2;
    private string slotColName3;
    private string slotColName4;
    private string slotColName5;
    private string slotColName6;
    private string slotColName7;
    private string slotColName8;
    private string slotColName9;
    private string slotColName10;
    private string slotColName11;
    private string slotColName12;
    private string slotColName13;
    private string slotColName14;


    // Use this for initialization
    void Start() {
        credits = 0;
        winCredits = 0;
        reelsRunningCount = 0;
        buttonStart = false;
        buttonStop = false;
        checkWin = false;
        reel0 = transform.FindChild("Reel0").gameObject;
        reel1 = transform.FindChild("Reel1").gameObject;
        reel2 = transform.FindChild("Reel2").gameObject;
        reel3 = transform.FindChild("Reel3").gameObject;
        reel4 = transform.FindChild("Reel4").gameObject;
    }

    // Update is called once per frame
    void Update() {

        //check if we won something
        if (checkWin) {
            debugSlots();
            if (slotColName3.Equals(slotColName6) && slotColName6.Equals(slotColName9)) {
                winCredits = 5;
            } else if (slotColName4.Equals(slotColName7) && slotColName7.Equals(slotColName10)) {
                winCredits = 5;
            } else if (slotColName5.Equals(slotColName8) && slotColName8.Equals(slotColName11)) {
                winCredits = 5;
            } else if (slotColName3.Equals(slotColName7) && slotColName7.Equals(slotColName11)) {
                winCredits = 5;
            } else if (slotColName5.Equals(slotColName7) && slotColName7.Equals(slotColName9)) {
                winCredits = 5;
            }

            credits += winCredits;
            winCredits = 0;
            checkWin = false;
        }
        //checks if game is currently running and buttons are pressed

        //stoping reels
        if (reelsRunningCount != 0 && buttonStop) {

            switch (reelsRunningCount) {
                case 5:
                    reel0.SendMessage("setReelActive", false);
                    reelsRunningCount--;
                    break;
                case 4:
                    reel1.SendMessage("setReelActive", false);
                    reelsRunningCount--;
                    break;
                case 3:
                    reel2.SendMessage("setReelActive", false);
                    reelsRunningCount--;
                    break;
                case 2:
                    reel3.SendMessage("setReelActive", false);
                    reelsRunningCount--;
                    //just for the purpose of 3 reels 
                    reelsRunningCount--;
                    checkWin = true;
                    break;
                case 1:
                    reel4.SendMessage("setReelActive", false);
                    reelsRunningCount--;
                    break;
                default:
                    break;
            }

            // starting reels
        } else if (reelsRunningCount == 0 && buttonStart) {
            //reel0.SendMessage("setReelActive", true);
            reel1.SendMessage("setReelActive", true);
            reel2.SendMessage("setReelActive", true);
            reel3.SendMessage("setReelActive", true);
            //reel4.SendMessage("setReelActive", true);
            reelsRunningCount = 4; // for 3 reels
        }

        this.resetButtons();
    }

    private void resetButtons() {
        buttonStart = false;
        buttonStop = false;
    }

    public void hitStart() {
        buttonStart = true;
        //Debug.Log("activated");
    }
    public void hitStop() {
        buttonStop = true;
    }

    public void setColName(Slot.colData Data) {
        string slotName = Data.getSlotName();
        string colName = Data.getColName();
        //Debug.Log("setColName: " +colName + slotName);
        switch (slotName) {
            case "Slot0":
                slotColName0 = colName;
                break;
            case "Slot1":
                slotColName1 = colName;
                break;
            case "Slot2":
                slotColName2 = colName;
                break;
            case "Slot3":
                slotColName3 = colName;
                break;
            case "Slot4":
                slotColName4 = colName;
                break;
            case "Slot5":
                slotColName5 = colName;
                break;
            case "Slot6":
                slotColName6 = colName;
                break;
            case "Slot7":
                slotColName7 = colName;
                break;
            case "Slot8":
                slotColName8 = colName;
                break;
            case "Slot9":
                slotColName9 = colName;
                break;
            case "Slot10":
                slotColName10 = colName;
                break;
            case "Slot11":
                slotColName11 = colName;
                break;
            case "Slot12":
                slotColName12 = colName;
                break;
            case "Slot13":
                slotColName13 = colName;
                break;
            case "Slot14":
                slotColName14 = colName;
                break;
            default:
                break;
        }
    }

    public void debugSlots() {
        Debug.Log(slotColName0);
        Debug.Log(slotColName1);
        Debug.Log(slotColName2);
        Debug.Log(slotColName3);
        Debug.Log(slotColName4);
        Debug.Log(slotColName5);
        Debug.Log(slotColName6);
        Debug.Log(slotColName7);
        Debug.Log(slotColName8);
        Debug.Log(slotColName9);
        Debug.Log(slotColName10);
        Debug.Log(slotColName11);
        Debug.Log(slotColName12);
        Debug.Log(slotColName13);
        Debug.Log(slotColName14);
    }

}
