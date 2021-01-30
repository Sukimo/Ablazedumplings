using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveToast : MonoBehaviour
{
    public string _text;
    public void ActiveToastByString()
    {
        print("Active");
        Toast.Instance.Show(_text);
    }
}
