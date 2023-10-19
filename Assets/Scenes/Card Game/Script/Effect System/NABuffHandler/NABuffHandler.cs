using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BuffSystem
{
    public class NABuffHandler : BuffHandler
    {
        private NABuffBaseSOData NABUffData;
        public NABuffHandler(BuffSOData data, MonsterCard target,  GameObject caster) : base(data, target, caster)
        {
            NABUffData = (NABuffBaseSOData)data;
        }
        public override void ApplyEffect()
        {
            Target.NormalAttackDamage += NABUffData.NABuffAmount;
        }
        public override void OnEffectEnd()
        {
            IsFinished = true;
            Target.NormalAttackDamage -= NABUffData.NABuffAmount;
            EffectStack = 0;
            base.OnEffectEnd();
        }
    }
}
