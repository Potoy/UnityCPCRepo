using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Column : MonoBehaviour
{
    public Text m_title;
    public GameObject field;

    public void SetTitle(string newTitle)
    {
        m_title.text = newTitle;
    }

    public void SetFields(List<string> Campos)
    {
        foreach (var campo in Campos)
        {
           GameObject clone =  Instantiate(field, transform);
            clone.GetComponent<FieldScript>().SetTitle(campo);
        }
    }

}
