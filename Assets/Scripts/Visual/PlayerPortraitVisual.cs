using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPortraitVisual : MonoBehaviour
{

    public CharacterAsset charAsset;
    [Header("Text Component References")]
    //public Text NameText;
    public Text HealthText;
    [Header("Image References")]
    public Image HeroPowerIconImage;
    public Image HeroPowerBackgroundImage;
    public Image PortraitImage;
    public Image PortraitBackgroundImage;

    void Awake()
    {
        if (charAsset != null)
        {
            ApplyLookFromAsset();
        }
    }

    public void ApplyLookFromAsset()
    {
        HealthText.text = charAsset.MaxHealth.ToString();
        HeroPowerIconImage.sprite = charAsset.HeroPowerIconImage;
        HeroPowerBackgroundImage.sprite = charAsset.HeroPowerBGImage;
        PortraitImage.sprite = charAsset.AvatarImage;
        PortraitBackgroundImage.sprite = charAsset.AvatarBGImage;

        HeroPowerBackgroundImage.color = charAsset.HeroPowerBGTint;
        PortraitBackgroundImage.color = charAsset.AvatarBGTint;

    }

    public void TakeDamage(int amount, int healthAfter)
    {
        if (amount > 0)
        {
            DamageEffect.CreateDamageEffect(transform.position, amount);
            HealthText.text = healthAfter.ToString();
        }
    }

    public void GiveLife(int amountForEffect, int healthAfter)
    {
        if (healthAfter < 30)
        {
            DamageEffect.CreateDamageEffect(transform.position, -amountForEffect);
            HealthText.text = healthAfter.ToString();
        }
        else
        {
            DamageEffect.CreateDamageEffect(transform.position, -amountForEffect);
            HealthText.text = "30";
        }
    }

    public void Explode()
    {
        Instantiate(GlobalSettings.Instance.ExplosionPrefab, transform.position, Quaternion.identity);
        Sequence s = DOTween.Sequence();
        s.PrependInterval(2f);
        s.OnComplete(() => GlobalSettings.Instance.GameOverPanel.SetActive(true));
    }

    public void HoldTurn(int targetID)
    {
        if (targetID == GlobalSettings.Instance.LowPlayer.PlayerID)
        {
            GlobalSettings.Instance.LowPlayer.skipTurn = true;
            GlobalSettings.Instance.LowPlayer.numberOfSkippedTurns++;
        }
        else
        {
            GlobalSettings.Instance.TopPlayer.skipTurn = true;
            GlobalSettings.Instance.TopPlayer.numberOfSkippedTurns++;
        }
    }

    public void HalfCreatureAttack(int targetID)
    {
        if (targetID == GlobalSettings.Instance.LowPlayer.PlayerID)
        {
            GlobalSettings.Instance.LowPlayer.halfAttack = true;
            GlobalSettings.Instance.LowPlayer.halfAttackTurns = 3;
            GlobalSettings.Instance.LowPlayer.HalfAttackCardsInHand();
        }
        else
        {
            GlobalSettings.Instance.TopPlayer.halfAttack = true;
            GlobalSettings.Instance.TopPlayer.halfAttackTurns = 3;
            GlobalSettings.Instance.TopPlayer.HalfAttackCardsInHand();
        }
    }



}
