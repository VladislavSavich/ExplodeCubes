using System;
using UnityEngine;

public class RayCaster : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    private Ray _ray;
    public event Action<Cube> CubeHitted;

    private void OnMouseUp()
    {
        Hit();
    }

    private void Hit()
    {
        _ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(_ray, out RaycastHit hit, Mathf.Infinity))
        {
            if (hit.collider.TryGetComponent<Cube>(out var hittedCube))
                CubeHitted?.Invoke(hittedCube);
        }
    }
}
