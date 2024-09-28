using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStates : MonoBehaviour
{
    public AIStateType States;

    public void ChangeToState(AIStateType state)
    {
        if (States == state) return;

        // ANIMACAO DE TROCA DE ESTADO
        // COISAS AO TROCAR DE ESTADO

        States = state;
    }

}
