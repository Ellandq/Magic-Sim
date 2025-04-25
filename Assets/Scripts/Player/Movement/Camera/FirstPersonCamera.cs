using UnityEngine;

namespace Player.Movement.Camera
{
    public class FirstPersonCamera : CameraController
    {
        [SerializeField] private Rigidbody playerBody;
        [SerializeField] private Transform cameraRoot;
        [SerializeField] private Transform cameraFollowObject;

        public override void SetUpCamera(CameraState state, float sensitivity)
        {
            base.SetUpCamera(state, sensitivity);
            
            camera.cullingMask &= ~(1 << LayerMask.NameToLayer("FirstPerson"));

            OnActivate = () =>
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            };
            
            OnEnable = () =>
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = true;
            };
            
            OnDisable = () =>
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            };
        }

        public override void Move()
        {
            transform.position = cameraRoot.position;
            if (!CameraState.Equals(CameraState.ActiveAndEnabled)) return;
        
            var mouseX = UnityEngine.Input.GetAxis("Mouse X") * Sensitivity * Time.deltaTime;
            var mouseY = UnityEngine.Input.GetAxis("Mouse Y") * Sensitivity * Time.deltaTime;
        
            var forwardPoint = transform.position + transform.forward * 3.0f;
            cameraFollowObject.position = forwardPoint;

            XRotation -= mouseY;
            XRotation = Mathf.Clamp(XRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(XRotation, 0f, 0f);
            playerBody.MoveRotation(playerBody.rotation * Quaternion.Euler(0f, mouseX, 0f));
        }
    }
}