using Player;
using UnityEngine;
using CameraType = Player.Movement.Camera.CameraType;

namespace GameStates
{
    public class PlayingState : IGameState
    {
        string IGameState.Name
        {
            get => "Playing";
        }

        public GameStateStatus Status { get; private set; }
        
        public void Enter()
        {
            Status = GameStateStatus.Entering;

            var camController = PlayerManager.Instance.GetPlayerCameraController();
            camController.SetUp(CameraType.FirstPerson); // TODO this should be set up with the saved camera
            camController.EnableCurrentCamera();
            
            Status = GameStateStatus.Active;
        }

        public void Update()
        {
            // TODO
        }

        public void Exit()
        {
            Status = GameStateStatus.Exiting;
            // TODO
            Status = GameStateStatus.Done;
        }

        public bool CanExit()
        {
            return Status == GameStateStatus.Done;
        }
    }
}