using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreController : MonoBehaviour
{
    public List<Coin> _listCoin = new List<Coin>();
    public TextMeshProUGUI _scoreText,_timeText;
    public int _coinCount;
    public int _allCoin;
    private static float m_score;
    public float _score
    {
        get
        {
            return m_score;
        }
        set
        {
            _scoreText.gameObject.SetActive(false);
            _scoreText.text = "Score : "+ value.ToString();
            m_score = value;
            _scoreText.gameObject.SetActive(true);
        }
    }
    private static float m_time;
    public float _time
    {
        get
        {
            return m_time;
        }
        set
        {
            _timeText.text = "Time : " + _minute.ToString("F0") + " : " + _second.ToString("F0");
            m_time = value;
        }
    }
    public float _minute,_second;
    public bool _isDirty;
    public static ScoreController Instance { get; private set; }

    private void Awake()
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
        _isDirty = true;
    }

    public void CheckCoin(Coin coin)
    {
        if (_listCoin.Contains(coin))
        {
            Destroy(coin.gameObject);
        }
        else
        {
            _listCoin.Add(coin);
        }
    }
    public void AddScore(float score)
    {
        _score += score;
        _coinCount += 1;
    }

    private void Update()
    {
        if (_isDirty)
        {
            _second += Time.deltaTime;
            if (_second > 59)
            {
                _second = 0;
                _minute += 1;
            }
            _time += 1;
        }
    }

    public void Show(bool state)
    {
        _scoreText.gameObject.SetActive(state);
        _timeText.gameObject.SetActive(state);
    }
}
