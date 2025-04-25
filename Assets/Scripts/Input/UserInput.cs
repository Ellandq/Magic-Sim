﻿using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Input
{
    public class UserInput<T> : MonoBehaviour
    {
        [Header("Events")] 
        protected Dictionary<string, Action<ButtonState>> OnInputAction;

        [Header("Key Information")] 
        protected Dictionary<string, T> ButtonAssignment;
        protected Dictionary<T, bool> ButtonStates;
        
        protected void UpdateButtonStateDictionary () 
        {
            ButtonStates = new Dictionary<T, bool>();

            foreach (var button in ButtonAssignment){
                ButtonStates.Add(button.Value, false);
            }
        }

        protected void UpdateEventDictionaries () 
        {
            OnInputAction = new Dictionary<string, Action<ButtonState>>();

            foreach (var tuple in InputManager.MouseButtons){
                OnInputAction.Add(tuple.action, (state) => {});
            }
        }
        
        public bool GetButtonState (T key){
            return ButtonStates[key];
        }
        
        public bool GetButtonState (string action){
            return ButtonStates[ButtonAssignment[action]];
        }
    }
}