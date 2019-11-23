using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="Itens", menuName="Inventario/Item")]
public class Item : ScriptableObject
{
    public string nome;
    public string desc;
    public Sprite icon;

    public virtual void Use()
    {
        Debug.Log("Use "+nome);
    }
}
