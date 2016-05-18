using UnityEngine;
using System.Collections;

public class TouchInput : MonoBehaviour {
    private Ray ray;
    private RaycastHit hit;
    public float minSwipeDistY;
    public float minSwipeDistX;
    private Vector2 startPos;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
            //position first touches
            //Input.GetTouch(0).position;

            ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity)) {
                Debug.Log(hit.transform.gameObject.name);
                hit.transform.gameObject.SendMessage("GotHit", SendMessageOptions.DontRequireReceiver);
            }

            //foreach (Touch touch in Input.touches)
            //{
            //    Debug.Log(touch.position);
            //}
        }

        //#if UNITY_ANDROID
        if (Input.touchCount > 0) {

            Touch touch = Input.touches[0];

            switch (touch.phase) {
                case TouchPhase.Began:
                    startPos = touch.position;
                    break;

                case TouchPhase.Ended:
                    float swipeDistVertical = (new Vector3(0, touch.position.y, 0) - new Vector3(0, startPos.y, 0)).magnitude;
                    if (swipeDistVertical > minSwipeDistY) {
                        float swipeValue = Mathf.Sign(touch.position.y - startPos.y);
                        if (swipeValue > 0) {//up swipe
                            //Jump ();
                        } else if (swipeValue < 0) {//down swipe
                            //Shrink ();
                        }
                    }

                    float swipeDistHorizontal = (new Vector3(touch.position.x, 0, 0) - new Vector3(startPos.x, 0, 0)).magnitude;
                    if (swipeDistHorizontal > minSwipeDistX) {
                        float swipeValue = Mathf.Sign(touch.position.x - startPos.x);
                        if (swipeValue > 0) {//right swipe
                            //MoveRight ();
                        } else if (swipeValue < 0) {//left swipe
                            //MoveLeft ();
                        }
                    }
                    break;
            }

        }
    }
}
