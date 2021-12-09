using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;


    private void Awake()
    {
        if (GameManager.instance != null)
        {
            Destroy(gameObject);
            return;
        }

        //PlayerPrefs.DeleteAll();

        instance = this;
        SceneManager.sceneLoaded += loadState;
        DontDestroyOnLoad(gameObject);
    }

    public List<Sprite> playerSprites;
    public List<Sprite> WeaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTable;

    public Player player;
    public Weapon weapon;

    public floatingTextManager FloatingTextManager;

    //FloatingText
   

    public int coins;
    public int experience;


    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        FloatingTextManager.Show(msg, fontSize, color, position, motion, duration);
    }

    //Upgrade weapon

    public bool TryUpgradeWeapon()
    {
        //is the weapon max Level?
        if (weaponPrices.Count <= weapon.weaponLevel)
        {
            return false;
        }

        if (coins >= weaponPrices[weapon.weaponLevel])
        {
            coins -= weaponPrices[weapon.weaponLevel];
            weapon.UpgradeWeapon();
            return true;
        }
        return false;
    }

    //Exprience System
    public int GetCurrentLevel()
    {
        int r = 0;
        int add = 0;

        while (experience >= add)
        {
            add += xpTable[r];
            r++;

            if (r == xpTable.Count)
            {
                return r;
            }
        }
        return r;
    }

    public int GetXpToLevel(int level)
    {
        int r = 0;
        int xp = 0;
        while (r < level)
        {
            xp += xpTable[r];
            r++;
        }

        return xp;
    }

    public void GrantXp(int xp)
    {
        int currLevel = GetCurrentLevel();
        experience += xp;
        if (currLevel < GetCurrentLevel())
        {
            OnLevelUp();
        }
    }

    public void OnLevelUp()
    {
        player.OnLevelUp();
    }
    //save state
    /*
     * INT preferedSkin
     * INT weaponLevel
     * INT coin
     * INT experience
     */
    public void saveState()
    {
        string s = "";
        s += "0" + "|";
        s += coins.ToString() + "|";
        s += experience.ToString() + "|";
        s += weapon.weaponLevel.ToString();

        PlayerPrefs.SetString("saveState", s);
    }

    public void loadState(Scene s, LoadSceneMode mode)
    {
        if (!PlayerPrefs.HasKey("saveState"))
        {
            return;
        }
        string[] data = PlayerPrefs.GetString("saveState").Split('|');
        //change player Skin
        coins = int.Parse(data[1]);

        //Experience
        experience = int.Parse(data[2]);
        if(GetCurrentLevel() != 1)
        player.setLevel(GetCurrentLevel());

        //change weapon level
        weapon.SetWeaponLevel(int.Parse(data[3]));
    }
}
