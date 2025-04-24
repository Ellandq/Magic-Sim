using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Input
{
    public class MouseInput : MonoBehaviour
    {
        [Header("Events")] 
        private Dictionary<string, Action<ButtonState>> _onInputAction;

        [Header("Key Information")] 
        private Dictionary<string, int> _buttonAssignment;
        private Dictionary<int, bool> _buttonStates;

        private void Awake()
        {
            _buttonStates = new Dictionary<int, bool>();
            _buttonAssignment = InputManager.MouseButtons
                .Select(n => new KeyValuePair<string, int>(n.action, n.button))
                .ToDictionary(pair => pair.Key, pair => pair.Value);

            UpdateButtonStateDictionary();
            UpdateEventDictionaries();
        }
    }
}