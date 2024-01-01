using Cinemachine;
using System.Collections.Generic;
using UnityEngine;

namespace YK
{
    public class CameraController : MonoBehaviour
    {

        [SerializeField] private GameObject go;

        List<Transform> cells = new List<Transform>();

        private void Awake()
        {
            GridsAndMolesSpawnManager grids = go.GetComponent<GridsAndMolesSpawnManager>();
        }

        void Start()
        {
            CinemachineVirtualCamera virtualCamera = GetComponent<CinemachineVirtualCamera>();
            if (virtualCamera == null)
            {
                Debug.LogError("Virtual Camera not found on the same GameObject.");
                return;
            }

            AdjustCamera(virtualCamera);
        }

        void AdjustCamera(CinemachineVirtualCamera virtualCamera)
        {
            if (cells.Count == 0)
            {
                Debug.LogWarning("No cells assigned to the camera controller.");
                return;
            }

            Bounds bounds = CalculateBounds();

            float cameraSize = bounds.size.y / 2f;

            // Настраиваем параметры виртуальной камеры
            virtualCamera.m_Lens.OrthographicSize = cameraSize;
            virtualCamera.transform.position = new Vector3(bounds.center.x + 500, bounds.center.y, virtualCamera.transform.position.z);
        }

        Bounds CalculateBounds()
        {
            if (cells.Count == 0)
            {
                Debug.LogWarning("No cells assigned to the camera controller.");
                return new Bounds(Vector3.zero, Vector3.zero);
            }

            Bounds bounds = new Bounds(cells[0].position, Vector3.zero);

            foreach (Transform cell in cells)
            {
                bounds.Encapsulate(cell.position);
            }

            return bounds;
        }
    }
}
