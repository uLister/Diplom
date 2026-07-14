using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private StateMachine stateMachine;

    public PatrolState patrolState;
    public CombatState combatState;

    void Start()
    {
        stateMachine = new StateMachine();

        patrolState = new PatrolState(this);
        combatState = new CombatState(this);

        stateMachine.Initialize(patrolState);
    }

    void Update()
    {
        stateMachine.Update();
    }

    public void SwitchState(BaseState newState)
    {
        stateMachine.ChangeState(newState);
    }
}