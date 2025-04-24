using System;
using System.Collections.Generic;
using UnityEngine;

namespace Input
{
    public class KeyboardInput
    {
        [Header("Events")] 
        private Dictionary<string, Action<ButtonState>> _onInputAction;

        [Header("Key Information")] 
        private Dictionary<string, KeyCode> _buttonAssignment;
        private Dictionary<KeyCode, bool> _buttonStates;
    }
}