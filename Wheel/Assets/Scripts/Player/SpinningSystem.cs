using System;
using UnityEngine;
using UnityEngine.InputSystem;

public enum WheelDirection
{
    stopped,
    right,
    left
}

public class SpinningSystem : MonoBehaviour
{
    public InputActionReference mousePosAction;
    public InputActionReference mouseClickAction;

    public WheelDirection wheelDirection;
    Vector3 oldRight;

    bool isSpinning;

    public float rotationSpeed;
    private Quaternion targetRotation;

    private void Start()
    {
        targetRotation = transform.rotation;
        oldRight = transform.right;
    }

    private void Update()
    {
        DetermineWheelDirection();

        if (mouseClickAction.action.WasReleasedThisFrame())
        {
            wheelDirection = WheelDirection.stopped;
            isSpinning = false;
        }

        if (isSpinning == true)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(mousePosAction.action.ReadValue<Vector2>());
            mousePos.z = 0;

            Vector3 direction = mousePos - transform.position;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));          
        }

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    public void DetermineWheelDirection()
    {
        Vector3 cross = Vector3.Cross(oldRight, transform.right);

        if (cross.z < 0)
            wheelDirection = WheelDirection.right;
        else if (cross.z > 0)
            wheelDirection = WheelDirection.left;
        else
            wheelDirection = WheelDirection.stopped;

        oldRight = transform.right;
}

    private void MouseClicked(InputAction.CallbackContext context)
    {
        isSpinning = true;
    }

    private void OnEnable()
    {
        mouseClickAction.action.performed += MouseClicked;
    }

    private void OnDisable()
    {
        mouseClickAction.action.performed -= MouseClicked;
    }
}