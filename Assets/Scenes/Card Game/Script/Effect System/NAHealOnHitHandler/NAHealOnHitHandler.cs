using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BuffSystem
{
    public class NAHealOnHitHandler : BuffHandler
    {
        private NAHealOnHitSOData NAHealData;
        public NAHealOnHitHandler(BuffSOData data, MonsterCard target,  GameObject caster) : base(data, target, caster)
        {
            NAhealData = (NAHealOnHitSOData)data;
        }
        public override void ApplyEffect()
        {
            if (Target.OnPerformAttackEvent)
            {
                Target.Health += NAHealData.NAHealAmount;
            }
        }
        public override void OnEffectEnd()
        {
            EffectStack = 0;
            base.OnEffectEnd();
        }
    }
}
