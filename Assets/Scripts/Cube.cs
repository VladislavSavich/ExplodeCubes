using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Cube : MonoBehaviour
{
    private Renderer _renderer;
    public float ValueSplitChance { get; private set; }
    public Vector3 Position { get; private set; }
    public Vector3 Scale { get; private set; }

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        _renderer.material.color = Random.ColorHSV();
        ValueSplitChance = 100;
        Scale = transform.localScale;
    }

    private void Update()
    {
        Position = transform.localPosition;
    }

    public void SplitChanceReduce() => ValueSplitChance /= 2;
}
