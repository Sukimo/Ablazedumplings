using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Created by: Hamza Herbou        (mobile games developer)
// email     : hamza95herbou@gmail.com

public class Toast : MonoBehaviour {
	float _counter = 0f;
	float _duration;
	public bool _isToasting = false;
	public bool _isToastShown = false;
    public GameObject _button,_startButton;
    public static Toast Instance { get; private set; }
    [SerializeField] Text toastText;
	[SerializeField] Animator anim;
	[SerializeField] Color[] co;
	Image toastColorImage;
    public InteractCollision _objectCollistion;
	public enum ToastColor{Dark,Red,Green,Blue,Magenta,Pink}
    public bool _end;
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

	void Start () {toastColorImage = GetComponent <Image> ();}

	void Update(){
		if (_isToasting){
			if (!_isToastShown){
                //print("Show");
				toastShow ();
				//_isToastShown = true;
			}
            /*_counter += Time.deltaTime;
			if(_counter>=_duration){
				_counter = 0f;
                _isToasting = false;
                toastHide();
                _isToastShown = false;
            }*/
            if (Input.GetKeyDown(KeyCode.F))
            {
                ResetToast();
            }
        }
        if (_end)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
                /*
                SceneModule.Instance.LoadSceneByName("Menu", true);
                Destroy(ScoreController.Instance.gameObject);
                _button.gameObject.SetActive(false);
                _end = false;
                _startButton.gameObject.SetActive(true);*/
            }
        }
        
	}
    public void ResetToast()
    {
        if (_isToastShown)
        {
            _isToasting = false;
            toastHide();
            _isToastShown = false;
        }
    }

    /// <summary>
    /// make an empty toast with text: "Hello ;)"
    /// </summary>
    public void Show(){
		toastColorImage.color = co [0];
		toastText.text = "Hello ;)";
		_duration = 1f;
		_counter = 0f;
		if (!_isToasting) _isToasting = true;
	}

	/// <summary>
	/// make a toast with a message.
	/// </summary>
	/// <param name="text">(string), toast message.</param>
	public void Show(string text){
		toastColorImage.color = co [0];
		toastText.text = text;
		_duration = 1f;
		_counter = 0f;
		if (!_isToasting) _isToasting = true;
	}

	/// <summary>
	/// make a toast with a message & duration.
	/// </summary>
	/// <param name="text">(string), toast message.</param>
	/// <param name="duration">(float), toast duration in seconds.</param>
	public void Show(string text, float duration){
		toastColorImage.color = co [0];
		toastText.text = text;
		_duration = duration;
		_counter = 0f;
		if (!_isToasting) _isToasting = true;
	}

	/// <summary>
	/// make a toast with a message, duration & color.
	/// </summary>
	/// <param name="text">(string), toast message.</param>
	/// <param name="duration">(float), toast duration in seconds.</param>
	/// <param name="color">(Toast.ToastColor), toast background color, ex: Toast.ToastColor.Green .</param>
	public void Show(string text, float duration, ToastColor color){
		toastColorImage.color = co [0];
		toastColorImage.color = co [(int)color];
		toastText.text = text;
		_duration = duration;
		_counter = 0f;
		if (!_isToasting) _isToasting = true;
	}



	//show/hide Toast
	void toastShow(){anim.SetBool ("isToastUp",true);}
	void toastHide(){anim.SetBool ("isToastUp",false);}
}
