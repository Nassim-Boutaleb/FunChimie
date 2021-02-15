using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackerFollowerXY : MonoBehaviour
{
    [SerializeField]
    private GameObject _tracker;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_tracker != null)
        {
            Vector3 pos_ = new Vector3(_tracker.transform.position.x, 0, _tracker.transform.position.z);
            Vector3 rot_ = new Vector3(0, _tracker.transform.eulerAngles.y, 0);

            this.gameObject.transform.position = pos_;
            this.gameObject.transform.eulerAngles = rot_;
        }
    }
}
