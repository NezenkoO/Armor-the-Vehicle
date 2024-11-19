using Core.State;

namespace GamePlay.GameStates
{
    public class GameStateSwitcher : StateSwitcher
    {
        private void Start()
        {
            SwitchState<GameSetupState>();
        }
    }
}
