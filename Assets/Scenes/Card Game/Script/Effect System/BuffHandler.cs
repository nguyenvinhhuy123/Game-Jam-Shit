using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BuffSystem
{
    public abstract class BuffHandler : MonoBehaviour
    {
        protected int Duration;
        protected int EffectStack;
        public BuffSOData Data;
        protected readonly MonsterCard Target;
        protected readonly GameObject Caster;
        public bool IsFinished;

        public BuffHandler(BuffSOData data, MonsterCard target,  GameObject caster)
        {
            Data = data;
            Target = target;
            Caster = caster;
        }
        public void OnTurnChange()
        {
            if (Data.EndConditionType != LifeTimeType.END_ON_TIME) return;
            Duration --;
            if (Duration <=0)
            {
                OnEffectEnd();
            }
        }
        public void ActivateEffect()
        {
            if (Data.Stacking == StackConditionType.EFFECT_STACKING)
            {
                ApplyEffect();
                EffectStack++;
            }
            if (Data.Stacking == StackConditionType.DURATION_STACKING)
            {
                Duration += Data.Duration;
            }
            if (Data.Stacking == StackConditionType.OVERRIDE)
            {
                EffectStack = 1;
                Duration = Data.Duration;
            }
        }
        public void RequestEndOfEffect(GameObject caller)
        {
            if (caller != Caster)
            {
                Debug.Log("this Game Object dont have authority to call this fucntion");
                return;
            }
            OnEffectEnd();
        }
        public abstract void ApplyEffect();
        public virtual void OnEffectEnd()
        {
            IsFinished = true;
        }

    }
}
