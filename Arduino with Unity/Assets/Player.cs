using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField]
    int hp = 100;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI endText;
    public int time = 0;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Counter", 0, 1);
        endText.GetComponent<TextMeshProUGUI>().text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Zombie")
        {
            Debug.Log("Collision");
            int i = Random.Range(11, 14);
            hp -= i;
            healthText.GetComponent<TMPro.TextMeshProUGUI>().text = "Health: " + hp;

            if(hp <= 0)
            {
                EndGame();
            }
        }
    }

    void Counter()
    {
        time += 1;
        timeText.GetComponent<TextMeshProUGUI>().text = "Time survived: " + time + " seconds";
    }

    void EndGame()
    {
        CancelInvoke();
        
        endText.GetComponent<TextMeshProUGUI>().text = "You died! Time survived: " + time + " seconds";
        healthText.GetComponent<TextMeshProUGUI>().text = "";
        timeText.GetComponent<TextMeshProUGUI>().text = "";
    }
}
