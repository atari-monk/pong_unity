using UnityEngine;

public class Ball : MonoBehaviour {
    public float speed = 10f;

    void Start() {
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.name == "PaddleLeft" || collision.gameObject.name == "PaddleRight") {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-GetComponent<Rigidbody2D>().velocity.x, GetComponent<Rigidbody2D>().velocity.y);
        }
    }
}
