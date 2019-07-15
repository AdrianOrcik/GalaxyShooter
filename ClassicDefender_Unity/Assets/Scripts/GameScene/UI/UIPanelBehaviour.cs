using UnityEngine;
using UnityEngine.UI;

public class UIPanelBehaviour : MainBehaviour
{
    public Image[] HealthsDot;
    public Image[] ShieldsDot;
    public Image WaveProgress;

    public BtnWrapper OnActiveShot;
    public BtnWrapper OnActiveMissile;

    public float ShotBtnActiveTimer = 0;
    public float MissileBtnActiveTimer = 0;

    private void Start()
    {
        OnActiveShot.btn.onClick.AddListener(ActiveShot);
        OnActiveShot.btn.interactable = false;

        OnActiveMissile.btn.onClick.AddListener(ActiveMissile);
        OnActiveMissile.btn.interactable = false;
    }

    public void SetHealth(int id, bool enable)
    {
        if (id >= 0)
        {
            HealthsDot[id].enabled = enable;
        }
    }

    public void SetShield(int id, bool enable)
    {
        ShieldsDot[id].enabled = enable;
    }

    public void SetWaveProgress(int killedEnemy, int totalEnemy)
    {
        float progress = (float) killedEnemy / (float) totalEnemy;
        WaveProgress.fillAmount = progress;
    }

    public void ActiveShot()
    {
        if (OnActiveShot.btn.interactable)
        {
            LevelManager.PlayerBehaviour.Weapons.SetWeaponType(ShipWeaponType.ThreeWayShot);
        }
    }

    public void ActiveMissile()
    {
        if (OnActiveMissile.btn.interactable)
        {
            LevelManager.PlayerBehaviour.Weapons.Missile();
        }
    }

    private void CastShotBonus()
    {
        ShotBtnActiveTimer += Time.deltaTime;
        if (ShotBtnActiveTimer >= Constants.SHOT_CAST_TIME)
        {
            OnActiveShot.btn.interactable = true;
        }
        else
        {
            OnActiveShot.btn.interactable = false;
        }

        if (OnActiveShot.bg.fillAmount < 1)
        {
            OnActiveShot.bg.fillAmount = (float) ShotBtnActiveTimer / (float) Constants.SHOT_CAST_TIME;
        }
    }

    private void CastMissileBonus()
    {
        MissileBtnActiveTimer += Time.deltaTime;
        if (MissileBtnActiveTimer >= Constants.MISSILE_CAST_TIME)
        {
            OnActiveMissile.btn.interactable = true;
        }
        else
        {
            OnActiveMissile.btn.interactable = false;
        }


        if (OnActiveMissile.bg.fillAmount < 1)
        {
            OnActiveMissile.bg.fillAmount = (float) MissileBtnActiveTimer / (float) Constants.MISSILE_CAST_TIME;
        }
    }

    private void Update()
    {
        CastShotBonus();
        CastMissileBonus();
    }
}