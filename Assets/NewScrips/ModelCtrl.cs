using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelCtrl : MMonoBehaviour
{
    [SerializeField] protected List<GameObject> magicBulletObj;
    public List<GameObject> MagicBulletObj => this.magicBulletObj;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.GetChildrenObj();
    }

    protected virtual void GetChildrenObj()
    {
        if (magicBulletObj != null) return;
        foreach (Transform children in transform)
        {
            this.magicBulletObj.Add(children.gameObject);
        }
    }
}
