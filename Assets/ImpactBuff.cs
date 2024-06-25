using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]

public class ImpactBuff : LoadWarriorController
{
	[SerializeField] protected Rigidbody2D rigidComponent;
	[SerializeField] protected BoxCollider2D boxComponent;
	[SerializeField] protected bool isSleep;
	[SerializeField] protected float sleepTime;
	[SerializeField] protected float buffTime;
	[SerializeField] protected Animator animatorObject;
	[SerializeField] protected List<GameObject> warriors;

	protected const float MAX_SLEEP = 3f;
	protected const float MAX_BUFF = 6f;

	protected override void LoadComponents()
	{
		base.LoadComponents();
		this.LoadRigidbody2D();
		this.LoadBoxCollider2D();
		this.LoadAnimator();
		Buff();
		isSleep = false;
		sleepTime = 0.0f;
		buffTime = 0.0f;
	}

	protected virtual void LoadRigidbody2D()
	{
		if (this.rigidComponent != null) return;
		this.rigidComponent = GetComponent<Rigidbody2D>();
		this.rigidComponent.isKinematic = true;
		Debug.Log(transform.name + ": Load Rigibody2D", gameObject);
	}

	protected virtual void LoadBoxCollider2D()
	{
		if (this.boxComponent != null) return;
		this.boxComponent = GetComponent<BoxCollider2D>();
		this.boxComponent.isTrigger = true;
		Debug.Log(transform.name + ": Load BoxCollider2D", gameObject);
	}

	protected virtual void LoadAnimator()
	{
		if (this.animatorObject != null) return;
		this.animatorObject = transform.parent.Find("Model").GetComponent<Animator>();
		Debug.Log(transform.name + ": Load Animator", gameObject);
	}

	protected override void LoadWarriorCtrl()
	{
		if (this.warriorCtrl != null) return;
		this.warriorCtrl = transform.parent.GetComponent<WarriorController>();
		Debug.Log(transform.name + ": Load WarriorController", gameObject);
	}

	protected virtual void OnTriggerEnter2D(Collider2D collision)
	{
		WarriorDamagedReceiver wdr = collision.transform.GetComponent<WarriorDamagedReceiver>();
		if (wdr == null) return;
		warriors.Add(wdr.gameObject);
	}
	private void OnTriggerExit2D(Collider2D collision)
	{
		WarriorDamagedReceiver wdr = collision.transform.GetComponent<WarriorDamagedReceiver>();
		if (wdr == null) return;
		warriors.Remove(wdr.gameObject);

	}

	private void Update()
	{

		if (isSleep)
		{
			sleepTime += Time.deltaTime;
			TimeUp(ref sleepTime, MAX_SLEEP);
		}
		else
		{
			foreach (var w in warriors)
			{
				w.GetComponent<WarriorDamagedReceiver>().Add(30);
			}
			buffTime += Time.deltaTime;
			TimeUp(ref buffTime, MAX_BUFF);
		}
	}

	private void TimeUp(ref float time, float max)
	{
		if (time >= max)
		{
			time = 0;
			isSleep = !isSleep;
			if (isSleep) { Sleep(); }
			else { Buff(); }
		}

	}

	protected virtual void Buff()
	{
		this.animatorObject.SetTrigger("isBuff");
	}

	protected virtual void Sleep()
	{
		this.animatorObject.SetTrigger("isDestroyBuff");
	}
}
