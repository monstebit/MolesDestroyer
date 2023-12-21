using UnityEngine;

namespace YK
{
    public class GameModeManager : MonoBehaviour
    {
        public GameMode currentGameMode;

        public GameMode SelectHealthMode()
        {
            currentGameMode = GameMode.HealthGameMode;
            return currentGameMode;
        }

        public GameMode SelectTimerMode()
        {
            currentGameMode = GameMode.TimerGameMode;
            return currentGameMode;
        }
    }
}
