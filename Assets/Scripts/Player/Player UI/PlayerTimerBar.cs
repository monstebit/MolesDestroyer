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
                _timerText.text = "TIME: " + Mathf.Round(timer).ToString();

                timer -= Time.deltaTime;

                yield return null;
            }

            TitleScreenAndGameModeManager.Instance.RestartGame();
        }



        //[SerializeField] private float _remainingSeconds;
        //[SerializeField] private TextMeshProUGUI _timerText;

        //private void Start()
        //{
        //    _timerText.text = _remainingSeconds.ToString();
        //}

        //private void Update()
        //{
        //    if (_remainingSeconds > 0f)
        //    {
        //        _remainingSeconds -= Time.deltaTime;
        //        _timerText.text = "TIME: " + Mathf.Round(_remainingSeconds).ToString();
        //    }
        //    else
        //    {
        //        TitleScreenAndGameModeManager.Instance.RestartGame();
        //    }
        //}
    }
}
