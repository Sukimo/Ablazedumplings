using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class Loader : MonoBehaviour
{
    public static Loader Instance { get; private set; }
    public Animator _ani;
    public TextMeshProUGUI _text;
    public AsyncOperation asyncOperation;
    void Awake()
    {
        print("Call From : "+ SceneManager.GetActiveScene().name);
        if (Instance == null)
        {
            print("GET");
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            print("Destroy");
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
}
