using UnityEngine;
using UnityEngine.UI;

public class FieldScript : MonoBehaviour
{
    public Text m_title;

    public void SetTitle(string newTitle)
    {
        m_title.text = newTitle;
    }
}
