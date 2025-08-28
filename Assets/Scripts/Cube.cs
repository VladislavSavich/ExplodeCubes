using UnityEngine;

[RequireComponent(typeof(Renderer))]
[RequireComponent(typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    private float _maximumValueChance = 100f;
    private float _minimumValueChance = 0f;
    private Renderer _renderer;
    public float ValueSplitChance { get; private set; }
    public Rigidbody Rigidbody { get; private set; }
    public Color Color { get; private set; }
    public Vector3 Scale => transform.localScale;
    public Vector3 Position => transform.localPosition;

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
        _renderer = GetComponent<Renderer>();
    }

    private void Start()
    {;
        _renderer.material.color = Color;

        if (ValueSplitChance == _minimumValueChance)
            ValueSplitChance = _maximumValueChance;
    }

    public void Init(Color color, Vector3 targetScale, float newSplitChance)
    {
        Color = color;
        transform.localScale = targetScale;
        ValueSplitChance = newSplitChance;
    }
}
