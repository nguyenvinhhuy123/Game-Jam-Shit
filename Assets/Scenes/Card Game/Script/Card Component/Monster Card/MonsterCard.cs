using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using System.Data.Common;
using BuffSystem;
using System.Linq;
using UnityEngine.Events;

[ExecuteAlways]
[RequireComponent(typeof(Health), typeof(Attack))]
public class MonsterCard : Card
{
    #region Data Container
    public CardComponentWrapper m_component = new CardComponentWrapper();
    [Header("Data Asset")]
    [SerializeField] private MonsterCardSOData m_data;
    [SerializeField] private SkeletonDataAsset m_animationAsset;
    public SkeletonDataAsset AnimationAsset { get { return m_animationAsset; } set { m_animationAsset = value; } }
    #endregion

    #region Atttribute

    [SerializeField] private int m_health;
    public int Health { get { return m_health; } set { m_health = value; } }
    [SerializeField] private MonsterTrait m_type;
    public MonsterTrait Type { get { return m_type; } private set { m_type = value; } }
    [SerializeField] private MonsterClass m_class;
    public MonsterClass Class { get { return m_class; } set { m_class = value; } }
    [SerializeField] private MonsterNormalAttack m_normalAttack;
    public MonsterNormalAttack NormalAttack { get { return m_normalAttack; } set { m_normalAttack = value; } }
    [SerializeField] private MonsterSkill m_skill;
    public MonsterSkill Skill { get { return m_skill; } set { m_skill = value; } }
    [SerializeField] private int m_normalAttackDamage;

    //? Should we use a formula here , Or Use a complete different scale??
    //!Option 1:
    //*NADamage = attack*multiplier + debuff */
    //*SkillDmg = attack*Skill multiplier + debuff */
    //!Option 2:
    //*NADamage = NABaseDamage + debuff */
    //*SkillDmg = SkillBaseDmg + debuff */

    //Plus 2 Attack for card
    //Plus 2 NA dmg
    //* */

    public int NormalAttackDamage { get { return m_normalAttackDamage; } set { m_normalAttackDamage = value; } }
    [SerializeField] private int m_skillDamage;
    public int SkillDamage { get { return m_skillDamage; } set { m_skillDamage = value; } }

    #endregion

    #region Buff System
    private Dictionary<BuffSOData, BuffHandler> m_buffDic = new Dictionary<BuffSOData, BuffHandler>();

    #endregion
    private UnityAction<PlayerAuthority> OnTurnChangeAction;
    private UnityAction OnKillSelfAction;
    private UnityAction<int, bool> OnHitAction;
    private UnityAction<int> OnPerformAttack;

    #region Callback
    void InitData()
    {
        #region set up attribute
        m_type = m_data.Type;
        m_class = m_data.Class;
        m_health = m_data.Health;
        m_normalAttackDamage = m_data.NormalAttackDamage;
        m_skillDamage = m_data.SkillDamage;

        CardID = m_data.CardID;
        FrontSprite = m_data.FrontSprite;
        BackSprite = m_data.BackSprite;
        CardName = m_data.Name;
        m_animationAsset = m_data.SkeletonAsset;
        #endregion

        m_normalAttack.MainTypeEnergy = m_type;
        m_skill.MainTypeEnergy = m_type;
    }
    void OnEnable()
    {
        m_component.InitComponent(this.gameObject);
        OnTurnChangeAction += OnTurnChange;
        //TODO: Assign callback for action
    }
    void OnDisable()
    {
        OnTurnChangeAction -= OnTurnChange;
        //TODO: Assign callback for action

    }
    void Awake()
    {
        m_component.InitComponent(this.gameObject);
    }
    void Start()
    {

        m_component.m_axieAnimation.skeletonDataAsset = m_data.SkeletonAsset;
        m_component.m_axieAnimation.AnimationState.SetAnimation(0, "action/idle/normal", true);
        InitData();
        m_component.m_health.InitHealth(m_health);
        TurnManager.Instance.AddEndOfTurnListener(OnTurnChangeAction);
        m_component.m_health.AddOnHitListener(OnHitAction);
        m_component.m_health.AddOnKillSelfListener(OnKillSelfAction);
        //TODO: Assign callback for action
    }
    void OnValidate()
    {
        if (m_component.m_axieAnimation == null)
        {
            m_component.InitComponent(this.gameObject);
        }
        if (m_data != null)
        {
            m_data.Type = m_type;
            m_data.Health = m_health;
            m_data.NormalAttackDamage = m_normalAttackDamage;
            m_data.SkillDamage = m_skillDamage;

            m_data.FrontSprite = FrontSprite;
            m_data.BackSprite = BackSprite;
            m_data.Name = CardName;
            m_data.SetID(CardID);

            m_data.SkeletonAsset = m_animationAsset;
            Debug.Log(m_component.m_axieAnimation);
            m_component.m_axieAnimation.skeletonDataAsset = m_data.SkeletonAsset;
        }
    }
    void OnHit()
    {

    }
    void OnKillSelf()
    {

    }

