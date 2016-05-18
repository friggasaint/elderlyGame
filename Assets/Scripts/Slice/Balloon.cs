using UnityEngine;
using System.Collections;

public class Balloon : MonoBehaviour {

    private bool touched = false;
    private float timer = 0;
    private Animator anim;

    // Use this for initialization
    void Start() {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        //balloonmovement
        transform.Translate(Vector3.up * Time.deltaTime, Space.World);
        
        //destroy balloon if exiting screen
        if (gameObject.transform.position.y >= 5.5f) {
            GameObject.Destroy(gameObject);
        }
    }

    void GotHit() {
        touched = true;
        GameConfig_Slice.score++;
        anim.SetBool("Pop",true);
        StartCoroutine(KillOnAnimationEnd());
    }
    private IEnumerator KillOnAnimationEnd() {
        yield return new WaitForSeconds(1.3f);
        Destroy(gameObject);
    }
}
