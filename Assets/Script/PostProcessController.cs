using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
public class PostProcessController : MonoBehaviour
{
    public static PostProcessController Instance { get; private set; }
    public PostProcessVolume m_Volume;
    public ColorGrading m_ColorGrading;
    private float _targetSaturation,_tempS;
    public bool _isDirty;
    private List<string> _oldColor = new List<string>();
    public List<ColorParameter> _color = new List<ColorParameter>();
    public FloatParameter _test;
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
        m_Volume.profile.TryGetSettings(out m_ColorGrading);
        //m_ColorGrading.saturation.value = -100f;
        //StartCoroutine(FadeOutColor());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            StartCoroutine(FadeInColor());
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            StartCoroutine(FadeOutColor());
        }

        /*if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(AddColor("red"));
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            StartCoroutine(AddColor("green"));
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            StartCoroutine(AddColor("blue"));
        }*/
    }

    public IEnumerator FadeOutColor()
    {
        _isDirty = true;
        _targetSaturation = 0;
        float temp = 0;
        temp = _targetSaturation;
        float time=0;
        while (_targetSaturation > -100)
        {
            _targetSaturation = Mathf.Lerp(temp, -100,time);
            time += Time.deltaTime * 0.8f;
            m_ColorGrading.saturation.value = _targetSaturation;
            yield return null;
        }
        yield return new WaitForSeconds(2);
        _isDirty = false;
    }

    public IEnumerator FadeInColor()
    {
        _isDirty = true;
        _targetSaturation = -100;
        float temp = 0;
        temp = _targetSaturation;
        float time = 0;
        while (_targetSaturation < 0)
        {
            _targetSaturation = Mathf.Lerp(temp, 0, time);
            time += Time.deltaTime * 0.8f;
            m_ColorGrading.saturation.value = _targetSaturation;
            yield return null;
        }
        yield return new WaitForSeconds(2);
        _isDirty = false;
    }

    public IEnumerator AddColor(string color)
    {
        _oldColor.Add(color);
        _isDirty = true;
        _targetSaturation += 33;
        float temp = 0;
        temp = m_ColorGrading.saturation.value;
        float time = 0;
        if (_oldColor.Count == 1)
        {
            if (color == "red")
                m_ColorGrading.colorFilter = _color[0];
            if (color == "green")
                m_ColorGrading.colorFilter.value = _color[1];
            if (color == "blue")
                m_ColorGrading.colorFilter.value = _color[2];
        }

        if (_oldColor.Count == 2)
        {
            if (_oldColor[0] == "red" && _oldColor[1]=="green")
                m_ColorGrading.colorFilter = _color[3];
            if (_oldColor[0] == "red" && _oldColor[1] == "blue")
                m_ColorGrading.colorFilter.value = _color[4];
            if (_oldColor[0] == "green" && _oldColor[1] == "blue")
                m_ColorGrading.colorFilter.value = _color[5];
        }

        if (_oldColor.Count == 3)
        {
                m_ColorGrading.colorFilter.value = _color[6];
        }

        if (_oldColor.Count > 3)
            yield break;

        while (m_ColorGrading.saturation.value < _targetSaturation)
        {
            temp = Mathf.Lerp(temp, _targetSaturation, time);
            time += Time.deltaTime * 0.8f;
            _test = new FloatParameter {value = temp};
            m_ColorGrading.saturation.value = _test;
            yield return null;
        }
        yield return new WaitForSeconds(1);
        _isDirty = false;
    }
}
