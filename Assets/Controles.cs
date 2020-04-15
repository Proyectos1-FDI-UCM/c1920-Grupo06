// GENERATED AUTOMATICALLY FROM 'Assets/Controles.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Controles : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controles()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controles"",
    ""maps"": [
        {
            ""name"": ""Jugador"",
            ""id"": ""4bd3f03f-08e6-4f35-bfd6-c0966330fa1d"",
            ""actions"": [
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""bc4c2453-459b-44a4-b681-f49cd135c9e7"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e859bd55-2cad-4e06-a240-2a6d0f6511fe"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Teclado Y Raton"",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a08b96ac-6e9e-4829-9bdd-a02f8b4d69a3"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Teclado Y Raton"",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Teclado Y Raton"",
            ""bindingGroup"": ""Teclado Y Raton"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Jugador
        m_Jugador = asset.FindActionMap("Jugador", throwIfNotFound: true);
        m_Jugador_Dash = m_Jugador.FindAction("Dash", throwIfNotFound: true);
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

    // Jugador
    private readonly InputActionMap m_Jugador;
    private IJugadorActions m_JugadorActionsCallbackInterface;
    private readonly InputAction m_Jugador_Dash;
    public struct JugadorActions
    {
        private @Controles m_Wrapper;
        public JugadorActions(@Controles wrapper) { m_Wrapper = wrapper; }
        public InputAction @Dash => m_Wrapper.m_Jugador_Dash;
        public InputActionMap Get() { return m_Wrapper.m_Jugador; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(JugadorActions set) { return set.Get(); }
        public void SetCallbacks(IJugadorActions instance)
        {
            if (m_Wrapper.m_JugadorActionsCallbackInterface != null)
            {
                @Dash.started -= m_Wrapper.m_JugadorActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_JugadorActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_JugadorActionsCallbackInterface.OnDash;
            }
            m_Wrapper.m_JugadorActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
            }
        }
    }
    public JugadorActions @Jugador => new JugadorActions(this);
    private int m_TecladoYRatonSchemeIndex = -1;
    public InputControlScheme TecladoYRatonScheme
    {
        get
        {
            if (m_TecladoYRatonSchemeIndex == -1) m_TecladoYRatonSchemeIndex = asset.FindControlSchemeIndex("Teclado Y Raton");
            return asset.controlSchemes[m_TecladoYRatonSchemeIndex];
        }
    }
    public interface IJugadorActions
    {
        void OnDash(InputAction.CallbackContext context);
    }
}
