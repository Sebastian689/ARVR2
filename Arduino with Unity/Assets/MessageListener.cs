using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageListener : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;

    public Camera fpsCam;
    public GameObject impact;
    public CameraShake shake;



    // Invoked when a line of data is received from the serial device.
    void OnMessageArrived(string msg)
    {
        if(msg=="1"){
            Debug.Log("Input");
            PewPew();
        }
    }

    // Invoked when a connect/disconnect event occurs. The parameter 'success'
    // will be 'true' upon connection, and 'false' upon disconnection or
    // failure to connect.
    void OnConnectionEvent(bool success)
    {
        Debug.Log("Connected");
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1")) { PewPew(); }
    }
    void PewPew()
    {
        StartCoroutine(shake.Shake(.15f, .4f));
        RaycastHit hit;
            if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Zombie target = hit.transform.GetComponent<Zombie>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            GameObject ImpactGO = Instantiate(impact, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(ImpactGO, 1f);
        }
    }
}
