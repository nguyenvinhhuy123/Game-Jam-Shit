using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BuffSystem
{
    public class NAHealOnHitSOData : BuffSOData
    {
        public int NAHealAmount;
        public override BuffHandler InitHandler(MonsterCard target, GameObject caster)
        {
            return new NAHealOnHitHandler(this , target, caster);
        }
    }
}
