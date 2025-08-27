using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _cube;
    [SerializeField] private float _scaleReducer;
    private List<Rigidbody> _rigidbodies = new List<Rigidbody>();
    private Vector3 _targetScale;
    private int _cubesCount;
    private int _minValueCubeCount = 2;
    private int _maxValueCubeCount = 7;

    public void SpawnCubes()
    {
        _cubesCount = Random.Range(_minValueCubeCount, _maxValueCubeCount);
        _targetScale = _cube.Scale / _scaleReducer;

        for (int i = 0; i < _cubesCount; i++)
        {
            Cube cubeClone = Instantiate(_cube, _cube.Position, Quaternion.identity);
            cubeClone.transform.localScale = _targetScale;
            _rigidbodies.Add(cubeClone.GetComponent<Rigidbody>());
        }
    }

    public List<Rigidbody> GetExplodableObjects() 
    {
        List<Rigidbody> explodableObjects = new List<Rigidbody>();

        for (int i = 0; i < _rigidbodies.Count; i++)
            explodableObjects.Add(_rigidbodies[i]);

        return explodableObjects;
    }
}
