using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Player.Movement.Camera
{
    public class PlayerCameraController : ManagerBase<PlayerCameraController>
    {
        [Header("Player Reference")] 
        [SerializeField] private Rigidbody playerBody;

        [Header("Camera Settings")] 
        [SerializeField] private float firstPersonCameraSensitivity = 80f;
        [SerializeField] private float thirdPersonCameraSensitivity = 80f;
        private Dictionary<CameraType, float> _sensitivities;

        [Header("Camera References")] 
        [SerializeField] private CameraType activeCamera;
        [SerializeField] private List<CameraController> cameras;
        private CameraController _activeCamera;
        private Dictionary<CameraType, CameraController> _cameras;

        #region Set Up

        protected override void Awake()
        {
            var cameraTypes = Enum.GetValues(typeof(CameraType))
                .Cast<CameraType>()
                .ToList();
            
            _sensitivities = cameraTypes
                .Zip(new[] { firstPersonCameraSensitivity, thirdPersonCameraSensitivity, 0f },
                    (type, sensitivity) => new { type, sensitivity })
                .ToDictionary(x => x.type, x => x.sensitivity);
            
            _cameras = cameraTypes
                .Zip(cameras, (type, controller) => new { type, controller })
                .ToDictionary(x => x.type, x => x.controller);
            
            base.Awake();
        }

        public void SetUp(CameraType cameraType)
        {
            activeCamera = cameraType;
            _cameras.Keys.ToList().ForEach(type =>
            {
                var state = type == cameraType ? CameraState.Active : CameraState.Inactive;
                var sensitivity = _sensitivities[type];
                _cameras[type].SetUpCamera(state, sensitivity);
            });
        }

        #endregion
        
        public void ChangeActiveCamera(CameraType cameraType)
        {
            activeCamera = cameraType;
            foreach (var kvp in _cameras)
            {
                kvp.Value.SetCameraState(kvp.Key == cameraType ? CameraState.Active : CameraState.Inactive);
            }
        }
        
        private void LateUpdate()
        {
            _cameras[activeCamera].Move();
        }
    }
}