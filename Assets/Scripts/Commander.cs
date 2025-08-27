using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Commander : MonoBehaviour
{
    [SerializeField] private Exploder _exploder;
    [SerializeField] private RayCaster _rayCaster;
    [SerializeField] private Spawner _spawner;
    private float _valueDisappearingChance;
    private int _maxValueChance = 101;
    private int _minValueChance = 0;
    public event Action CubeSplitted;

    private void OnEnable()
    {
        _rayCaster.CubeHitted += CheckSplitChance;
    }

    private void OnDisable()
    {
        _rayCaster.CubeHitted -= CheckSplitChance;
    }

    private void CheckSplitChance(Cube cube)
    {
        _valueDisappearingChance = Random.Range(_minValueChance, _maxValueChance);

        if (_valueDisappearingChance <= cube.ValueSplitChance)
        {
            _spawner.SpawnCubes();
            cube.SplitChanceReduce();
        }
        else
        {
            Destroy(cube.gameObject);
            _exploder.Explode(_spawner.GetExplodableObjects());
        }
    }
}
