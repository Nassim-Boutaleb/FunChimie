using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zodiac_GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _target0;
    [SerializeField] private GameObject _target1;
    [SerializeField] private GameObject _target2;
    [SerializeField] private GameObject _target3;
    [SerializeField] private GameObject _target4;
    [SerializeField] private GameObject _target5;
    [SerializeField] private GameObject _target6;
    [SerializeField] private GameObject _target7;
    [SerializeField] private GameObject _target8;
    [SerializeField] private GameObject _target9;
    [SerializeField] private GameObject _target10;
    [SerializeField] private GameObject _target11;
    [SerializeField] private GameObject _mass;

    private GameObject curr_Target;
    private float _time;

    // Start is called before the first frame update
    void Start()
    {
        if (_target0.activeSelf == true)
            curr_Target = _target0;
        else if (_target1.activeSelf == true)
            curr_Target = _target1;
        else if (_target2.activeSelf == true)
            curr_Target = _target2;
        else if (_target3.activeSelf == true)
            curr_Target = _target3;
        else if (_target4.activeSelf == true)
            curr_Target = _target4;
        else if (_target5.activeSelf == true)
            curr_Target = _target5;
        else if (_target6.activeSelf == true)
            curr_Target = _target6;
        else if (_target7.activeSelf == true)
            curr_Target = _target7;
        else if (_target8.activeSelf == true)
            curr_Target = _target8;
        else if (_target9.activeSelf == true)
            curr_Target = _target9;
        else if (_target10.activeSelf == true)
            curr_Target = _target10;
        else if (_target11.activeSelf == true)
            curr_Target = _target11;
        _time = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vec = _mass.transform.position - curr_Target.transform.position;
        if (vec.magnitude <= .1f)
		{
            Debug.Log("On the point");
            _time += Time.deltaTime;
            if (_time > 5f)
			{
                //implement success here
                Debug.Log("Success !");
			}
		}
        else
		{
            Debug.Log("nope " + vec.magnitude);
            _time = 0f;
		}

    }
}
