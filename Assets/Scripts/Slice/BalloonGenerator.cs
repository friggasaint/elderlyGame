using UnityEngine;
using System.Collections;

public class BalloonGenerator : MonoBehaviour {
    public GameObject prefab;
    public float speed;
    private float time;
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        time += Time.deltaTime;
        if (time >= speed) {
            Instantiate(prefab, new Vector3(Random.Range(-8.0F, 8.0F), -5.5f, 0), Quaternion.identity);
            time =- speed;
        }
    }
}
