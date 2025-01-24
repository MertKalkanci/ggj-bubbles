using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

[DefaultExecutionOrder(-10)]
public class InputManager : MonoBehaviour
{
    private Vector2 inputScreenPosition, inputScreenPositionOld;
    private Finger currentFinger;
    private static InputManager instance;
    private static Control playerControlInputs;
    public static Control.GameplayInputsActions gameplayActions => playerControlInputs.GameplayInputs;
    private bool isPressed;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        playerControlInputs = new Control();
    }

    private void OnEnable()
    {
        gameplayActions.Enable();
        gameplayActions.Click.performed += OnClick;
        if (!Application.isMobilePlatform)
            return;
        EnhancedTouchSupport.Enable();
#if UNITY_EDITOR
        TouchSimulation.Enable();
#endif
        Touch.onFingerDown += TocuhStart;
        Touch.onFingerUp += TouchEnd;
    }
    private void TocuhStart(Finger finger)
    {
        if (isPressed)
            return;
        isPressed = true;
        currentFinger = finger;
    }
    private void TouchEnd(Finger finger)
    {
        isPressed = false;
    }
    private void Update()
    {
        if (!Application.isMobilePlatform)
            return;
        inputScreenPosition = currentFinger.screenPosition;

        inputScreenPositionOld = inputScreenPosition;
    }
    private void OnClick(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isPressed = true;
        }
        else if(context.canceled)
        {
            isPressed = false;
        }
    }
    private void  MousePositionRecord(InputAction.CallbackContext context)
    {
        if (!Application.isMobilePlatform)
            inputScreenPosition = context.ReadValue<Vector2>();
    }

}