    #endregion

    #region Method
    public void UseNormalAttack(MonsterCard target, PlayerManager player)
    {
        if (TurnManager.Instance.Authority != player.ThisAuthority)
        {
            Debug.Log("Can not use attack, not our turn yet");
            return;
        }
        if (TurnManager.Instance.CurrentPhase != Phase.COMBAT_PHASE)
        {
            Debug.Log("Can not use attack, not attack phase yet");
            return;
        }
        if (target == null)
        {
            Debug.Log("Cannot find target monster");
            return;
        }
        //TODO: Add constrain when target card = our card
        m_normalAttack?.OnUse(target, this as MonsterCard, player);
    }
    public void UseSkill(MonsterCard target, PlayerManager player)
    {
        if (TurnManager.Instance.Authority != player.ThisAuthority)
        {
            Debug.Log("Can not use spell, not our turn yet");
            return;
        }
        if (TurnManager.Instance.CurrentPhase != Phase.COMBAT_PHASE)
        {
            Debug.Log("Can not use spell, not combat phase yet");
            return;
        }
        if (!m_skill.NeedTarget)
        {
            if (target != null)
            {
                Debug.Log("Target shouldn't be choose here");
            }
            m_skill?.OnUse(this as MonsterCard, player);
            return;
        }
        if (m_skill.NeedTarget)
        {
            if (target == null)
            {
                Debug.Log("Cannot find target monster");
                return;
            }
            m_skill?.OnUse(target, this as MonsterCard, player);
        }
        //TODO: Add constrain when target card = our card

    }
    public void RequestEndOfEffect(GameObject caller, BuffHandler buff)
    {
        if (m_buffDic.ContainsKey(buff.Data))
        {
            Debug.Log("remove");
            m_buffDic[buff.Data].RequestEndOfEffect(caller);
            if (m_buffDic[buff.Data].IsFinished)
            {
                m_buffDic.Remove(buff.Data);
            }
            Debug.Log(m_buffDic.Count);
        }
        else
        {
            Debug.Log("Dont have needed buff");
        }
    }
    public void AddBuff(BuffHandler buff)
    {
        if (m_buffDic.ContainsKey(buff.Data))
        {
            if (m_buffDic[buff.Data].Data.Stacking == StackConditionType.EFFECT_STACKING)
                m_buffDic[buff.Data].ActivateEffect();
        }
        else
        {
            m_buffDic.Add(buff.Data, buff);
            buff.ActivateEffect();
            Debug.Log(m_buffDic.Count);
        }

    }
    private void OnTurnChange(PlayerAuthority authority)
    {
        foreach (var buff in m_buffDic.Values.ToList())
        {
            buff.OnTurnChange();
            if (buff.IsFinished)
            {
                m_buffDic.Remove(buff.Data);
            }
        }
    }

    #endregion

}
