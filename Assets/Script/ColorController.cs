using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorController : MonoBehaviour
{
    public static ColorController Instance { get; private set; }
    public List<ChangedColorObject> _colorObj = new List<ChangedColorObject>();
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void Start()
    {

    }

    public void PickUpColor(ColorData color)
    {
        foreach (ChangedColorObject item in _colorObj)
        {
            if (color._color == item._currentColor._color)
            {
                item._activeColor = true;
                item.ChangeColor(color);
                ColorUI.Instance._isDirty = false;
            }
        }
    }

    public void ResetColor()
    {
        foreach (ChangedColorObject item in _colorObj)
        {
            item._defaltMode.Invoke(0);
        }
    }

    public void AvtiveEvent(ColorData color)
    {
        ResetColor();
        foreach (ChangedColorObject item in _colorObj)
        {
            if (color._color == item._currentColor._color)
            {
                item._colorEvent.Invoke(0);
            }
        }
    }
}
