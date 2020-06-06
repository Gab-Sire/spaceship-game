using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class ControlInputField : MonoBehaviour
{
    InputField inputField;
    string controlName;

    void Start()
    {
        inputField = GetComponent<InputField>();
        // map input field names to the Controlsmanager inputs names
        controlName = name.Substring(name.IndexOf('_') + 1);
    }

    void Update()
    {
    }

    void OnGUI()
    {
        Event e = Event.current;
        if (e.isKey)
        {
            if (inputField != null && inputField.isFocused)
            {
                // display text in input field
                inputField.text = e.keyCode.ToString().ToUpper();

                // bind new key for the designated move
                if (e.keyCode != KeyCode.None)
                {
                    ControlsManager.Inputs[controlName] = e.keyCode;
                    Debug.Log("KeyCode effective in ControlsManager: " + ControlsManager.Inputs[controlName]);
                }   
            }
        }
    }

    public void Mouse(BaseEventData eventData)
    {
        PointerEventData pointerEventData = (PointerEventData) eventData;

        if (inputField != null && inputField.isFocused)
        {
            inputField.text = pointerEventData.button.ToString().ToUpper();

            // map main mouse keycodes by hand
            if ((KeyCode)pointerEventData.button != KeyCode.None)
            {
                if (pointerEventData.button.ToString().Equals("Left", StringComparison.OrdinalIgnoreCase))
                {
                    ControlsManager.Inputs[controlName] = KeyCode.Mouse0;
                }
                else if (pointerEventData.button.ToString().Equals("Right", StringComparison.OrdinalIgnoreCase))
                {
                    ControlsManager.Inputs[controlName] = KeyCode.Mouse1;
                }
                else if (pointerEventData.button.ToString().Equals("Middle", StringComparison.OrdinalIgnoreCase))
                {
                    ControlsManager.Inputs[controlName] = KeyCode.Mouse2;
                }
                Debug.Log("KeyCode effective in ControlsManager: " + ControlsManager.Inputs[controlName]);
            }
        }
    }

}
