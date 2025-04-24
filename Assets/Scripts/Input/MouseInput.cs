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
        
        private void UpdateButtonStateDictionary () 
        {
            _buttonStates = new Dictionary<int, bool>();

            foreach (var button in _buttonAssignment){
                _buttonStates.Add(button.Value, false);
            }
        }

        private void UpdateEventDictionaries () 
        {
            _onInputAction = new Dictionary<string, Action<ButtonState>>();

            foreach (var tuple in InputManager.MouseButtons){
                _onInputAction.Add(tuple.action, (state) => {});
            }
        }
        
        public bool GetButtonState (int key){
            return _buttonStates[key];
        }
    }
}