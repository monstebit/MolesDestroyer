using UnityEngine;

namespace YK
{
    public class WorldSoundFXManager : MonoBehaviour
    {
        public static WorldSoundFXManager instance;

        private AudioSource _audioSource;

        [Header("Action Sounds")]
        public AudioClip destroyEnemySFX;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();

            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            EnemyEventManager.EnemyDiedSoundFX += Died;

            DontDestroyOnLoad(gameObject);
        }

        private void OnDisable()
        {
            EnemyEventManager.EnemyDiedSoundFX -= Died;
        }

        void Died()
        {
            _audioSource.PlayOneShot(WorldSoundFXManager.instance.destroyEnemySFX);
        }
    }
}
