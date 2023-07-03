using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

using TMPro;
using Unity.VisualScripting;

public class InputController : MonoBehaviour
{
    [SerializeField]
    TMP_Text text;

    [SerializeField]
    TMP_Text movementText;

    [SerializeField]
    GameObject playerGameObject;

    public float moveSpeed;

    public float xMin = -3.0f;

    public float xMax = 3.0f;

    /// <summary>
    /// value read in from game pad
    /// </summary>
    Vector2 moveAmount;

    private bool isMovingHorizontally = true;

    void Awake()
    {
        var allGamepads = Gamepad.all;

        foreach (Gamepad gamepad in allGamepads)
        {
            Debug.Log($"game pad {gamepad.name}");
            text.text = gamepad.name;
        }
    }

    #region Game Update

    // Update is called once per frame
    void Update()
    {
        if (isMovingHorizontally)
        {
            MoveHorizontally(moveAmount);
        }
        else
        {
            Move(moveAmount);
        }
    }

    private void MoveHorizontally(Vector2 direction)
    {
        if (direction.sqrMagnitude < 0.01)
            return;

        // check if the direction being moved will go past the horizontal limits
        float xPos = playerGameObject.transform.position.x;
        float moveAmount = direction.x * moveSpeed;
        

        if (direction.x < 0 && (xPos + moveAmount < xMin)) // direction < 0 - left
        {
            return;
        }
        
        if (direction.x > 0 && (xPos + moveAmount > xMax)) // direction > 0 - right
        {
            return;
        }

        var scaledMoveSpeed = moveSpeed * Time.deltaTime;
        var move = Quaternion.Euler(0, playerGameObject.transform.eulerAngles.y, 0) * new Vector3(direction.x, 0, 0);
        playerGameObject.transform.position += move * scaledMoveSpeed;
    }


    /// <summary>
    /// This gets invoked when movement keys or a gamepad is used.
    /// The movement keys are currently mapped to WASD.
    /// </summary>
    /// <param name="direction"></param>
    private void Move(Vector2 direction)
    {
        if (direction.sqrMagnitude < 0.01)
            return;
        var scaledMoveSpeed = moveSpeed * Time.deltaTime;
        // For simplicity's sake, we just keep movement in a single plane here. Rotate
        // direction according to world Y rotation of player.
        var move = Quaternion.Euler(0, playerGameObject.transform.eulerAngles.y, 0) * new Vector3(direction.x, 0, direction.y);
        playerGameObject.transform.position += move * scaledMoveSpeed;
    }

    #endregion

    #region Input

    /// <summary>
    /// This gets configured in the scene in the PlayerInput class in the gameplay
    /// callback events.
    /// </summary>
    /// <param name="context"></param>
    public void OnMove(InputAction.CallbackContext context)
    {
        // read the value for the "move" action each event call
        moveAmount = context.ReadValue<Vector2>();
        movementText.text = $"({moveAmount.x.ToString("F2")}, {moveAmount.y.ToString("F2")})";
    }

    #endregion
}
