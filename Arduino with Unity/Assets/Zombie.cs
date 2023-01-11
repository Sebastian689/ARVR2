using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Zombie : MonoBehaviour
{
    Transform _followTarget;
    float _speed = 1.0f;
    const float EPSILON = 1.0f;
    //public TextMeshProUGUI debugText;
    public int hp = 50;

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(hp <= 0){
            StartCoroutine(DeadAnimation());
        }

        _followTarget = GameObject.FindGameObjectWithTag("MainCamera").transform;
        //debugText.GetComponent<TextMeshProUGUI>().text = "Transform: " + _followTarget.position;

        transform.LookAt(_followTarget);

        if((transform.position - _followTarget.position).magnitude > EPSILON)
            transform.Translate(0.0f, 0.0f, _speed * Time.deltaTime);
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player"){
            animator.SetBool("isAttacking", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player"){
            animator.SetBool("isAttacking", false);
        }
    }

    IEnumerator DeadAnimation()
    {
        transform.position = new Vector3(transform.position.x, -1.5f, transform.position.z);
        animator.SetBool("isUnalive", true);
        yield return new WaitForSeconds(3.0f);
        Destroy(gameObject);
    }
}
