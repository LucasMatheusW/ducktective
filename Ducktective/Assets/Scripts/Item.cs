using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName="Itens", menuName="Inventario/Item")]
public class Item : ScriptableObject
{
    public int id;
    public string nome;
    [TextArea]
    public string desc;
    public Sprite icon;
    public string dialog;
    public virtual void Use()
    {
        Debug.Log("Use "+nome);
        PlayerMove.textarea.SetActive(true);
        PlayerMove.textarea.transform.GetChild(1).GetComponent<Text>().text = nome;
        PlayerMove.textarea.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = desc;
    }
}
