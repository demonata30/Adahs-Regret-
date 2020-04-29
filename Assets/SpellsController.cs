using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellsController : MonoBehaviour
{
    [Header("Properties")]
    public List<Spell> spells;

    // Update is called once per frame
    void Update()
    {
        foreach (Spell spell in spells)
        {
            if (Input.GetKeyDown(spell.key) && !spell.onCooldown && !spell.isExecuting)
            {
                spell.StartSpell();
            }
        }
    }
}
