using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace YK
{
    public class GridsAndMolesSpawnManager : MonoBehaviour
    {
        public CinemachineTargetGroup targetGroup; // Ссылка на CinemachineTargetGroup

        [SerializeField] private float scaleChangeSpeed = 1f;

        [Header("Player Health Bar")]
        [SerializeField] private PlayerHealthBar _healthBar;

        [Header("Prefab")]
        [SerializeField] private GameObject _grid;
        [SerializeField] private List<GameObject> _mole;
        [SerializeField] private GameObject _cube;

        [Header("Grid")]
        //  TO DO: ADD CHECK FOR NULL
        public List<Transform> GridTransforms = new List<Transform>();
        [SerializeField] private int _rowValue = 3;
        [SerializeField] private int _columnValue = 3;

        [Header("Mole")]
        [SerializeField] private int _moleAnount = 3;

        [Header("Coroutine Time")]
        private float _moleSpawnTimer = 1.0f;

        private void Start()
        {
            SpawnGrids();
            StartCoroutine(SpawnMoles());
        }

        private void SpawnGrids()
        {
            GameObject[,] grids = new GameObject[_rowValue, _columnValue];

            for (int i = 0; i < _rowValue; i++)
            {
                if (i == 0)
                {
                    //  FIRST TARGET FOR CINEMACHINE
                    GameObject firstCubeInstance = Instantiate(_cube);
                    firstCubeInstance.transform.position = new Vector3(0, 0, 0);
                    firstCubeInstance.SetActive(false);

                    // Добавляем созданный объект в CinemachineTargetGroup
                    targetGroup.AddMember(firstCubeInstance.transform, 1.0f, 0);
                }

                for (int j = 0; j < _columnValue; j++)
                {
                    GameObject gridInstance = Instantiate(_grid);

                    gridInstance.transform.position = new Vector3(i * 2.0f, 0, j * 2.0f);
                    GridTransforms.Add(gridInstance.transform);

                    grids[i, j] = gridInstance;
                }
            }

            //  SECOND TARGET FOR CINEMACHINE
            GameObject secondCubeInstance = Instantiate(_cube);
            secondCubeInstance.SetActive(false);

            Transform lastTransform = GridTransforms[GridTransforms.Count - 1];
            Vector3 lastTransformPosition = lastTransform.position;

            secondCubeInstance.transform.position = lastTransformPosition;

            // Добавляем созданный объект в CinemachineTargetGroup
            targetGroup.AddMember(secondCubeInstance.transform, 1.0f, 0);
        }

        private GameObject GetRandomMole(List<GameObject> moles)
        {
            if (moles == null)
                throw new ArgumentNullException(nameof(moles), "The 'moles' list cannot be null.");


            if (moles.Count == 0)
                throw new ArgumentException("The 'moles' list cannot be empty.", nameof(moles));


            int randomIndex = Random.Range(0, moles.Count);
            return moles[randomIndex];
        }

        private Transform GetRandomSpawnPoint()
        {
            int randomIndex = Random.Range(0, GridTransforms.Count);
            Transform randomTransform = GridTransforms[randomIndex]; 

            return randomTransform;
        }

        //  COROUTINES
        private IEnumerator SpawnMoles()
        {
            while (true)
            {
                yield return new WaitForSeconds(_moleSpawnTimer);

                for (int i = 0; i < _moleAnount; i++)
                {
                    if (GridTransforms.Count != 0)
                    {
                        Transform randomSpawnPoint = GetRandomSpawnPoint();

                        Quaternion rotation = Quaternion.Euler(0f, 180f, 0f);
                        GameObject ramdomMole = GetRandomMole(_mole);
                        GameObject moleInstance = Instantiate(ramdomMole, randomSpawnPoint.position, rotation);

                        //  SCALE OVER TIME
                        moleInstance.transform.localScale = Vector3.zero;
                        StartCoroutine(ScaleOverTime(moleInstance));

                        //  GET ENEMY DISAPPEARANCE TIME
                        Enemy newMoplecomponent = moleInstance.GetComponent<Enemy>();   //  UPCASTING
                        float newMoleDisappearanceTime = newMoplecomponent.DisappearanceTime;

                        //  DELETE LAST MOLE SPAWN POINT
                        GridTransforms.Remove(randomSpawnPoint);

                        StartCoroutine(DestroyMoleAfterDelay(moleInstance, newMoleDisappearanceTime));
                        StartCoroutine(RestoreSpawnPointAfterDelay(moleInstance, randomSpawnPoint));
                    }
                }
            }
        }

        private IEnumerator DestroyMoleAfterDelay(GameObject mole, float destroyTime)
        {
            yield return new WaitForSeconds(destroyTime);

            //  DELETE PREFAB AFTER DELAY IF IS NOT NULL
            if (mole != null)
            {
                //  ADD PLAYER DAMAGED EVENT
                Enemy newMoplecomponent = mole.GetComponent<Enemy>();   //  UPCASTING

                if (TitleScreenAndGameModeManager.Instance.currentGameMode == GameMode.HealthGameMode)
                {
                    _healthBar.ApplyDamage(newMoplecomponent.MaxHealth); //  DAMAGE PLAYER
                }

                Destroy(mole);
            }
        }

        private IEnumerator RestoreSpawnPointAfterDelay(GameObject mole, Transform spawnPoint)
        {
            Enemy newMoplecomponent = mole.GetComponent<Enemy>();   //  UPCASTING

            yield return new WaitForSeconds(newMoplecomponent.DisappearanceTime);

            //  ADD SPAWN POINT BACK TO THE LIST
            GridTransforms.Add(spawnPoint);
        }

        IEnumerator ScaleOverTime(GameObject objToScale)
        {
            if (objToScale == null)
            {
                yield break; // Если объект уничтожен, выходим из корутины
            }

            float currentTime = 0f;
            float duration = 2f; // Время изменения размера в секундах

            Vector3 startScale = objToScale.transform.localScale;
            Vector3 targetScale = Vector3.one; // Финальный размер

            while (currentTime < duration)
            {
                if (objToScale == null)
                {
                    yield break; // Если объект уничтожен, выходим из корутины
                }

                objToScale.transform.localScale = Vector3.Lerp(startScale, targetScale, currentTime / duration);
                currentTime += Time.deltaTime * scaleChangeSpeed;
                yield return null;
            }

            // Убедитесь, что размер установлен в конечное значение точно
            if (objToScale != null)
            {
                objToScale.transform.localScale = targetScale;
            }
        }
    }
}
