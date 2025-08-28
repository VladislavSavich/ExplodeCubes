using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    private Renderer _renderer;

    public Color GenerateRandomColor() 
    {
        _renderer = GetComponent<Renderer>();
        _renderer.material.color = Random.ColorHSV();

        return _renderer.material.color;
    }
}
