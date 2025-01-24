//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.11.2
//     from Assets/Scripts/Input/Control.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @Control: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Control()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Control"",
    ""maps"": [
        {
            ""name"": ""GameplayInputs"",
            ""id"": ""3dc18d12-3f30-4e7f-b778-677ca7c82747"",
            ""actions"": [
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""Value"",
                    ""id"": ""f5d9190f-83d1-4d2b-912c-94afb6df67e5"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Click"",
                    ""type"": ""Button"",
                    ""id"": ""b9da93f6-fd06-4b6c-89c0-1bb924069336"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""1d48dfbc-311e-4c81-8dfa-c5bf21b024be"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4ceaef2e-d85a-455b-ac4d-8ef5fd1f6faa"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // GameplayInputs
        m_GameplayInputs = asset.FindActionMap("GameplayInputs", throwIfNotFound: true);
        m_GameplayInputs_MousePosition = m_GameplayInputs.FindAction("MousePosition", throwIfNotFound: true);
        m_GameplayInputs_Click = m_GameplayInputs.FindAction("Click", throwIfNotFound: true);
    }

    ~@Control()
    {
        UnityEngine.Debug.Assert(!m_GameplayInputs.enabled, "This will cause a leak and performance issues, Control.GameplayInputs.Disable() has not been called.");
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // GameplayInputs
    private readonly InputActionMap m_GameplayInputs;
    private List<IGameplayInputsActions> m_GameplayInputsActionsCallbackInterfaces = new List<IGameplayInputsActions>();
    private readonly InputAction m_GameplayInputs_MousePosition;
    private readonly InputAction m_GameplayInputs_Click;
    public struct GameplayInputsActions
    {
        private @Control m_Wrapper;
        public GameplayInputsActions(@Control wrapper) { m_Wrapper = wrapper; }
        public InputAction @MousePosition => m_Wrapper.m_GameplayInputs_MousePosition;
        public InputAction @Click => m_Wrapper.m_GameplayInputs_Click;
        public InputActionMap Get() { return m_Wrapper.m_GameplayInputs; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayInputsActions set) { return set.Get(); }
        public void AddCallbacks(IGameplayInputsActions instance)
        {
            if (instance == null || m_Wrapper.m_GameplayInputsActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_GameplayInputsActionsCallbackInterfaces.Add(instance);
            @MousePosition.started += instance.OnMousePosition;
            @MousePosition.performed += instance.OnMousePosition;
            @MousePosition.canceled += instance.OnMousePosition;
            @Click.started += instance.OnClick;
            @Click.performed += instance.OnClick;
            @Click.canceled += instance.OnClick;
        }

        private void UnregisterCallbacks(IGameplayInputsActions instance)
        {
            @MousePosition.started -= instance.OnMousePosition;
            @MousePosition.performed -= instance.OnMousePosition;
            @MousePosition.canceled -= instance.OnMousePosition;
            @Click.started -= instance.OnClick;
            @Click.performed -= instance.OnClick;
            @Click.canceled -= instance.OnClick;
        }

        public void RemoveCallbacks(IGameplayInputsActions instance)
        {
            if (m_Wrapper.m_GameplayInputsActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IGameplayInputsActions instance)
        {
            foreach (var item in m_Wrapper.m_GameplayInputsActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_GameplayInputsActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public GameplayInputsActions @GameplayInputs => new GameplayInputsActions(this);
    public interface IGameplayInputsActions
    {
        void OnMousePosition(InputAction.CallbackContext context);
        void OnClick(InputAction.CallbackContext context);
    }
}
