using UnityEngine;
using UnityEngine.UI;

public class SpellCooldown : AutoMonoBehaviour
{
    [SerializeField] protected Image imageCooldown;
    [SerializeField] protected float coolDownTimeMax = 2f;
    [SerializeField] protected float coolDownTime;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadImageCoolDown();
    }

    public virtual void ChangeCoolDownTime(float time)
    {
        this.coolDownTimeMax = time;
        this.ResetCoolDown();
    }

    protected virtual void LoadImageCoolDown()
    {
        if (this.imageCooldown != null) return;
        this.imageCooldown = transform.parent.Find("Model").GetComponent<Image>();
        Debug.Log(transform.name + ": Load Image", gameObject);
    }

    protected virtual void OnEnable()
    {
        this.ResetCoolDown();
    }

    protected virtual void ResetCoolDown()
    {
        this.imageCooldown.fillAmount = 1;
        this.coolDownTime = this.coolDownTimeMax;
    }

    protected virtual void Update()
    {
        this.ApplyCooldown();
        if (this.coolDownTime > 0) return;
        WarriorCDSetActive.Instance.SetObjectActive(transform.parent.name, Vector3.zero, transform.rotation, false);
    }

    protected virtual void ApplyCooldown()
    {
        this.coolDownTime -= Time.deltaTime;
        this.imageCooldown.fillAmount = this.coolDownTime / this.coolDownTimeMax;
    }
}
