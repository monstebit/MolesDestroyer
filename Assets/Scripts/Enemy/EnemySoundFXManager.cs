using UnityEngine;

namespace YK
{
    public class EnemySoundFXManager : MonoBehaviour
    {
        private AudioSource audioSource;
        [HideInInspector] private EnemyEventManager _enemyEventManager;

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
            _enemyEventManager = GetComponent<EnemyEventManager>();
        }

        public void PlayDestroySoundFX()
        {
            audioSource.PlayOneShot(WorldSoundFXManager.instance.destroyEnemySFX);
        }
    }
}
