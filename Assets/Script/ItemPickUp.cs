using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class MyEvent : UnityEvent<string> { }
public class ItemPickUp : MonoBehaviour
{
    public InteractCollision _interactable;
    public System.Action<int> _pickUpEvent;
    public KeyCode _key;
    public ColorData _colorData;
    public MyEvent _event;
    public string _sceneName;
    
    // Start is called before the first frame update
    void Start()
    {
        ColorUI ColorUI = ColorUI.Instance;
        foreach (ColorData item in ColorUI._colors)
        {
            if (item._color == _colorData._color)
                Destroy(this.gameObject);
        }
        _pickUpEvent += delegate { Picked(); };
        _interactable._key = _key;
        _event.AddListener(delegate { SceneModule.Instance.LoadSceneByName(_sceneName);});
    }

    // Update is called once per frame
    void Update()
    {
        if (_interactable._interact)
        {
            if (Input.GetKeyDown(_key))
            {
                if (_event != null)
                {
                    _interactable._interactUI.UpdateUI("", false, _key);
                    _event.Invoke("");
                }
            }
        }
    }

    public void Picked()
    {
        _interactable._interact = false;
        _interactable._interactUI.UpdateUI("", false, _key);
        ColorUI.Instance.AddColor(_colorData);
        ColorController.Instance.PickUpColor(_colorData);
        Destroy(this.gameObject);
    }

    public void LoadScene(string name)
    {

    }
}
