using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private Cube _prefabCube;
    [SerializeField] private float _scaleReducer;
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;
    private List<Rigidbody> _explodableCubes = new List<Rigidbody>();
    private Renderer _renderer;
    private Vector3 _targetScale;
    private Vector3 _position;
    private float _valueSplitChance;
    private float _valueDisappearingChance;
    private int _cubesCount;
    private int _minValueCubeCount = 2;
    private int _maxValueCubeCount = 7;
    private int _maxValueChance = 101;
    private int _minValueChance = 0;

    private void Start()
    {
        _valueSplitChance = 100;
        _targetScale = transform.localScale / _scaleReducer;
        _renderer = GetComponent<Renderer>();
        _renderer.material.color = Random.ColorHSV();
        _cubesCount = Random.Range(_minValueCubeCount, _maxValueCubeCount);
    }

    private void Update()
    {
        _position = transform.localPosition;
    }

    private void OnMouseUp()
    {
        Separate();
    }
    private void Separate() 
    {
        for (int i = 0; i < _cubesCount; i++)
        {
            Cube cubeClone = Instantiate(_prefabCube, _position, Quaternion.identity);
            _explodableCubes.Add(cubeClone.GetComponent<Rigidbody>());
            cubeClone.transform.localScale = _targetScale;
        }

        _valueDisappearingChance = Random.Range(_minValueChance,_maxValueChance);

        if (_valueDisappearingChance > _valueSplitChance)
        {
            Destroy(gameObject);
            Explode();
        }
        else
        {
            _valueSplitChance /= 2;
        }
    }

    private void Explode() 
    {
        foreach (Rigidbody _explodableCube in _explodableCubes)
            _explodableCube.AddExplosionForce(_explosionForce, _position, _explosionRadius);
    }
}
