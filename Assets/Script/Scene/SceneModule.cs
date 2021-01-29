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
        
    }

    public void LoadSceneByName(string sceneName)
    {
        _sceneName = sceneName;
        if (_sceneName != "")
        {
            _loader._ani.SetTrigger("fadein");
            StartCoroutine(LoadByName());
        }
    }

    public IEnumerator LoadByName()
    {
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
            _loader._text.text = "Loading progress: " + (asyncOperation.progress * 100) + "%";

            // Check if the load has finished
            if (asyncOperation.progress >= 0.9f)
            {
                _loader._ani.SetTrigger("fadeout");
            }

            yield return null;
        }
    }
}
