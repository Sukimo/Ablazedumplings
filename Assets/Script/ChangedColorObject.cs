using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangedColorObject : MonoBehaviour
{
    public ColorTemp _colorTemp;
    public ColorData _currentColor;
    public Material _mat;
    private float r=200, g=200, b = 200;
    // Start is called before the first frame update
    void Start()
    {
        ColorController.Instance._colorObj.Add(this);
        _mat = GetComponent<Renderer>().material;
    }
    public void Update()
    {
        if (_mat.color != _colorTemp._color)
        {
            _mat.color = Color.Lerp(_mat.color, _colorTemp._color,Time.deltaTime*4);
        }
    }
    public void ChangeColor(ColorData color)
    {
        if (color._name == "red")
        {
            if (_currentColor._name == "red")
            {
                _colorTemp._color = new Color(r,0,0);
            }
            else if (_currentColor._name == "green")
            {
                _colorTemp._color = new Color(r, g, 0);
            }
            else if (_currentColor._name == "blue")
            {
                _colorTemp._color = new Color(r, 0, b);
            }
        }
        if (color._name == "green")
        {
            if (_currentColor._name == "red")
            {
                _colorTemp._color = new Color(r, g, 0);
            }
            else if (_currentColor._name == "green")
            {
                _colorTemp._color = new Color(0, g, 0);
            }
            else if (_currentColor._name == "blue")
            {
                _colorTemp._color = new Color(0, g, b);
            }
        }
        if (color._name == "blue")
        {
            if (_currentColor._name == "red")
            {
                _colorTemp._color = new Color(r, 0, b);
            }
            else if (_currentColor._name == "green")
            {
                _colorTemp._color = new Color(0, g, b);
            }
            else if (_currentColor._name == "blue")
            {
                _colorTemp._color = new Color(0, 0, b);
            }
        }
    }
}
