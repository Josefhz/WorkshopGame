using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    // piscar o inimigo

    // no git Package de VFX e um de Numeros


    [Header("Script References")]
    public CharacterStatusManager StatusScript;
    public MeshRenderer myRenderer;

    private void Start()
    {
        if (gameObject.tag != "Enemy")
        {
            Init();
        }
    }

    public void Init()
    {
        StatusScript = GetComponent<CharacterStatusManager>();
        myRenderer = GetComponentInChildren<MeshRenderer>();

        SubscribeToEvent();
    }

    private void SubscribeToEvent() // se inscreve em eventos
    {
        Debug.Log("Se inscrevendo aos eventos");

        StatusScript.OnTakeDamage += BlinkMaterial;
    }

    private void OnDisable() // sai dos eventos
    {
        Debug.Log("Se desinscrevendo dos eventos");

        StatusScript.OnTakeDamage -= BlinkMaterial;
    }



    public void BlinkMaterial()
    {
        if (StatusScript == null)
        {
            Debug.LogError("Missing status script");
            return;
        }

        if (myRenderer == null)
        {
            Debug.LogError("Missing renderer script");
            return;
        }

        StartCoroutine(BlinkMaterialRoutine());
    }

    IEnumerator BlinkMaterialRoutine()
    {
        var myMaterial = myRenderer.materials[0];
        var myMaterialColor = myMaterial.color;

        myMaterial.color = Color.white;

        yield return new WaitForSeconds(0.2f);

        myMaterial.color = myMaterialColor;
    }


}
