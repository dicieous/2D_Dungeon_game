 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMenu : MonoBehaviour
{
    //Texts Field
    public Text levelText, hitpointText, coinText, upgradeCostText, xpText;

    //Logic
    private int currentCharacterSelection = 0;
    public Image characterSelectionSprite;
    public Image weaponSprite;
    public RectTransform xpBar;

    //characterSelection;
    public void OnArrowClick(bool right)
    {
        if (right)
        {
            currentCharacterSelection++;
            if (currentCharacterSelection == GameManager.instance.playerSprites.Count)
            {
                currentCharacterSelection = 0;
            }

            OnselectionChanged();
        }
        else
        {
            currentCharacterSelection--;
            if (currentCharacterSelection < 0)
            {
                currentCharacterSelection = GameManager.instance.playerSprites.Count - 1;
            }

            OnselectionChanged();
        }
    }

    private void OnselectionChanged()
    {
        characterSelectionSprite.sprite = GameManager.instance.playerSprites[currentCharacterSelection];
    }

    //WeaponUpgrade
    public void OnUpgradeClick()
    {
        if (GameManager.instance.TryUpgradeWeapon())
            UpdateMenu();
    }

    //update the character info
    public void UpdateMenu()
    {
        //weapon
        weaponSprite.sprite = GameManager.instance.WeaponSprites[GameManager.instance.weapon.weaponLevel];
        if (GameManager.instance.weapon.weaponLevel == GameManager.instance.weaponPrices.Count)
        {
            upgradeCostText.text = "MAX";
        }
        else
        {
            upgradeCostText.text = GameManager.instance.weaponPrices[GameManager.instance.weapon.weaponLevel].ToString();
        }


        //Meta
        levelText.text = GameManager.instance.GetCurrentLevel().ToString();
        hitpointText.text = GameManager.instance.player.hitPoint.ToString();
        coinText.text = GameManager.instance.coins.ToString();

        //xpBar
        int currLevel = GameManager.instance.GetCurrentLevel();
        if (currLevel == GameManager.instance.xpTable.Count)
        {
            xpText.text = GameManager.instance.experience.ToString() + " total Experience Points";//displays total Xp
            xpBar.localScale = Vector3.one;
        }
        else
        {
            int prevLevelXp = GameManager.instance.GetXpToLevel(currLevel-1);
            int currLevelXp = GameManager.instance.GetXpToLevel(currLevel);

            int diff = currLevelXp = prevLevelXp;
            int currXpIntoLevel = GameManager.instance.experience - prevLevelXp;

            float completionRatio = (float)currXpIntoLevel / (float)diff;
            xpBar.localScale = new Vector3(completionRatio, 1, 1);
            xpText.text = currXpIntoLevel.ToString() + " / " + diff;
        }
    }
}
