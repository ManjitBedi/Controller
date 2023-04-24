using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

using TMPro;

public class InputController : MonoBehaviour
{
    [SerializeField]
    TMP_Text text;

    [SerializeField]
    TMP_Text movementText;

    Vector2 moveAmount;

    void Awake()
    {
        var allGamepads = Gamepad.all;

        foreach (Gamepad gamepad in allGamepads)
        {
            Debug.Log($"game pad {gamepad.name}");
            text.text = gamepad.name;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region

    public void OnMove(InputAction.CallbackContext context)
    {
        // read the value for the "move" action each event call
        moveAmount = context.ReadValue<Vector2>();
        movementText.text = $"({moveAmount.x.ToString("F2")}, {moveAmount.y.ToString("F2")})";
    }

    #endregion
}
