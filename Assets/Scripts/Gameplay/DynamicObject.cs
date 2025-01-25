using UnityEngine;

public class DynamicObject : MonoBehaviour
{
    [SerializeField] private Vector3 movementAxis;
    [SerializeField] private Rigidbody rb;
    private bool moveable = false;
    private Vector2 inputScreenPosition, inputScreenPositionOld;
    private Vector3 oldPosition,newPosition;
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
        if(moveable)
        {
            if(!InputManager.instance.isPressed)
            {
                moveable = false;
                return;
            }
            inputScreenPosition = InputManager.instance.inputScreenPosition;

            Ray newRay = Camera.main.ScreenPointToRay(inputScreenPosition);
            if (Physics.Raycast(newRay, out RaycastHit hit))
            {
                newPosition = hit.point;
            }

            Vector3 movementInput = newPosition - oldPosition;
            rb.MovePosition(rb.position + Vector3.Scale(movementInput, movementAxis));
            oldPosition = newPosition;
        }
    }
}
