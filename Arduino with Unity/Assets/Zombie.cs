using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Zombie : MonoBehaviour
{
    Transform _followTarget;
    float _speed = 1.0f;
    const float EPSILON = 0.1f;
    public TextMeshProUGUI debugText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _followTarget = GameObject.FindGameObjectWithTag("Player").transform;
        debugText.GetComponent<TextMeshProUGUI>().text = "Transform: " + _followTarget.position;

        transform.LookAt(_followTarget);

        if((transform.position - _followTarget.position).magnitude > EPSILON)
            transform.Translate(0.0f, 0.0f, _speed * Time.deltaTime);
    }
}
