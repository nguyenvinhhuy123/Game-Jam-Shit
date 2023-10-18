using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class DebbugerManager : MonoBehaviour
{
    // Start is called before the first frame update
    public MonsterCard Monster1;
    public MonsterCard Monster2;

    // Update is called once per frame
    void Update()
    {
        //!for testing with health and attack communication
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int healthMonster2Before = Monster2.m_component.m_health.CurrentHealthValue;
            Monster1.UseNormalAttack(Monster2);
            Assert.AreNotEqual(Monster2.m_component.m_health.CurrentHealthValue, healthMonster2Before);
        }
        
    }
}
