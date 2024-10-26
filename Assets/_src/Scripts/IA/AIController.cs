using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    [Header("Main Data")]
    [SerializeField] private EnemyScriptable brain;
    [SerializeField] private GameObject XPPrefab;

    [Header("Player Reference")]
    [SerializeField] private Transform playerTransform;

    [Header("Transform Data")]
    [SerializeField] private Transform GFXTransform;

    [Header("Scripts References")]
    private AIStates AIStatesScript;
    private AIMovement AIMovementScript;
    private AICombat AICombatScript;
    private CharacterStatusManager AIStatusScript;
    private DamageHandler AIDamageHandlerScript;

    [Header("References Check")]
    [SerializeField] private bool referencesOk;


    public void Init(EnemyScriptable pBrain)
    {
        referencesOk = false;

        AIStatesScript = GetComponent<AIStates>();
        AIMovementScript = GetComponent<AIMovement>();
        AICombatScript = GetComponent<AICombat>();
        AIStatusScript = GetComponent<CharacterStatusManager>();
        AIDamageHandlerScript = GetComponent<DamageHandler>();

        brain = pBrain;

        AICombatScript.Init(brain);
        AIMovementScript.Init(brain);
        AIStatusScript.InitStatus(brain.Status);

        InstantiateGraphics();
        FindPlayerReference();

        AIDamageHandlerScript.Init();

        referencesOk = true;
    }

    private void Update()
    {
        if (referencesOk == false) return;
        if (playerTransform == null) return;

        if (AIStatesScript.States == AIStateType.CHASING)
        {
            ChaseBehaviour();
            return;
        }

        if (AIStatesScript.States == AIStateType.ATTACKING)
        {
            AttackBehaviour();
            return;
        }


    }

    void ChaseBehaviour()
    {
        if (playerTransform == null) return;
        if (AIMovementScript == null) return;

        var sucess = AIMovementScript.Chase(playerTransform);

        if (sucess == false)
            AIStatesScript.ChangeToState(AIStateType.ATTACKING);
    }

    void AttackBehaviour()
    {
        var sucess = AICombatScript.CheckAndAttack(playerTransform);

        if (sucess == false)
            AIStatesScript.ChangeToState(AIStateType.CHASING);
    }

    void InstantiateGraphics()
    {
        var gfx = Instantiate(brain.GFX, GFXTransform);
        gfx.transform.parent = this.transform;
    }

    void FindPlayerReference()
    {
        var playerReference = GameObject.FindGameObjectWithTag("Player");

        if (playerReference == null) return;

        playerTransform = playerReference.transform;
    }

    private void OnDestroy()
    {
        Instantiate(XPPrefab, transform.position, Quaternion.identity);
    }
}
