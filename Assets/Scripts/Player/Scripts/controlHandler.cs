using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlHandler : MonoBehaviour
{

    public enum inputState
    {
        Keyboard, XB1, PS4
    };
    public inputState state = inputState.Keyboard;

    void Update()
    {
        string[] names = Input.GetJoystickNames();
        switch (state)
        {
            case inputState.Keyboard:
                if (isControllerInput()) state = controllerType();
                break;

            case inputState.XB1:
                if (isKeyboardInput()) state = inputState.Keyboard;
                break;

            case inputState.PS4:
                if (isKeyboardInput()) state = inputState.Keyboard;
                break;
        }
    }

    private bool isKeyboardInput()
    {
        if (Event.current.isKey ||
            Event.current.isMouse) return true;
        if (Input.GetAxis("Mouse X") != 0.0f ||
            Input.GetAxis("Mouse Y") != 0.0f) return true;
        return false;
    }

    private bool isControllerInput()
    {
        if (Input.GetKey(KeyCode.Joystick1Button0) ||
           Input.GetKey(KeyCode.Joystick1Button1) ||
           Input.GetKey(KeyCode.Joystick1Button2) ||
           Input.GetKey(KeyCode.Joystick1Button3) ||
           Input.GetKey(KeyCode.Joystick1Button4) ||
           Input.GetKey(KeyCode.Joystick1Button5) ||
           Input.GetKey(KeyCode.Joystick1Button6) ||
           Input.GetKey(KeyCode.Joystick1Button7) ||
           Input.GetKey(KeyCode.Joystick1Button8) ||
           Input.GetKey(KeyCode.Joystick1Button9) ||
           Input.GetKey(KeyCode.Joystick1Button10) ||
           Input.GetKey(KeyCode.Joystick1Button11) ||
           Input.GetKey(KeyCode.Joystick1Button12) ||
           Input.GetKey(KeyCode.Joystick1Button13) ||
           Input.GetKey(KeyCode.Joystick1Button14) ||
           Input.GetKey(KeyCode.Joystick1Button15) ||
           Input.GetKey(KeyCode.Joystick1Button16) ||
           Input.GetKey(KeyCode.Joystick1Button17) ||
           Input.GetKey(KeyCode.Joystick1Button18) ||
           Input.GetKey(KeyCode.Joystick1Button19)) return true;

        if (Input.GetAxis("PS4 JOYSTICK X") != 0.0f ||
           Input.GetAxis("PS4 JOYSTICK X") != 0.0f ||
           Input.GetAxis("PS4 TRIGGER RIGHT") != 0.0f ||
           Input.GetAxis("XB1 JOYSTICK X") != 0.0f ||
           Input.GetAxis("XB1 JOYSTICK Y") != 0.0f ||
           Input.GetAxis("XB1 TRIGGER RIGHT") != 0.0f)
            return true;

        return false;
    }

    inputState controllerType()
    {
        int cType = 0;
        string[] names = Input.GetJoystickNames();
        for (int x = 0; x < names.Length; x++)
        {
            print(names[x].Length);
            if (names[x].Length == 19)
            {
                print("PS4 CONTROLLER IS CONNECTED");
                cType = 1;
            }
            if (names[x].Length == 33)
            {
                print("XBOX ONE CONTROLLER IS CONNECTED");
                cType = 2;
            }
        }


        if (cType == 1) return inputState.PS4;
        else if (cType == 2) return inputState.XB1;
        else return inputState.Keyboard;
    }
}
