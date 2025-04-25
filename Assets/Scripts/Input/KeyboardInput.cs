using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Input
{
    public class KeyboardInput :  UserInput<KeyCode>
    {
        private void Awake()
        {
            _buttonStates = new Dictionary<KeyCode, bool>();
            _buttonAssignment = InputManager.KeyboardButtons
                .Select(n => new KeyValuePair<string, KeyCode>(n.action, n.button))
                .ToDictionary(pair => pair.Key, pair => pair.Value);

            UpdateButtonStateDictionary();
            UpdateEventDictionaries();
        }
        
        private void Update ()
        {
            foreach (var button in _buttonAssignment)
            {
                var previousState = _buttonStates[button.Value];

                _buttonStates[button.Value] = UnityEngine.Input.GetKey(button.Value);

                switch (_buttonStates[button.Value])
                {
                    case true when !previousState:
                        _onInputAction[button.Key]?.Invoke(ButtonState.Down);
                        break;
                    case false when previousState:
                        _onInputAction[button.Key]?.Invoke(ButtonState.Up);
                        break;
                }
            }
        } 
    }
}