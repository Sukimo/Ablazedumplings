using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangedColorObject : MonoBehaviour
{
    public ColorData _colorTemp;
    public ColorData _currentColor;
    public Material _mat;
    public Color _Unselect;
    // Start is called before the first frame update
    void Start()
    {
        ColorController.Instance._colorObj.Add(this);
        _mat = GetComponent<Renderer>().material;
        _colorTemp._color = _Unselect;
    }
    public void Update()
    {
        if (_mat.color != _colorTemp._color)
        {
            _mat.color = Color.Lerp(_mat.color, _colorTemp._color,1);
        }
    }
    public void ChangeColor(ColorData color)
    {
        if (_currentColor._color == color._color)
        {
            _colorTemp._color = color._color;
        }
        else
        {
            _colorTemp._color = _Unselect;
        }
    }
}
