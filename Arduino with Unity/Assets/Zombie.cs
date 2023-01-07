using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    Transform _followTarget;
    float _speed = 2.0f;
    //const float EPSILON = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        _followTarget = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(_followTarget);

        //if((transform.position - _followTarget.position).magnitude > EPSILON)
        transform.Translate(0.0f, 0.0f, _speed * Time.deltaTime);
    }
}
