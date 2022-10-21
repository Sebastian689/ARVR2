using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointlessButtonLEDThing : MonoBehaviour
{

    public SerialController SC;
    public int val1, val2;
    public string[] messageReceived;
    
    // Start is called before the first frame update
    void Start()
    {
        SC = GetComponent<SerialController>();
    }
    
    void Update()
    {
        // Læs fra serial på arduino
        string message = SC.ReadSerialMessage();
        if (message == null)
        {
            return;
        }

        if (ReferenceEquals(message, SerialController.SERIAL_DEVICE_CONNECTED))
        {
            Debug.Log("Device connected :D");
        }
        else if (ReferenceEquals(message, SerialController.SERIAL_DEVICE_DISCONNECTED))
        {
            Debug.Log("Device disconnected ;(");
        }
        else
        {
            Debug.Log("Message recieved : " + message);
            messageReceived = message.Split('/');
            val1 = int.Parse(messageReceived[0]);
            val2 = int.Parse(messageReceived[1]);
        }

        if (val2 == 1)
        {
            TurnLEDOn();
        }
        else if(val2 == 0)
        {
            TurnLEDOff();
        }
    }

    public void TurnLEDOn()
    {
        SC.SendSerialMessage("a");
    }

    public void TurnLEDOff()
    {
        SC.SendSerialMessage("s");
    }
    
    
    
}
