using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;


public class GameUI : MonoBehaviour
{
    public Slider healthBar;
    public TextMeshProUGUI playerInfoText;
    public TextMeshProUGUI ammoText;
    public TextMeshProUGUI winText;
    public Slider fpBar;
    public Slider shieldBar;
    public Image winBackground;
    private PlayerController player;
    // instance
    public static GameUI instance;
    void Awake()
    {
        instance = this;
    }
    public void Initialize(PlayerController localPlayer)
    {
        player = localPlayer;
        healthBar.maxValue = player.maxHp;
        healthBar.value = player.curHp;
        fpBar.maxValue = player.weapon.maxFpAmmo;
        fpBar.value = player.weapon.curFpAmmo;
        shieldBar.maxValue = player.maxShield;
        shieldBar.value = player.curShield;
        UpdatePlayerInfoText();
        UpdateAmmoText();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            if (healthBar.gameObject.activeSelf)
            {
                healthBar.gameObject.SetActive(false);
                playerInfoText.gameObject.SetActive(false);
                ammoText.gameObject.SetActive(false);
                fpBar.gameObject.SetActive(false);
                shieldBar.gameObject.SetActive(false);
            }
            else
            {
                healthBar.gameObject.SetActive(true);
                playerInfoText.gameObject.SetActive(true);
                ammoText.gameObject.SetActive(true);
                fpBar.gameObject.SetActive(true);
                shieldBar.gameObject.SetActive(true);
            }
        }
    }
    public void UpdateHealthBar()
    {
        healthBar.value = player.curHp;
    }
    public void UpdateShieldBar()
    {
        shieldBar.value = player.curShield;
    }
    public void UpdatePlayerInfoText()
    {
        GameManager.instance.CheckWinCondition();
        if (GameManager.instance.pvp)
        {
            playerInfoText.text = "<b>Alive:</b> " + GameManager.instance.alivePlayers + "\n<b>Kills:</b> " + player.kills;
        }
        else
        {
            if(MissionManager.instance != null)
            {
                playerInfoText.text = "<b>Alive:</b> " + GameManager.instance.alivePlayers;
                LeaderBoard.instance.GetStatistics();
                playerInfoText.text = playerInfoText.text + "\n<b>Shards: <b>" + LeaderBoard.instance.shardCount;
                int enemiesLeft = MissionManager.instance.enemyAmount - MissionManager.instance.numEnemiesKilled;
                if (MissionManager.instance.killNumEnemies) { playerInfoText.text = playerInfoText.text + "\n<b>Enemies Remaining:</b> " + enemiesLeft; }
                if(MissionManager.instance.getToEnd) { playerInfoText.text = playerInfoText.text + "\n<b>Get To End</b> "; }
                if(MissionManager.instance.killBoss) { playerInfoText.text = playerInfoText.text + "\n<b>Kill Boss</b> "; }
                if (GameManager.instance.debug) { playerInfoText.text = playerInfoText.text + "\n<b>MISSION DEBUG:</b> " + MissionManager.instance.killNumEnemies + MissionManager.instance.getToEnd + MissionManager.instance.killBoss; }
                if (GameManager.instance.debug && MissionManager.instance.allMissionsComplete) { playerInfoText.text = playerInfoText.text + "\n<b>MISSION DEBUG:</b> AllMissionsComplete"; }
            }
            else
            {
                playerInfoText.text = "<b>CRITICAL GAMEMODE ERROR<b>";
            }
        }
    }
    public void UpdateAmmoText()
    {
        ammoText.text = player.weapon.curAmmo + " / " + player.weapon.maxAmmo;
    }
    public void EmergencyAmmoText()
    {
        StartCoroutine("ReloadText");
    }
    IEnumerator ReloadText()
    {
        ammoText.text = "RELOADING...";
        yield return new WaitForSeconds(1.66f);
        ammoText.text = "RELOADING..";
        yield return new WaitForSeconds(1.66f);
        ammoText.text = "RELOADING.";
        yield return new WaitForSeconds(1.66f);
        UpdateAmmoText();
    }
    public void UpdateFPAmmo()
    {
        //Implement a slider
        fpBar.value = player.weapon.curFpAmmo;
    }
    public void SetWinText(string winnerName)
    {
        winBackground.gameObject.SetActive(true);
        winText.text = winnerName + " WINS";
    }
    public void SetWinTextPVE()
    {
        winBackground.gameObject.SetActive(true);
        winText.text = "Mission Complete!";
    }
    public void SetMissionFailText()
    {
        winBackground.gameObject.SetActive(true);
        winText.text = "Mission FAILURE!";
    }
    public void DEBUG_DeactivateWinText()
    {
        winBackground.gameObject.SetActive(false);
    }
}
