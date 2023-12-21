using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YK
{
    public class GridAndMoleSpawnManager : MonoBehaviour
    {
        private List<Transform> _gridTransforms = new List<Transform>();

        [SerializeField] private GameObject _gridPrefab;
        [SerializeField] private List<GameObject> _molePrefab;

        //  TO DO: ADD CHECK FOR NULL
        [SerializeField] private int _rowValue = 3;
        [SerializeField] private int _columnValue = 3;

        [SerializeField] private int _moleAnount = 3;
        //  TO DO: FIX IT
        private float firstMoleSpawnTimer = 2f;
        private float restoreMoleSpawnPointTimer = 2.5f;

        private void Start()
        {
            SpawnGrid();
            StartCoroutine(FirstMoleSpawnAfterDelay());
        }

        private void SpawnGrid()
        {
            GameObject[,] grids = new GameObject[_rowValue, _columnValue];

            for (int i = 0; i < _rowValue; i++)
            {
                for (int j = 0; j < _columnValue; j++)
                {
                    GameObject gridInstance = Instantiate(_gridPrefab);

                    gridInstance.transform.position = new Vector3(i * 2.0f, 0, j * 2.0f);
                    _gridTransforms.Add(gridInstance.transform);

                    grids[i, j] = gridInstance;
                }
            }
        }

        //  TO DO: FIX IT
        private IEnumerator MolesSpawn()
        {
            // ожидаем 1 секунду
            yield return new WaitForSeconds(firstMoleSpawnTimer);

            for (int i = 0; i < _moleAnount; i++)
            {
                Transform randomSpawnPoint = GetRandomSpawnPoint();

                GameObject ramdomMole = GetRandomMole(_molePrefab);
                GameObject moleInstance = Instantiate(ramdomMole, randomSpawnPoint.position, randomSpawnPoint.rotation);

                //  DISAPPEARANCE TIME
                Enemy newMoplecomponent = moleInstance.GetComponent<Enemy>();   //  UPCASTING
                float newMoleDisappearanceTime = newMoplecomponent.DisappearanceTime;

                //  DELETE LAST MOLE SPAWN POINT
                _gridTransforms.Remove(randomSpawnPoint);

                StartCoroutine(DestroyMoleAfterDelay(moleInstance, newMoleDisappearanceTime));
                StartCoroutine(RestoreSpawnPointAfterDelay(randomSpawnPoint));
            }
        }

        //  TO DO: FIX IT
        private IEnumerator FirstMoleSpawnAfterDelay()
        {
            while (true)
            {
                StartCoroutine(MolesSpawn());
                yield return new WaitForSeconds(firstMoleSpawnTimer);
            }
        }

        private IEnumerator DestroyMoleAfterDelay(GameObject mole, float destroyTime)
        {
            yield return new WaitForSeconds(destroyTime);

            // Удаляем префаб после задержки, но только если он был создан
            if (mole != null)
            {
                //  PLAYER DAMAGED EVENT
                Enemy newMoplecomponent = mole.GetComponent<Enemy>();   //  UPCASTING
                EventManager.OnPlayerDied(newMoplecomponent.MaxHealth);

                Destroy(mole);
            }
        }

        private IEnumerator RestoreSpawnPointAfterDelay(Transform spawnPoint)
        {
            yield return new WaitForSeconds(restoreMoleSpawnPointTimer);

            // Добавляем точку обратно в список
            _gridTransforms.Add(spawnPoint);
        }

        private Transform GetRandomSpawnPoint()
        {
            int randomIndex = Random.Range(0, _gridTransforms.Count);
            Transform randomTransform = _gridTransforms[randomIndex]; 

            return randomTransform;
        }

        private GameObject GetRandomMole(List<GameObject> moles)
        {
            if (moles == null || moles.Count == 0)
            {
                Debug.LogWarning("The list of moles is empty or null.");
                return null;
            }

            int randomIndex = Random.Range(0, moles.Count);
            return moles[randomIndex];
        }
    }
}
