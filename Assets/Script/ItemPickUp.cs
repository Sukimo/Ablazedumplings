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
    // Start is called before the first frame update
    void Start()
    {
        _pickUpEvent += delegate { Picked(); };
        _interactable._key = _key;
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
        Destroy(this.gameObject);
        _interactable._interact = false;
        _interactable._interactUI.UpdateUI("", false, _key);
        ColorUI.Instance.AddColor(_colorData);
        ColorController.Instance.PickUpColor(_colorData);
    }
}
