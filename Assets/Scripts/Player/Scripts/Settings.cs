using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Settings
{
      //-------------------//
     // PRIVATE VARIABLES //
    //-------------------//

        // BOOLEANS
    private static bool showFPS = false;

        // INTEGERS
    private static float volume = 1;
    private static int sensitivity = 10;

      //------------------//
     // PUBLIC VARIABLES //
    //------------------//


        //BOOLEANS
    public static bool ShowFPS
    {
        get
        {
            return showFPS;
        }
        set
        {
            showFPS = value;
        }
    }

        // INTEGERS
    public static float Volume
    {
        get
        {
            return volume;
        }
        set
        {
            volume = value;
        }
    }
    public static int Sensitivity
    {
        get
        {
            return sensitivity;
        }
        set
        {
            sensitivity = value;
        }
    }
}
