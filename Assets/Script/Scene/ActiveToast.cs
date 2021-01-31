using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveToast : MonoBehaviour
{
    public string _text;
    public bool _showTime,_showCoin,_showScore,_end;
    public void ActiveToastByString()
    {
        print("Active");
        if (_showTime)
        {
            Toast.Instance.Show("I took " + ScoreController.Instance._minute.ToString("F0") + " minutes " + ScoreController.Instance._second.ToString("F0") + " seconds of your time.");
            ScoreController.Instance._isDirty = false;
            
            return;
        }
        
        if (_showCoin)
        {
            Toast.Instance.Show("You get " + ScoreController.Instance._coinCount + " coins and miss " + (ScoreController.Instance._allCoin - ScoreController.Instance._coinCount) + " coins.");
            return;
        }

        if (_showScore)
        {
            Toast.Instance.Show("You get "+ScoreController.Instance._score.ToString("F0")+" scores.");
            return;
        }
        if (_end)
        {
            Toast.Instance._end = true;
        }
        Toast.Instance.Show(_text);
    }
}
