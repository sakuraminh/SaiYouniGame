using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class InputManageS : MSingleton<InputManageS>
{
    [SerializeField] protected float xHorizontal;
    public float XHorizontal => this.xHorizontal;

    [SerializeField] protected float yVertical;
    public float YVertical => this.yVertical;

    [SerializeField] protected bool mouseButton0;
    public bool MouseButton0 => this.mouseButton0;

    [SerializeField] protected bool fireDown1;
    public bool FireDown1 => this.fireDown1;

    [SerializeField] protected bool fireUp1;
    public bool FireUp1 => this.fireUp1;

    [SerializeField] protected bool tab;
    public bool Tab => this.tab;

    [SerializeField] protected bool mouseButton1;
    public bool MouseButton1 => this.mouseButton1;

    [SerializeField] protected bool mouseButtonDown1;
    public bool MouseButtonDown1 => this.mouseButtonDown1;

    protected virtual void Update()
    {
        this.LoadHorizontal();
        this.LoadVertical();
        this.LoadFireDown1();
        this.LoadFireUp1();
        this.LoadMouseButton0();
        this.LoadTab();
        this.LoadMouseButton1();
        this.LoadMouseButtonDown1();
    }

    protected virtual void FixedUpdate()
    {

    }
    protected virtual void LoadHorizontal()
    {
        this.xHorizontal = Input.GetAxis("Horizontal");
    }

    protected virtual void LoadVertical()
    {
        this.yVertical = Input.GetAxis("Vertical");
    }

    protected virtual void LoadFireDown1()
    {
        this.fireDown1 = Input.GetButtonDown("Fire1");
    }

    protected virtual void LoadFireUp1()
    {
        this.fireDown1 = Input.GetButtonUp("Fire1");
    }

    protected virtual void LoadMouseButton0()
    {
        this.mouseButton0 = Input.GetMouseButton(0);
    }

    protected virtual void LoadTab()
    {
        this.tab = Input.GetKeyDown(KeyCode.Tab);
    }

    protected virtual void LoadMouseButton1()
    {
        this.mouseButton1 = Input.GetMouseButton(1);
    }

    protected virtual void LoadMouseButtonDown1()
    {
        this.mouseButtonDown1 = Input.GetMouseButtonDown(1);
    }

}
