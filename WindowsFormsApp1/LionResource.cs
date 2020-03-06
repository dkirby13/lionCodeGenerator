using System;
using System.Collections.Generic;

public class LionResource
{
    private string moduleName;
    private string url;
    private string resourceName;
    private bool get;
    private bool post;
    private bool put;
    private bool delete;
    private bool getSingle;
    private List<LionDataField> dataFields;

    public LionResource(string moduleName, string url, string resourceName, 
        bool get, bool post, bool put, bool delete, bool getSingle,
        List<LionDataField> dataFields)
    {
        this.DataFields = new List<LionDataField>();
        this.ResourceName = resourceName;
        this.ModuleName = moduleName;
        this.Url = url;
        this.Get = get;
        this.Post = post;
        this.Put = put;
        this.Delete = delete;
        this.GetSingle = getSingle;
        foreach (LionDataField dataField in dataFields) {
            this.DataFields.Add(dataField);
        }

	}

    public string ModuleName { get => moduleName; set => moduleName = value; }
    public string Url { get => url; set => url = value; }
    public string ResourceName { get => resourceName; set => resourceName = value; }
    public bool Get { get => get; set => get = value; }
    public bool Post { get => post; set => post = value; }
    public bool Put { get => put; set => put = value; }
    public bool Delete { get => delete; set => delete = value; }
    public bool GetSingle { get => getSingle; set => getSingle = value; }
    public List<LionDataField> DataFields { get => dataFields; set => dataFields = value; }
}
