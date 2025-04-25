using System;
using UnityEngine;

namespace Player.Movement.Camera
{
    public abstract class CameraController : MonoBehaviour
    {
        [Header("Misc.")]
        protected CameraState CameraState = CameraState.Inactive;
        protected float Sensitivity;
        protected float XRotation; 

        public void SetUpCamera(CameraState state, float sensitivity)
        {
            SetCameraState(state);
            Sensitivity = sensitivity;
        }
        
        public void SetCameraState(CameraState state)
        {
            CameraState = state;

            switch (CameraState)
            {
                case CameraState.ActiveAndEnabled:
                    break;
                case CameraState.Active:
                    break;
                case CameraState.Inactive:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public virtual void Move()
        {
            throw new NotImplementedException();
        }
    }
}