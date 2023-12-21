using TMPro;
using UnityEngine;
using YK;

namespace SG
{
    public class PlayerTimerBar : MonoBehaviour
    {
        [SerializeField] private float _remainingSeconds;
        [SerializeField] private TextMeshProUGUI _timerText;

        private void Start()
        {
            _timerText.text = _remainingSeconds.ToString();
        }

        private void Update()
        {
            if (_remainingSeconds > 0f)
            {
                _remainingSeconds -= Time.deltaTime;
                _timerText.text = "TIME: " + Mathf.Round(_remainingSeconds).ToString();
            }
            else
            {
                TitleScreenAndGameModeManager.Instance.RestartGame();
            }
        }
    }
}
