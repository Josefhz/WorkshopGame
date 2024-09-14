using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnableScript : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log("AWAKE CALLED");
    }

    void Start()
    {
        Debug.Log("START CALLED");
    }

    private void OnEnable()
    {
        Debug.Log("ON ENABLE CALLED " + Random.Range(0,99999));
    }

    private void OnDisable()
    {
        Debug.Log("ON DISABLE CALLED " + Random.Range(0, 99999));
    }

    private void Update()
    {
        Debug.Log("UPDATE CALLED");
    }
}
