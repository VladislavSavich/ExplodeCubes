using System;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private Renderer _renderer;
    private float _valueReducer = 2f;
    private float _maximumValueChance = 100f;
    private float _minimumValueChance = 0f;
    public float ValueSplitChance { get; private set; }
    public float ValueExplodeChance { get; private set; }
    public Vector3 Position { get; private set; }
    public Vector3 Scale { get; private set; }

    private void Start()
    {
        Scale = transform.localScale;

        if (ValueSplitChance == _minimumValueChance)
            ValueSplitChance = _maximumValueChance;

        if (ValueExplodeChance == _minimumValueChance)
            ValueExplodeChance = _maximumValueChance;
    }

    public void Init(Color color, Vector3 targetScale, float newSplitChance, float newExplodeChance)
    {
        _renderer = GetComponent<Renderer>();
        _renderer.material.color = color;
        transform.localScale = targetScale;
        ValueSplitChance = newSplitChance;
        ValueExplodeChance = newExplodeChance;
    }

    private void Update()
    {
        Position = transform.localPosition;
    }
}
