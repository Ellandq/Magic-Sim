using System.Collections.Generic;
using GameStates;

public class GameManager : ManagerBase<GameManager>
{
    private (GameStateStatus status, IGameState state) _currentState;
    
    private void Start()
    {
        // ChangeState(new MainMenuState(this));
    }

    private void Update()
    {
        _currentState.state?.Update();
    }

    public void ChangeState(IGameState newState)
    {
        _currentState.state?.Exit();
        _currentState.state = newState;
        _currentState.state?.Enter();
    }

    // Optional: expose states for external use
    // public void StartGame() => ChangeState(new PlayingState(this));
    // public void PauseGame() => ChangeState(new PauseState(this));
    // public void ReturnToMenu() => ChangeState(new MainMenuState(this));
}
