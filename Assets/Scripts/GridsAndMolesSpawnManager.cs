using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace YK
{
    public class GridsAndMolesSpawnManager : MonoBehaviour
    {
        [Header("Prefab")]
        [SerializeField] private GameObject _grid;
        [SerializeField] private List<GameObject> _mole;

        [Header("Grid")]
        //  TO DO: ADD CHECK FOR NULL
        private List<Transform> _gridTransforms = new List<Transform>();
        [SerializeField] private int _rowValue = 3;
        [SerializeField] private int _columnValue = 3;

        [Header("Mole")]
        [SerializeField] private int _moleAnount = 3;

        [Header("Coroutine Time")]
        //  TO DO: FIX IT
        [SerializeField] private float _firstMoleSpawnTimer = 0.5f;
        private float _moleSpawnTimer = 2.5f;
        private float _restoreMoleSpawnPointTimer = 2.5f;

        private void Start()
        {
            SpawnGrids();
            //StartCoroutine(FirstMoleSpawnAfterDelay()); 
            //StartCoroutine(MolesSpawn());
            StartCoroutine(FirstMoleSpawnAfterDelay());
            StartCoroutine(MolesSpawn());
        }

        private void SpawnGrids()
        {
            GameObject[,] grids = new GameObject[_rowValue, _columnValue];

            for (int i = 0; i < _rowValue; i++)
            {
                for (int j = 0; j < _columnValue; j++)
                {
                    GameObject gridInstance = Instantiate(_grid);

                    gridInstance.transform.position = new Vector3(i * 2.0f, 0, j * 2.0f);
                    _gridTransforms.Add(gridInstance.transform);

                    grids[i, j] = gridInstance;
                }
            }
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
            int randomIndex = Random.Range(0, _gridTransforms.Count);
            Transform randomTransform = _gridTransforms[randomIndex]; 

            return randomTransform;
        }

        //  COROUTINES
        private IEnumerator MolesSpawn()
        {
            while (true)
            {
                yield return new WaitForSeconds(_moleSpawnTimer);
                Debug.Log("ЦИКЛ Подождал: " + _moleSpawnTimer);

                for (int i = 0; i < _moleAnount; i++)
                {
                    if (_gridTransforms.Count != 0)
                    {
                        Transform randomSpawnPoint = GetRandomSpawnPoint();

                        GameObject ramdomMole = GetRandomMole(_mole);
                        GameObject moleInstance = Instantiate(ramdomMole, randomSpawnPoint.position, randomSpawnPoint.rotation);

                        //  GET ENEMY DISAPPEARANCE TIME
                        Enemy newMoplecomponent = moleInstance.GetComponent<Enemy>();   //  UPCASTING
                        float newMoleDisappearanceTime = newMoplecomponent.DisappearanceTime;

                        //  DELETE LAST MOLE SPAWN POINT
                        _gridTransforms.Remove(randomSpawnPoint);

                        StartCoroutine(DestroyMoleAfterDelay(moleInstance, newMoleDisappearanceTime));
                        StartCoroutine(RestoreSpawnPointAfterDelay(randomSpawnPoint));
                    }
                    else
                    {
                        //  TO DO?
                    }
                }
            }
        }

        private IEnumerator FirstMoleSpawnAfterDelay()
        {
            yield return new WaitForSeconds(_firstMoleSpawnTimer);
            //StartCoroutine(MolesSpawn());
        }

        private IEnumerator DestroyMoleAfterDelay(GameObject mole, float destroyTime)
        {
            yield return new WaitForSeconds(destroyTime);

            // Удаляем префаб после задержки, но только если он был создан
            if (mole != null)
            {
                //  ADD PLAYER DAMAGED EVENT
                Enemy newMoplecomponent = mole.GetComponent<Enemy>();   //  UPCASTING
                EventManager.OnPlayerDied(newMoplecomponent.MaxHealth);

                Destroy(mole);
            }
        }

        private IEnumerator RestoreSpawnPointAfterDelay(Transform spawnPoint)
        {
            yield return new WaitForSeconds(_restoreMoleSpawnPointTimer);

            //  ADD SPAWN POINT BACK TO THE LIST
            _gridTransforms.Add(spawnPoint);
        }
    }
}
