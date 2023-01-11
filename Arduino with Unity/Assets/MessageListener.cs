using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MessageListener : MonoBehaviour
{

    public TextMeshProUGUI debugText;


    // Invoked when a line of data is received from the serial device.
    void OnMessageArrived(string msg)
    {
        if(msg=="1"){
            Debug.Log("Input");
            debugText.GetComponent<TextMeshProUGUI>().text = "Shooting";
        }
        else if(msg=="0")
        {
            debugText.GetComponent<TextMeshProUGUI>().text = "Not shooting";
        }
    }

    // Invoked when a connect/disconnect event occurs. The parameter 'success'
    // will be 'true' upon connection, and 'false' upon disconnection or
    // failure to connect.
    void OnConnectionEvent(bool success)
    {
        Debug.Log("Connected");
    }
}
