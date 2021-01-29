using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatfromMove : MonoBehaviour
{
    public GameObject _point;
    private List<Transform> _points = new List<Transform>();
    public bool _isDirty, _back;
    public Transform _target;
    private int _indexPoint,_dir;
    public bool debug;
    private int _temp;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform item in _point.transform)
        {
            _points.Add(item);
        }
        if (debug)
        {
            StartMove();
        }
    }   

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartMove()
    {
        if (_points.Count > 1)
        {
            _isDirty = true;
            FindIndex();
            _indexPoint = _temp;
        }
        
    }

    public void StopMove()
    {
        _isDirty = false;
        _temp = _indexPoint;
    }

    public IEnumerator Move(Transform target)
    {
        float time=0;
        Vector3 pos = transform.position;
        while (transform.position != target.position)
        {
            if (!_isDirty)
                yield break;

            time += Time.deltaTime*0.33f;
            
            float distance = Vector3.Distance(pos, target.position);

            transform.position = Vector3.Lerp(pos, target.position, time);

            if (distance < 0.01f)
            {
                transform.position = target.position;
            }
            yield return null;
        }
        FindIndex();
    }

    public void FindIndex()
    {
        if (_indexPoint >= _points.Count-1)
        {
            _back = true;
        }
        if (_indexPoint < 1)
        {
            _back = false;
        }

        if (_back)
        {
            _indexPoint -= 1;
        }
        else
        {
            _indexPoint += 1;
        }
        _target = _points[_indexPoint];
        StartCoroutine(Move(_target.transform));
    }
}
