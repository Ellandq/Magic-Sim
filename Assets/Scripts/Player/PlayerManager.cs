using Player.Movement.Camera;
using UnityEngine;

namespace Player
{
    public class PlayerManager : ManagerBase<PlayerManager>
    {
        [Header("Object References")] 
        [SerializeField] private PlayerCameraController _cameraController;

        public PlayerCameraController GetPlayerCameraController()
        {
            return _cameraController;
        }
    }
}