using UnityEngine;
using System.Collections;

public class Reel : MonoBehaviour {
    public Sprite item1;
    public Sprite item2;
    public Sprite item3;
    public Sprite item4;
    public Sprite item5;
    public Sprite item6;
    public Sprite item7;

    public GameObject ReelSymbol;
    public int reelId;

    private float speed;
    private Sprite[] reelStack = new Sprite[256];
    private int temp;
    private int counter;
    private float time;
    private bool running;
    private bool brokeNews;

    // Use this for initialization
    void Start() {
        counter = 0;
        running = false;
        brokeNews = true;

        //space between symbols
        speed = 0.07f;

        //init reel
        for (int i = 0; i < reelStack.Length; i++) {
            temp = Random.Range(1, 7);
            switch (temp) {
                case 1:
                    reelStack[i] = item1;
                    break;
                case 2:
                    reelStack[i] = item2;
                    break;
                case 3:
                    reelStack[i] = item3;
                    break;
                case 4:
                    reelStack[i] = item4;
                    break;
                case 5:
                    reelStack[i] = item5;
                    break;
                case 6:
                    reelStack[i] = item6;
                    break;
                case 7:
                    reelStack[i] = item7;
                    break;
                default:
                    break;
            }
        }

    }

    // Update is called once per frame
    void Update() {

        if (running) {

            //recently changed bool
            if (!brokeNews) {
                foreach (Transform child in transform)
                    child.SendMessage("setRunning", true);
            }

            time += Time.deltaTime;
            if (time >= speed) {
                this.instSymbol(reelStack[counter]);
                time = -speed;
                if (counter >= 255)
                    counter = 0;
                else
                    counter++;
            }
        } else {
            if (!brokeNews) {
                foreach (Transform child in transform)
                    child.SendMessage("setRunning", false);
            }
        }
    }

    // instatiate a ReelSymbol
    private void instSymbol(Sprite sprSym) {
        GameObject symbol;
        symbol = Instantiate(ReelSymbol, new Vector3(transform.position.x, 5.0f, transform.position.z), Quaternion.identity) as GameObject;
        symbol.transform.parent = transform;
        symbol.GetComponent<SpriteRenderer>().sprite = sprSym;
    }

    public void setReelActive(bool set) {
        this.running = set;
        brokeNews = false;
        //Debug.Log("set reel active");
    }

    public bool getReelActive() {
        return running;
    }
}

