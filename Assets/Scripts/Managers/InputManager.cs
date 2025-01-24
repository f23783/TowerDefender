using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;

    public InputSystem_Actions inputActions;

    public InputAction move, jump;
    private void Awake() {
        instance = this;

        inputActions = new InputSystem_Actions();
        inputActions.Player.Enable();
    }

    private void Start() {
        move = inputActions.FindAction("Move");
        jump = inputActions.FindAction("Jump");
    }
}
