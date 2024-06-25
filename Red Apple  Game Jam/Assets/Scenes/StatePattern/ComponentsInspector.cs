
using System;
using UnityEngine;
[AttributeUsage(AttributeTargets.Field,AllowMultiple =false,Inherited =true)]
public class ComponentsInspector : PropertyAttribute
{
    public  bool visblity = false;
    public readonly string name;
    
    public ComponentsInspector(bool visblity,string name)
    {
        this.visblity = visblity;
        this.name = name;    
    }


}
