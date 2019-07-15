using System.Linq;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;


public class PlayerBehaviour : ShipBase
{
    public ShipDefinition ShipDefinition;
    public ShipRendererBehaviour ShipRendererBehaviour;
    public Weapons Weapons;
    public Vector3 PlayerMove;

    private float timer = 0f;
    private InputGameController playerController;

    private ShipStats ShipStats;

    /// <summary>
    /// Load Player Ship data from definition, init components and setup config data
    /// </summary>
    public void Init()
    {
        ShipDefinition =
            GameDefinitions.ShipDefinitions.FirstOrDefault(x => x.ID == LevelManager.PlayerDefitionPool.ID);

        ShipStats = new ShipStats(ShipDefinition.Health, ShipDefinition.Speed, ShipDefinition.ShootTime);
        Weapons = new Weapons(this, ShipDefinition);

#if UNITY_EDITOR
        playerController = new PlayerController();

#elif UNITY_ANDROID
        playerController = new PlayerMobileController();
#endif

        playerController.Init(this);

        ShipRendererBehaviour = GetComponentInChildren<ShipRendererBehaviour>();
        ShipRendererBehaviour.Init(this);
    }

    /// <summary>
    /// Update method check availability of weapons and refreshing player input 
    /// </summary>
    private void Update()
    {
        playerController.GameController();
        Weapons.Update();
        Shot();
    }

    public void Move(Vector3 direction)
    {
        transform.position += direction * Time.deltaTime * ShipStats.Speed;
    }

    public override void Kill()
    {
        ShipStats.Health -= 1;
        UIPanelBehaviour.SetHealth(ShipStats.Health, false);

        if (ShipStats.Health == 0)
        {
            ScreenManager.ActiveLoseScreen();
            LevelManager.OnEndLevel();
            gameObject.SetActive(false);
            return;
        }

        StartCoroutine(ShipRendererBehaviour.AnimColor(Color.red));
    }

    public void Shot()
    {
        if (timer >= ShipStats.ShootTime)
        {
            Weapons.Shot();
            timer = 0;
        }

        timer += Time.deltaTime;
    }
}