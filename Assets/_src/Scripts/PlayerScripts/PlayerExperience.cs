using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExperience : MonoBehaviour
{
    public PlayerWeapons WeaponsScript;
    public int NeededExperience;
    public int CurrentExperience;

    private void Awake()
    {
        WeaponsScript = GetComponent<PlayerWeapons>();
    }

    public void LevelUp()
    {
        CurrentExperience = 0;

        NeededExperience += 20;

        WeaponsScript.AddRandomWeapon();
    }

    public void IncreaseXP(int amount)
    {
        CurrentExperience += amount;

        if (CurrentExperience >= NeededExperience)
        {
            LevelUp();
        }
    }
}
