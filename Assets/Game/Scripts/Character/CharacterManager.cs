using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    public CharacterDatabase characterDB;

    [Header("Info Character")]
    public TMP_Text nameCharacterText, attack, deffense, speed, type, skillOne, skillTwo, skillThree, Ability, attackType;
    public Image photoCharacterImage;

    private int selectedOption = 0;

    private void Start()
    {

        if (!PlayerPrefs.HasKey("selectedOption"))
        {
            selectedOption = 0;
        }
        else
        {
            Load();
        }

        UpdateCharacter(selectedOption);
    }

    public void NextOption()
    {
        selectedOption++;
        if (selectedOption >= characterDB.CharacterCount)
        {
            selectedOption = 0;
        }

        UpdateCharacter(selectedOption);
        Save();
    }

    public void BackOption()
    {
        selectedOption--;
        if (selectedOption < 0)
        {
            selectedOption = characterDB.CharacterCount - 1;
        }

        UpdateCharacter(selectedOption);
        Save();
    }

    private void UpdateCharacter(int selectedOption)
    {
        Character character = characterDB.GetCharacter(selectedOption);

        photoCharacterImage.sprite = character.characterSprite;

        nameCharacterText.text = "Name : " + character.characterName;
        attack.text = "Attack : " + character.attack;
        deffense.text = "Deffense : " + character.deffense;
        speed.text = "Speed : " + character.speed;
        type.text = "Type : " + character.type;

        attackType.text = "Attack Type : " + character.attackType;
        skillOne.text = "Skill 1 : " + character.skillOne;
        skillTwo.text = "Skill 2 : " + character.skillTwo;
        skillThree.text = "Skill 3 : " + character.skillThree;
        Ability.text = "Ability : " + character.Ability;
    }

    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }

    private void Save()
    {
        PlayerPrefs.SetInt("selectedOption", selectedOption);
    }

}
