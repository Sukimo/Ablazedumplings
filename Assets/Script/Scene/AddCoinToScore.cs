using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCoinToScore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform item in ScoreController.Instance.gameObject.transform)
        {
            print(item.name + " " + this.gameObject.name);
            if (item.name == this.gameObject.name)
            {
                Destroy(this.gameObject);
            }
        }
        
        transform.parent = ScoreController.Instance.gameObject.transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
