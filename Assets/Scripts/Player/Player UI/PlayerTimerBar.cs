using System.Collections;
using TMPro;
using UnityEngine;
using YK;

namespace SG
{
    public class PlayerTimerBar : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _timerText;
        [SerializeField] private float _timeDuration = 60;

        private void Start()
        {
            StartCoroutine(StartTimer());    
        }

        private IEnumerator StartTimer()
        {
            float timer = _timeDuration;

            while (timer > 0)
            {
                //_timerText.text = "TIME: " + Mathf.Round(timer).ToString();
                _timerText.text = $"TIME: {Mathf.Round(timer)}";

                timer -= Time.deltaTime;

                yield return null;
            }

            TitleScreenAndGameModeManager.Instance.RestartGame();
        }
    }
}
