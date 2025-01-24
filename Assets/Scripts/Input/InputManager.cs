using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

[DefaultExecutionOrder(-10)]
public class InputManager : MonoBehaviour
{
    [SerializeField] private LayerMask Toggle, Grab;
    private Vector2 inputScreenPosition;
    private Finger currentFinger;
    public static InputManager instance
    {
        get;
        private set;
    }

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
    }

    private void OnEnable()
    {
        playerControlInputs = new Control();

        gameplayActions.Enable();
        gameplayActions.Click.performed += OnClickPointer;
        gameplayActions.MousePosition.performed += MousePositionRecord;
        if (!Application.isMobilePlatform)
            return;
        EnhancedTouchSupport.Enable();
#if UNITY_EDITOR
        TouchSimulation.Enable();
#endif
        Touch.onFingerDown += TocuhStart;
        Touch.onFingerUp += TouchEnd;
    }
    private void OnDisable()
    {
        gameplayActions.Click.performed -= OnClickPointer;
        gameplayActions.MousePosition.performed -= MousePositionRecord;

        if (!Application.isMobilePlatform)
            return;
        Touch.onFingerDown -= TocuhStart;
        Touch.onFingerUp -= TouchEnd;
        gameplayActions.Disable();
    }
    private void TocuhStart(Finger finger)
    {
        if (isPressed)
            return;
        isPressed = true;
        currentFinger = finger;

        inputScreenPosition = finger.screenPosition;
        StartInteraction();
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
    }
    private void OnClickPointer(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isPressed = true;
        }
        else if(context.canceled)
        {
            isPressed = false;
        }
        StartInteraction();
    }
    private void MousePositionRecord(InputAction.CallbackContext context)
    {
        if (!Application.isMobilePlatform)
            inputScreenPosition = context.ReadValue<Vector2>();
    }
    private void StartInteraction()
    {
        Ray ray = Camera.main.ScreenPointToRay(inputScreenPosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (Misc.IsInLayerMask(hit.collider.gameObject.layer, Toggle))
            {
                hit.collider.gameObject.GetComponentInParent<ToggleFan>().Toggle();
            }
            else if (Misc.IsInLayerMask(hit.collider.gameObject.layer, Grab))
            {

            }
        }
    }
}