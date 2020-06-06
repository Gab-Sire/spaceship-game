using UnityEngine;
using System.Collections.Generic;

public class ControlsManager
{
    public static Dictionary<string, KeyCode> Inputs { get; set; } = new Dictionary<string, KeyCode>
    {
        { "Up", KeyCode.W },
        { "Down", KeyCode.S },
        { "Left", KeyCode.A },
        { "Right", KeyCode.D },
        { "MG_Left", KeyCode.LeftArrow },
        { "MG_Right", KeyCode.RightArrow },
        { "Fire", KeyCode.Z },
        { "Missile", KeyCode.Mouse0 }
    };
}
