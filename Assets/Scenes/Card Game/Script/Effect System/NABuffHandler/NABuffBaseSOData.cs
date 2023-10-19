using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BuffSystem
{
    public class NABuffBaseSOData : BuffSOData
    {
        public int NABuffAmount;
        public override BuffHandler InitHandler(MonsterCard target, GameObject caster)
        {
            return new NABuffHandler(this , target, caster);
        }
    }
}
