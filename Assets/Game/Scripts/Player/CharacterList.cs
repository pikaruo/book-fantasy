using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterList : MonoBehaviour
{

    [Header("Info Character")]
    public CharacterDatabase characterDB;
    public TMP_Text nameCharacterText;
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

    private void UpdateCharacter(int selectedOption)
    {
        Character character = characterDB.GetCharacter(selectedOption);

        photoCharacterImage.sprite = character.characterSprite;
        nameCharacterText.text = "Name : " + character.characterName;

    }
    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }
}
