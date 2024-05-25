using UnityEngine;
using UnityEngine.InputSystem;

public class Paddle : MonoBehaviour {

    public float speed = 10f;
    public string map;
    private Rigidbody2D rigidbody2d;
    private PaddleInputActions paddleInputActions;
    private Vector2 inputVector;

    public void Awake() {
        rigidbody2d = GetComponent<Rigidbody2D>();
        paddleInputActions = new PaddleInputActions();
        paddleInputActions.Player.Enable();
        //if (map == "Vertical")
        //    paddleInputActions.Player.Vertical.performed += Jump;
        //if (map == "Vertical2")
        //    paddleInputActions.Player.Vertical2.performed += Jump;
    }

    public void FixedUpdate() {
        if (map == "Vertical")
            inputVector = paddleInputActions.Player.Vertical.ReadValue<Vector2>();
        if (map == "Vertical2")
            inputVector = paddleInputActions.Player.Vertical2.ReadValue<Vector2>();
        //rigidbody2d.AddForce(new Vector2(inputVector.x, inputVector.y) * speed, ForceMode2D.Force);
        rigidbody2d.velocity = new Vector2(0f, inputVector.y * speed);
    }

    public void Jump(InputAction.CallbackContext context) {
        Debug.Log(context);
        rigidbody2d.AddForce(Vector2.up * 5f, ForceMode2D.Impulse);
    }
}
