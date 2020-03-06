using System;
using System.Collections.Generic;

public enum DataType
{
    NONE = 0,
    INT = 1,
    STRING = 2,
    BOOL = 3,
    ENUM = 4
}

public class LionDataField
{
    string name;
    DataType dataType;
    List<string> enumValues;

    public LionDataField(string name, DataType dataType, string enumString)
    {
        this.Name = name;
        this.DataType = dataType;
        if (this.DataType == DataType.ENUM) {
            // the trim function removes all whitespace, the ToUpper makes it uppercase, and the split function seperates all the values by commas
            EnumValues = new List<string>(enumString.Trim().ToUpper().Split(','));
        }

    }

    public string Name { get => name; set => name = value; }
    public DataType DataType { get => dataType; set => dataType = value; }
    public List<string> EnumValues { get => enumValues; set => enumValues = value; }

}
