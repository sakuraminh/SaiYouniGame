using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PAttack : PlayerAbs
{
    //[SerializeField] protected float timer = 0;
    //[SerializeField] protected float delay = 4f;

    //[SerializeField] protected Enemy target;
    //[SerializeField] protected Transform rot;

    //[SerializeField] protected bool isAttack;
    //[SerializeField] protected bool endAttack;

    //[SerializeField] protected string bulletName = "Bullet";


    //protected virtual void Update()
    //{
    //    this.GetTarget();
    //    this.AttackStatus();
    //    this.PWeaponShooting();
    //}
    //protected virtual void GetTarget()
    //{
    //    this.target = this.WeaponCtrl.PRadar.GetTarget();

    //}

    //protected virtual void PWeaponShooting()
    //{
    //    //if (this.timer < delay) this.timer += Time.deltaTime;
    //    //if (this.target == null) return;
    //    //if (this.timer < this.delay) return;
    //    //this.timer = 0;

    //    if (isAttack == true)
    //    {
    //        Debug.Log("is attack");

    //        //OnAnimationAttack();

    //        Vector3 spawnBullePointDown = GameCtrlS.Instance.PlayerCtrl.PFirePoint.PFirePointGun.transform.position;
    //        Quaternion spawnRot = GameCtrlS.Instance.PlayerCtrl.PFirePoint.PFirePointGun.transform.rotation;


    //        Effect newBullet = GameCtrlS.Instance.OPerentCtrl.EffectSpawner.Spawn(this.GetBullet(), spawnBullePointDown, spawnRot);
    //        newBullet.gameObject.SetActive(true);
    //    }

    //}

    //protected virtual Effect GetBullet()
    //{
    //    return GameCtrlS.Instance.OPerentCtrl.EffectPrefab.GetPrefabByName(this.bulletName);
    //}

    //protected virtual void LookAtTarget()
    //{
    //    if (this.target == null) return;
    //}

    //protected virtual void AttackStatus()
    //{
    //    if (Input.GetMouseButtonDown(0) == true || Input.GetMouseButton(0) == true)
    //        this.isAttack = true;

    //    else this.isAttack = false;
    //}
    //protected virtual void OnAnimationAttack()
    //{
    //    if (Input.GetKeyDown(KeyCode.Alpha1))
    //    {
    //        this.weaponCtrl.Animator.SetTrigger("isAttack");
    //    }
    //}
    //void Attack()
    //{

    //}


}
