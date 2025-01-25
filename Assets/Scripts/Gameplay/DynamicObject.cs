using UnityEngine;

public class DynamicObject : MonoBehaviour
{
    [SerializeField] private float maximumVelocity = 0.1f;
    [SerializeField] private bool movementAxisLocalAxis = false;
    [SerializeField] private Vector3 movementAxis;
    [SerializeField] private Rigidbody rb;
    private bool moveable = false;
    private Vector2 inputScreenPosition, inputScreenPositionOld;
    private Vector3 oldPosition, newPosition, movementVector;
    public void StartMovement()
    {
        moveable = true;
        inputScreenPosition = InputManager.instance.inputScreenPosition;
        inputScreenPositionOld = inputScreenPosition;

        Ray ray = Camera.main.ScreenPointToRay(inputScreenPosition);
        Physics.Raycast(ray, out RaycastHit hit);
        oldPosition = hit.point;
        newPosition = hit.point;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.linearVelocity = Vector3.zero;
        if (moveable)
        {
            if (!InputManager.instance.isPressed)
            {
                moveable = false;
                return;
            }
            inputScreenPosition = InputManager.instance.inputScreenPosition;
        }

        Ray newRay = Camera.main.ScreenPointToRay(inputScreenPosition);
        if (Physics.Raycast(newRay, out RaycastHit hit))
        {
            newPosition = hit.point;
        }

        if (movementAxisLocalAxis)
            movementVector += Vector3.Scale(newPosition - oldPosition, transform.TransformDirection(movementAxis));
        else
            movementVector += Vector3.Scale(newPosition - oldPosition, movementAxis);

        rb.MovePosition(rb.position + Vector3.ClampMagnitude(movementVector, maximumVelocity));
        movementVector -= Vector3.ClampMagnitude(movementVector, maximumVelocity);

        oldPosition = newPosition;
    }
}
