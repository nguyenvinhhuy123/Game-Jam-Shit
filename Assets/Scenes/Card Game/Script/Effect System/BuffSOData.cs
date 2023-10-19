using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BuffSystem
{
    public enum LifeTimeType
    {
        END_ON_TIME,
        END_ON_EXTERNAL_CALL,
        END_ON_GAME_END
    }
    public enum StackConditionType
    {
        EFFECT_STACKING,
        DURATION_STACKING,
        OVERRIDE
    }
    public abstract class BuffSOData : ScriptableObject
    {
        public int Duration;
        public LifeTimeType EndConditionType;
        public StackConditionType Stacking;
        public abstract BuffHandler InitHandler(MonsterCard target, GameObject caster);
    }
}
