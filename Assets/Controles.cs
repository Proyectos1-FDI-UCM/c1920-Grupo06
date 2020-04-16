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
                },
                {
                    ""name"": ""Gancho"",
                    ""type"": ""Button"",
                    ""id"": ""6087f9c6-fe30-4738-885a-7838659b7a2c"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ApuntarGancho"",
                    ""type"": ""Button"",
                    ""id"": ""70d4029f-3778-4f29-afe0-7172243f7253"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Salto"",
                    ""type"": ""Button"",
                    ""id"": ""75ab45d1-c645-4908-961e-67fe67312b4b"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Apuntar Dash"",
                    ""type"": ""Button"",
                    ""id"": ""bffb5ae8-ae93-41f7-98e9-9797b605941e"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pausa"",
                    ""type"": ""Button"",
                    ""id"": ""c2e357d2-1452-4c36-8427-080742a3b6ec"",
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
                },
                {
                    ""name"": """",
                    ""id"": ""8150b380-10e8-460f-b285-f36b3d4eb554"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Teclado Y Raton"",
                    ""action"": ""Gancho"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6c8f75ff-6de7-47bf-b440-703b057e17ec"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Teclado Y Raton"",
                    ""action"": ""Gancho"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6f7593f5-0c92-4f84-9e4d-81901d3b1e0b"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Teclado Y Raton"",
                    ""action"": ""Salto"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f5c7f450-025f-4939-8351-5e6514af5691"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Teclado Y Raton"",
                    ""action"": ""Salto"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cfaa0c24-e295-4d79-8620-be25a15fa804"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Apuntar Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""041ae5e7-a786-4631-b21f-f0870fdcf6f1"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Teclado Y Raton"",
                    ""action"": ""Pausa"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fbf62d86-00d7-441c-a894-5a4d5282e9d8"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Teclado Y Raton"",
                    ""action"": ""ApuntarGancho"",
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
        m_Jugador_Gancho = m_Jugador.FindAction("Gancho", throwIfNotFound: true);
        m_Jugador_ApuntarGancho = m_Jugador.FindAction("ApuntarGancho", throwIfNotFound: true);
        m_Jugador_Salto = m_Jugador.FindAction("Salto", throwIfNotFound: true);
        m_Jugador_ApuntarDash = m_Jugador.FindAction("Apuntar Dash", throwIfNotFound: true);
        m_Jugador_Pausa = m_Jugador.FindAction("Pausa", throwIfNotFound: true);
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
    private readonly InputAction m_Jugador_Gancho;
    private readonly InputAction m_Jugador_ApuntarGancho;
    private readonly InputAction m_Jugador_Salto;
    private readonly InputAction m_Jugador_ApuntarDash;
    private readonly InputAction m_Jugador_Pausa;
    public struct JugadorActions
    {
        private @Controles m_Wrapper;
        public JugadorActions(@Controles wrapper) { m_Wrapper = wrapper; }
        public InputAction @Dash => m_Wrapper.m_Jugador_Dash;
        public InputAction @Gancho => m_Wrapper.m_Jugador_Gancho;
        public InputAction @ApuntarGancho => m_Wrapper.m_Jugador_ApuntarGancho;
        public InputAction @Salto => m_Wrapper.m_Jugador_Salto;
        public InputAction @ApuntarDash => m_Wrapper.m_Jugador_ApuntarDash;
        public InputAction @Pausa => m_Wrapper.m_Jugador_Pausa;
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
                @Gancho.started -= m_Wrapper.m_JugadorActionsCallbackInterface.OnGancho;
                @Gancho.performed -= m_Wrapper.m_JugadorActionsCallbackInterface.OnGancho;
                @Gancho.canceled -= m_Wrapper.m_JugadorActionsCallbackInterface.OnGancho;
                @ApuntarGancho.started -= m_Wrapper.m_JugadorActionsCallbackInterface.OnApuntarGancho;
                @ApuntarGancho.performed -= m_Wrapper.m_JugadorActionsCallbackInterface.OnApuntarGancho;
                @ApuntarGancho.canceled -= m_Wrapper.m_JugadorActionsCallbackInterface.OnApuntarGancho;
                @Salto.started -= m_Wrapper.m_JugadorActionsCallbackInterface.OnSalto;
                @Salto.performed -= m_Wrapper.m_JugadorActionsCallbackInterface.OnSalto;
                @Salto.canceled -= m_Wrapper.m_JugadorActionsCallbackInterface.OnSalto;
                @ApuntarDash.started -= m_Wrapper.m_JugadorActionsCallbackInterface.OnApuntarDash;
                @ApuntarDash.performed -= m_Wrapper.m_JugadorActionsCallbackInterface.OnApuntarDash;
                @ApuntarDash.canceled -= m_Wrapper.m_JugadorActionsCallbackInterface.OnApuntarDash;
                @Pausa.started -= m_Wrapper.m_JugadorActionsCallbackInterface.OnPausa;
                @Pausa.performed -= m_Wrapper.m_JugadorActionsCallbackInterface.OnPausa;
                @Pausa.canceled -= m_Wrapper.m_JugadorActionsCallbackInterface.OnPausa;
            }
            m_Wrapper.m_JugadorActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
                @Gancho.started += instance.OnGancho;
                @Gancho.performed += instance.OnGancho;
                @Gancho.canceled += instance.OnGancho;
                @ApuntarGancho.started += instance.OnApuntarGancho;
                @ApuntarGancho.performed += instance.OnApuntarGancho;
                @ApuntarGancho.canceled += instance.OnApuntarGancho;
                @Salto.started += instance.OnSalto;
                @Salto.performed += instance.OnSalto;
                @Salto.canceled += instance.OnSalto;
                @ApuntarDash.started += instance.OnApuntarDash;
                @ApuntarDash.performed += instance.OnApuntarDash;
                @ApuntarDash.canceled += instance.OnApuntarDash;
                @Pausa.started += instance.OnPausa;
                @Pausa.performed += instance.OnPausa;
                @Pausa.canceled += instance.OnPausa;
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
        void OnGancho(InputAction.CallbackContext context);
        void OnApuntarGancho(InputAction.CallbackContext context);
        void OnSalto(InputAction.CallbackContext context);
        void OnApuntarDash(InputAction.CallbackContext context);
        void OnPausa(InputAction.CallbackContext context);
    }
}
