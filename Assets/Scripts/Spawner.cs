using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YK
{
    public class Spawner : MonoBehaviour
    {
        private List<Transform> gridTransforms = new List<Transform>();

        [SerializeField] private GameObject gridPrefab;
        [SerializeField] private List<GameObject> molePrefabs;

        //  TO DO: ADD CHECK FOR NULL
        [SerializeField] private int rows = 3;
        [SerializeField] private int columns = 3;

        private int numberOfMoles = 3;

        private float firstMoleSpawnTimer = 2f;
        private float restoreMoleSpawnPointTimer = 2.5f;

        private void Start()
        {
            SpawnGrid();
            StartCoroutine(FirstMoleSpawnAfterDelay());
        }

        private void SpawnGrid()
        {
            GameObject[,] grids = new GameObject[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    GameObject gridInstance = Instantiate(gridPrefab);

                    gridInstance.transform.position = new Vector3(i * 2.0f, 0, j * 2.0f);
                    gridTransforms.Add(gridInstance.transform);

                    grids[i, j] = gridInstance;
                }
            }
        }

        //  TO DO: FIX IT
        private IEnumerator MolesSpawn()
        {
            // ожидаем 1 секунду
            yield return new WaitForSeconds(firstMoleSpawnTimer);

            for (int i = 0; i < numberOfMoles; i++)
            {
                Transform randomSpawnPoint = GetRandomSpawnPoint();

                GameObject ramdomMole = GetRandomMole(molePrefabs);
                GameObject moleInstance = Instantiate(ramdomMole, randomSpawnPoint.position, randomSpawnPoint.rotation);

                //  DISAPPEARANCE TIME
                Enemy newMoplecomponent = moleInstance.GetComponent<Enemy>();   //  UPCASTING
                float newMoleDisappearanceTime = newMoplecomponent.DisappearanceTime;

                //  DELETE LAST MOLE SPAWN POINT
                gridTransforms.Remove(randomSpawnPoint);

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

        private IEnumerator DestroyMoleAfterDelay(GameObject mole, float destoyTime)
        {
            yield return new WaitForSeconds(destoyTime);

            // Удаляем префаб после задержки, но только если он был создан
            if (mole != null)
            {
                Destroy(mole);
            }
        }

        private IEnumerator RestoreSpawnPointAfterDelay(Transform spawnPoint)
        {
            yield return new WaitForSeconds(restoreMoleSpawnPointTimer);

            // Добавляем точку обратно в список
            gridTransforms.Add(spawnPoint);
        }

        private Transform GetRandomSpawnPoint()
        {
            int randomIndex = Random.Range(0, gridTransforms.Count);
            Transform randomTransform = gridTransforms[randomIndex]; 

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
