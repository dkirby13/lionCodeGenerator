using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class DataParser
    {
        public static LionDataField dataPanelToDataField(Panel rowPanel)
        {
            string name = "";
            string dataTypeText;
            DataType dataType = DataType.NONE;
            string enumString = "";
            foreach (Control control in rowPanel.Controls)
            {
                if (control.Name.Contains("nameTextBox"))
                {
                    name = ((TextBox)control).Text;
                }
                else if (control.Name.Contains("typeComboBox"))
                {
                    dataTypeText = ((ComboBox)control).Text;
                    if (dataTypeText == "int")
                    {
                        dataType = DataType.INT;
                    }
                    else if (dataTypeText == "bool")
                    {
                        dataType = DataType.BOOL;
                    }
                    else if (dataTypeText == "enum")
                    {
                        dataType = DataType.ENUM;
                    }
                    else if (dataTypeText == "string")
                    {
                        dataType = DataType.STRING;
                    }
                }
                else if (control.Name.Contains("enumTextBox"))
                {
                    enumString = ((TextBox)control).Text;
                }
            }
            return new LionDataField(name, dataType, enumString);
        }
        public static LionResource startPageToResource(startPage startPage)
        {
            string moduleName = "";
            string url = "";
            string resourceName = "";
            bool get = false;
            bool post = false;
            bool put = false;
            bool delete = false;
            bool getSingle = false;
            List<LionDataField> dataFields = new List<LionDataField>(); ;
            foreach (Control control in startPage.Controls)
            {
                if (control.Name == "resourceNameTextBox")
                {
                    resourceName = ((TextBox)control).Text;
                }
                if (control.Name == "moduleComboBox")
                {
                    moduleName = ((ComboBox)control).Text;
                }
                if (control.Name == "urlTextBox")
                {
                    url = ((TextBox)control).Text;
                }
                if (control.Name == "getCheckBox")
                {
                    get = ((CheckBox)control).Checked;
                }
                if (control.Name == "postCheckBox")
                {
                    post = ((CheckBox)control).Checked;
                }
                if (control.Name == "putCheckBox")
                {
                    put = ((CheckBox)control).Checked;
                }
                if (control.Name == "deleteCheckBox")
                {
                    delete = ((CheckBox)control).Checked;
                }
                if (control.Name == "getSingleCheckBox")
                {
                    getSingle = ((CheckBox)control).Checked;
                }
                if (control.Name == "listPanel")
                {
                    foreach (Control dataPanel in ((Panel)control).Controls)
                    {
                        if (dataPanel.Name.Contains("rowPanel"))
                        {
                            dataFields.Add(dataPanelToDataField((Panel)dataPanel));
                        }
                    }
                }
            }
            return new LionResource(moduleName, url, resourceName, get, post, put, delete, getSingle, dataFields);
        }
        public static string toSnakeCase(string stringToConvert)
        {
            //create underscored value IE contactLog --> contact_log
            string snakeCaseString = "";
            for (int i = 0; i < stringToConvert.Length; i++)
            {
                if (Char.IsUpper(stringToConvert[i]))
                {
                    snakeCaseString += "_";
                    snakeCaseString += char.ToLower(stringToConvert[i]);
                }
                else
                {
                    snakeCaseString += stringToConvert[i];
                }
            }
            return snakeCaseString;
        }
    }

}
