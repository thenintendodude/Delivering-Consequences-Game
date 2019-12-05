using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushDetection : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private float MaxTimePushable;
    private bool BeingPushed;
    private float TimePushed; 

    // Start is called before the first frame update
    void Start()
    {
        this.BeingPushed = false;
        this.TimePushed = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (TimePushed >= MaxTimePushable) {
            Debug.Log("Hey! Stop Pushing me :(");
            this.TimePushed = 0f;
        } else if (BeingPushed)
        {
            TimePushed += Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("Starting Timer");
            this.BeingPushed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("Resetting Timer");
            this.BeingPushed = false;
            this.TimePushed = 0f;
        }
    }
}
