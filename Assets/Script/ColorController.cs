using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorController : MonoBehaviour
{
    public static ColorController Instance;
    public List<ChangedColorObject> _colorObj = new List<ChangedColorObject>();
    private void Awake()
    {
        Instance = this;
    }
    public void Start()
    {

    }

    public void ChangeColor(ColorData color)
    {
        foreach (ChangedColorObject item in _colorObj)
        {
            item.ChangeColor(color);
        }
    }
}
