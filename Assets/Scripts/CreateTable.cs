using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json.Linq;
using System.Linq;
using UnityEngine.UIElements;

[System.Serializable]
public class CreateTable : MonoBehaviour
{
    public Text tableTitle;
    public GameObject columnsContainer;
    public GameObject column;
    private List<GameObject> columnReference;

    private void SetColumns()
    {
        string path = Path.Combine(Application.streamingAssetsPath, "JsonChallenge.json");
        string jsonString = File.ReadAllText(path);
        var jsonObject = JObject.Parse(jsonString);
        

        List<List<string>> data = new List<List<string>>();
        List<string> columnHeaders = new List<string>();

        foreach (var item in jsonObject["ColumnHeaders"])
        {
            columnHeaders.Add(item.ToString());
        }

        foreach (var item in jsonObject["Data"])
        {
            List<string> aux = new List<string>();

            for (int i = 0; i < columnHeaders.Count; ++i)
            {
                if (item[columnHeaders[i]] !=null)
                    aux.Add(item[columnHeaders[i]].ToString());
            }

            data.Add(aux);
        }

        //transpose de una lista de listas, 
        var transposeData = data.SelectMany(inner => inner
                                .Select((item, index) => new { item, index }))
                                .GroupBy(i => i.index, i => i.item)
                                .Select(g => g.ToList()).ToList();
        
        SetMainTitle(jsonObject["Title"].ToString());


        int j = 0;
        foreach (var item in columnHeaders)
        {
           GameObject clone =  Instantiate(column, columnsContainer.transform);
            clone.GetComponent<Column>().SetTitle(item);
            if (j < transposeData.Count)
            {  
                clone.GetComponent<Column>().SetFields(transposeData[j]);
                j++;
            }

            columnReference.Add(clone);
        }

    }

    public void reloadJson() 
    {
        foreach (var item in columnReference)
        {
            Destroy(item);
        }
        columnReference.Clear();
        SetMainTitle("Place_holder");
        SetColumns();
    }

    public void quitGame() 
    {
        Application.Quit();
    }

    private void SetMainTitle(string mainTitle)
    {
        tableTitle.text = mainTitle;
    }

    // Start is called before the first frame update
    void Start()
    {
        columnReference = new List<GameObject>();
        SetColumns();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}




