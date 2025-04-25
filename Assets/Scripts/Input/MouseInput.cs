using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Input
{
    public class MouseInput : UserInput<int>
    {
        private void Awake()
        {
            _buttonStates = new Dictionary<int, bool>();
            _buttonAssignment = InputManager.MouseButtons
                .Select(n => new KeyValuePair<string, int>(n.action, n.button))
                .ToDictionary(pair => pair.Key, pair => pair.Value);

            UpdateButtonStateDictionary();
            UpdateEventDictionaries();
        }
        
        private void Update ()
        {
            foreach (var button in _buttonAssignment)
            {
                var previousState = _buttonStates[button.Value];

                _buttonStates[button.Value] = UnityEngine.Input.GetMouseButton(button.Value);

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