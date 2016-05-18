using UnityEngine;
using System.Collections;


public class ReelObject : MonoBehaviour {

    private int speed;
    private float positionY;
    private bool reelRunning;
    private bool collide;
    private SpriteRenderer spriteRenderer;

    // Use this for initialization
    void Start() {
        speed = 20;
        reelRunning = false;
        collide = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
        transform.name = spriteRenderer.sprite.name;
    }

    // Update is called once per frame
    void Update() {
        positionY = gameObject.transform.position.y;
        if (reelRunning) {
            transform.Translate(Vector3.down * Time.deltaTime * speed, Space.World);
            if (positionY <= -6.0f) {
                GameObject.Destroy(gameObject);
            }
        } else { //symbol on reel showing - reel stops

            //if (positionY < 0.0f && positionY >= -3.25f) {
            //    transform.position = new Vector3(transform.position.x, -3.0f, transform.position.z);
            //} else if (positionY < 3.0f && positionY >= 0.0f) {
            //    transform.position = new Vector3(transform.position.x, 0.0f, transform.position.z);
            //} else if (positionY >= 3.0f) {
            //    transform.position = new Vector3(transform.position.x, 3.0f, transform.position.z);
            //} else {
            //    GameObject.Destroy(gameObject);
            //}
            if (!collide) {
                transform.Translate(Vector3.down * Time.deltaTime * speed, Space.World);
                if (positionY <= -6.0f) {
                    GameObject.Destroy(gameObject);
                }
            } else {

            }

        }

    }



    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Slot") {
            transform.position = other.transform.position;
            GetComponent<Rigidbody>().isKinematic = false;
            collide = true;
            //Debug.Log("collision");
        }
    }

    private void setSprite(Sprite sprite) {
        spriteRenderer.sprite = sprite;
    }

    private void setRunning(bool running) {
        reelRunning = running;
    }
}
