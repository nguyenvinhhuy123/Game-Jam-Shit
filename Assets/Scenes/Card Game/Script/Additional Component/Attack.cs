using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Attack : MonoBehaviour
{
    private UnityEvent OnPerformAttackEvent;
    public void PerformAttack(MonsterCard target, int sourceDamage)
    {
        target.gameObject.TryGetComponent<Health>(out Health targetHealth);
        if (targetHealth.UnitInactive)
        {
            Debug.Log(target.gameObject.name + " is inactive due to dead");
            return;
        }
        targetHealth.DamageSelf(sourceDamage);
    }
    public void PerformDOTAttack(MonsterCard target, int sourceDamage, int sourceDOT, int sourceDOTDuration)
    {
        target.gameObject.TryGetComponent<Health>(out Health targetHealth);
        if (targetHealth.UnitInactive)
        {
            Debug.Log(target.gameObject.name + " is inactive due to dead");
            return;
        }
        targetHealth.DamageSelf(sourceDamage);
    }
    public void AddPerformAttackListener(UnityAction action)
    {
        OnPerformAttackEvent.AddListener(action);
    }
    public void RemovePerformAttackListener(UnityAction action)
    {
        OnPerformAttackEvent.RemoveListener(action);
    }
}
