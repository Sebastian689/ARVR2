using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkToArduino : MonoBehaviour
{

    public SerialController SC;
    
    // Start is called before the first frame update
    void Start()
    {
        SC = GetComponent<SerialController>();
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
