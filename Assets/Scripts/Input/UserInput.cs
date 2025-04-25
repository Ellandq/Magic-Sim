using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Input
{
    public class UserInput<T> : MonoBehaviour
    {
        [Header("Events")] 
        protected Dictionary<string, Action<ButtonState>> _onInputAction;

        [Header("Key Information")] 
        protected Dictionary<string, T> _buttonAssignment;
        protected Dictionary<T, bool> _buttonStates;
        
        protected void UpdateButtonStateDictionary () 
        {
            _buttonStates = new Dictionary<T, bool>();

            foreach (var button in _buttonAssignment){
                _buttonStates.Add(button.Value, false);
            }
        }

        protected void UpdateEventDictionaries () 
        {
            _onInputAction = new Dictionary<string, Action<ButtonState>>();

            foreach (var tuple in InputManager.MouseButtons){
                _onInputAction.Add(tuple.action, (state) => {});
            }
        }
        
        public bool GetButtonState (T key){
            return _buttonStates[key];
        }
        
        public bool GetButtonState (string action){
            return _buttonStates[_buttonAssignment[action]];
        }
    }
}