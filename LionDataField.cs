using System;

enum DataType
{
    INT = 0,
    STRING = 1,
    BOOL = 2,
    ENUM = 3
}

public class LionDataField
{
    string name;
    DataType dataType;
    string[] enumValues;

    public LionDataField(string name, DataType dataType, string enumString)
    {
        this.name = name;
        this.dataType = dataType;
        if (this.dataType == ENUM) { }
            // the trim function removes all whitespace, the ToUpper makes it uppercase, and the split function seperates all the values by commas
            enumValues = enumString.Trim().ToUpper().Split(',');
        }

	}
}
