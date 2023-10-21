using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;

public enum MonsterType : byte
{
    Beast,
    Aquatic,
    Reptile,
    Bird,
    Bug,
    Plant

}
public enum MonsterClass
{
    Mouth,
    Tail,
    Back, 
    Horn
}
[CreateAssetMenu(menuName = "Game-Jam-Shit/MonsterSO")]
public class MonsterCardSOData : CardSOData
{
    public int Health;
    public MonsterType Type;
    public MonsterClass Class;
    public int NormalAttackDamage;
    public int SkillDamage;
    public SkeletonDataAsset SkeletonAsset;

    
}
