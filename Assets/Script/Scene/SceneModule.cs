using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneModule : MonoBehaviour
{
    public static SceneModule Instance { get; private set; }
    private string _sceneName;
    public Loader _loader;
    public AsyncOperation asyncOperation;
    public List<ColorData> _listData = new List<ColorData>();
    public string _currentScene="Gameplay";
    public bool _menu;
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
        if(_loader==null)
        _loader = Loader.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadSceneByName(string sceneName)
    {
        print("LoadScene");
        _sceneName = sceneName;
        if (_sceneName != "")
        {
            if (_menu)
            {
                StartCoroutine(PostProcessController.Instance.FadeInColor());
                _loader._ani.SetTrigger("fadein");
                StartCoroutine(LoadByName());
                ColorController.Instance._colorObj.Clear();
            }
            else
            {
                StartCoroutine(WaitColor());
            }
            
        }
    }

    public IEnumerator WaitColor()
    {
        StartCoroutine(PostProcessController.Instance.FadeInColor());
        yield return new WaitUntil(() => !PostProcessController.Instance._isDirty);
        _loader._ani.SetTrigger("fadein");
        StartCoroutine(LoadByName());
        ColorController.Instance._colorObj.Clear();

    }

    public IEnumerator LoadByName()
    {
        _menu = false;
        _loader.gameObject.SetActive(true);
        
        yield return null;

        //Begin to load the Scene you specify
        asyncOperation = SceneManager.LoadSceneAsync(_sceneName);
        _loader.asyncOperation = asyncOperation;
        //Don't let the Scene activate until you allow it to
        asyncOperation.allowSceneActivation = false;
        Debug.Log("Pro :" + asyncOperation.progress);
        //When the load is still in progress, output the Text and progress bar
        while (!asyncOperation.isDone)
        {
            //Output the current progress
            //_loader._text.text = "Loading progress: " + (asyncOperation.progress * 100) + "%";
            _loader._text.text = "Lost&Found";
            // Check if the load has finished
            
            if (asyncOperation.progress >= 0.9f)
            {
                yield return new WaitForSeconds(1);
                _loader._ani.SetTrigger("fadeout");
            }

            yield return null;
        }
    }
    public void StartWait(float time)
    {
        StartCoroutine(Wait(time));
    }
    public IEnumerator Wait(float time)
    {
        ColorUI.Instance.ResetICON();
        StartCoroutine(PostProcessController.Instance.FadeOutColor());
        yield return new WaitForSeconds(time);
        foreach (ColorData item in ColorUI.Instance._colors)
        {
            //print("PickUP :" + item._name);
            ColorController.Instance.PickUpColor(item);
        }
        ColorUI.Instance._isDirty = false;
        _currentScene = SceneManager.GetActiveScene().name;
        
    }
}
