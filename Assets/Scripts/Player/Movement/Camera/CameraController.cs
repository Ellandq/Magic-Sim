using System;
using UnityEngine;

namespace Player.Movement.Camera
{
    public abstract class CameraController : MonoBehaviour
    {
        [Header("Object References")] 
        [SerializeField] protected UnityEngine.Camera camera;
        
        [Header("Misc.")]
        protected CameraState CameraState = CameraState.Disabled;
        protected float Sensitivity;
        protected float XRotation;
        
        [Header("State Switch Actions")]
        protected Action OnActivate;
        protected Action OnEnable;
        protected Action OnDisable;

        public virtual void SetUpCamera(CameraState state, float sensitivity)
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
                    OnActivate?.Invoke();
                    break;
                case CameraState.Enabled:
                    OnEnable?.Invoke();
                    break;
                case CameraState.Disabled:
                    OnDisable?.Invoke();
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