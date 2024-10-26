using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPScript : MonoBehaviour
{
    public int XPAmount;

    private Transform player;

    bool isReady = false;

    private void Start()
    {
        isReady = false;

        player = GameObject.FindGameObjectWithTag("Player").transform;

        isReady = true;
    }

    private void Update()
    {
        if (!isReady) return;
        if (player == null)
        {
            Destroy(this.gameObject);
            return;
        }

        transform.position = Vector3.MoveTowards(transform.position, player.position, Time.deltaTime * 10);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player") return;

        other.GetComponent<PlayerExperience>().IncreaseXP(XPAmount);

        Destroy(this.gameObject);
    }
}
