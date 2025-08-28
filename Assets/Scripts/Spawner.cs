using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _cube;
    [SerializeField] private float _scaleReducer;
    [SerializeField] private ColorChanger _colorChanger;
    private List<Rigidbody> _rigidbodies = new List<Rigidbody>();
    private Vector3 _targetScale;
    private int _cubesCount;
    private int _minValueCubeCount = 2;
    private int _maxValueCubeCount = 7;
    private float _valueReducer = 2f;
    private float _newSplitChance;

    public void SpawnCubes(Cube cube)
    {
        _cubesCount = Random.Range(_minValueCubeCount, _maxValueCubeCount);
        _targetScale= cube.Scale / _scaleReducer;
        _newSplitChance = cube.ValueSplitChance / _valueReducer;

        for (int i = 0; i < _cubesCount; i++)
        {
            Cube cubeClone = Instantiate(cube, cube.Position, Quaternion.identity);
            cubeClone.Init(_colorChanger.GenerateRandomColor(), _targetScale, _newSplitChance);
            _rigidbodies.Add(cubeClone.Rigidbody);
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
