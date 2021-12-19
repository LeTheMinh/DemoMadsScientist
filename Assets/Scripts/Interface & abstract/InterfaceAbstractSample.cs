using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class InterfaceAbstractSample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
public abstract class AbstactClassSample
{
    public int age;
    public string name
    {
        get
        {
            return "";
        }
    }
    public void ShowInfo()
    {

    }
    public virtual void Fire(int number)
    {

    }
    public abstract void Reload();
}
public class ChildAbstract :AbstactClassSample,IShootHandle,IReloadHandle
{
    public void Fire(bool isfire)
    {
        throw new System.NotImplementedException();
    }

    //public override void Fire(int number)
    //{
    //    base.Fire(number);
    //}
  
    public void Reload(float time)
    {
    
    }

    public override void Reload()
    {
       
    }
}

public interface IShootHandle
{
    void Fire(bool isfire);
}
public interface IReloadHandle
{
    void Reload(float time);
}
public class IAssaultHandle : IShootHandle,IReloadHandle
{
    public void Fire(bool isfire)
    {
     
    }

    public void Reload(float time)
    {
        
    }
}