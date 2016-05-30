using UnityEngine;
using System.Collections;

public class TouchInputSwipe : MonoBehaviour {
    private Ray ray;
    private RaycastHit hit;
    public float minSwipeDistY;
    public float minSwipeDistX;
    private Vector2 startPos;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) {
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
    }
}
