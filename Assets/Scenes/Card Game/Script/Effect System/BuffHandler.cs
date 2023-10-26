using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BuffSystem
{
    public abstract class BuffHandler
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
            Debug.Log(Duration);
            Duration--;
            if (Duration <=0)
            {
                OnEffectEnd();
            }
        }
        public void ActivateEffect()
        {
            if (Data.Stacking == StackConditionType.EFFECT_STACKING)
            {
                if (Duration <= 0) Duration += Data.Duration;
                ApplyEffect();
                EffectStack++;
                return;
            }
            if (Data.Stacking == StackConditionType.DURATION_STACKING)
            {
                if (Duration <=0) ApplyEffect();
                Duration += Data.Duration;
                return;
            }
            if (Data.Stacking == StackConditionType.OVERRIDE)
            {
                if (Duration <=0) ApplyEffect();
                EffectStack = 1;
                Duration = Data.Duration;
                return;
            }
        }
        public void RequestEndOfEffect(GameObject caller)
        {
            if (Data.EndConditionType != LifeTimeType.END_ON_EXTERNAL_CALL) return;
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
