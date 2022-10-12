using UnityEngine;

public class PlinkoBall : MonoBehaviour
{
    private bool movingLeft;
    void Start() {
        movingLeft = true;
    }
    void Update() {
        if (movingLeft) {
            // move left
            if (transform.position.x <= -4) movingLeft = false;
        } else {
            // move right
        }
    }
}
