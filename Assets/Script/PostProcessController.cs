using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
public class PostProcessController : MonoBehaviour
{
    public static PostProcessController Instance { get; private set; }
    public PostProcessVolume m_Volume;
    public ColorGrading m_ColorGrading;
    private float _targetSaturation = 0;
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
}
