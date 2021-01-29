using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;
public class ColorUI : MonoBehaviour
{
    public static ColorUI Instance { get; private set; }
    public int _indexColor;
    public List<ColorData> _colors = new List<ColorData>();
    public List<Transform> _colorUIs = new List<Transform>();
    public UICircle _imgaePrefab;
    public ColorData _currentColor;
    public bool _isDirty;
    void Awake()
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
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        #region ControllerColor
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            UpdateUI(0);
        }else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            UpdateUI(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            UpdateUI(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            UpdateUI(3);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            UpdateUI(4);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            UpdateUI(5);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            UpdateUI(6);
        }
        #endregion
    }

    public void UpdateUI(int index)
    {
        if (_isDirty&&index==_indexColor)
        {
            foreach (Transform item in _colorUIs)
            {
                item.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
            }
            ColorController.Instance.ResetColor();
            _isDirty = false;
            return;
        }
        if (index >= _colors.Count)
        {
            return;
        }
        _indexColor = index;
        foreach (Transform item in _colorUIs)
        {
            item.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
        }
        _colorUIs[_indexColor].localScale = new Vector3(1, 1, 1);
        _currentColor = _colors[_indexColor];
        ColorController.Instance.AvtiveEvent(_currentColor);
        _isDirty = true;
    }

    public void AddColor(ColorData color)
    {
        _colors.Add(color);
        UICircle _colorCircle = Instantiate(_imgaePrefab, transform);
        _colorCircle.color = color._color;
        _colorUIs.Add(_colorCircle.transform);
    }
}
