using System;
using System.IO;
using WindowsFormsApp1;

public class CodeGenerator
{
	private LionResource lionResource;
	private string capitalizedString;
	private string fulltypeNameString;
	public CodeGenerator(LionResource lionResource)
	{
		this.lionResource = new LionResource(lionResource.ModuleName, lionResource.Url, lionResource.ResourceName,
			lionResource.Get, lionResource.Post, lionResource.Put, lionResource.Delete, lionResource.GetSingle, lionResource.DataFields);

		//create the capitalized string IE contactLog --> ContactLog
		this.capitalizedString = char.ToUpper(this.lionResource.ResourceName[0]) + this.lionResource.ResourceName.Substring(1);
		//create the capitalized string IE contactLog --> D2FSP_ContactLog
		this.fulltypeNameString = this.lionResource.ModuleName.ToUpper() + "_" + this.capitalizedString;
	}
	
	//might save for later
	private void generateParse(string folderToSaveTo)
	{

	}

	private void generateApacheMod(string folderToSaveTo)
	{

	}

	private void generateApacheModC(string folderToSaveTo)
	{

	}

	private void generateModP(string folderToSaveTo)
	{

	}

	private void generateJson(string folderToSaveTo)
	{

	}

	private void generateJsonStringH(string folderToSaveTo)
	{
		string fileText = "";
		string fileFunctionText = "";
		//generate the .h
		fileText = fileText + "typedef struct {\n";
		foreach (LionDataField dataField in this.lionResource.DataFields)
		{
			fileText = fileText + "    const char *" + dataField.Name + ";\n";

			//for each enum create the three function header

			if (dataField.DataType == DataType.ENUM)
			{
				string enumCapatalizedString = char.ToUpper(dataField.Name[0]) + dataField.Name.Substring(1);

				string enumTypeNameString = this.lionResource.ModuleName.ToUpper() + "_" + enumCapatalizedString;
				//create to string function header
				fileFunctionText = fileFunctionText + "const char* _" + this.lionResource.ModuleName.ToUpper() + "_json" +
					enumCapatalizedString + "ToString(\n"
					+ "    " + enumTypeNameString + " typeEnum);\n\n";

				//create json type function header
				fileFunctionText = fileFunctionText + "OSAL_Status _" + this.lionResource.ModuleName.ToUpper() + "_jsonGet" +
					enumCapatalizedString + "(\n"
					+ "    json_t            *jsonString_ptr,\n"
					+ "    const char        *key_ptr,\n"
					+ "    " + enumTypeNameString + "         *dest_ptr);\n\n";


				//create By string function header
				fileFunctionText = fileFunctionText + enumTypeNameString
					+ " _" + this.lionResource.ModuleName.ToUpper() + "_jsonGet" + enumCapatalizedString + "ByString(\n"
					+ "    const char *value_ptr);\n\n";
			}
		}

		fileText = fileText + "} _" + this.lionResource.ModuleName.ToUpper() + "_json" + this.capitalizedString + "Keys;\n\n";

		fileText = fileText + "extern const _" + this.lionResource.ModuleName.ToUpper() + "_json" + this.capitalizedString + "Keys ";
		fileText = fileText + "_" + this.lionResource.ModuleName.ToLower() + "Json" + this.capitalizedString + "Keys;\n\n";

		string fileName = "_" + this.lionResource.ModuleName.ToLower() + "_" + "json_string.h";
		//string filePath = folderToSaveTo + fileName;
		using (StreamWriter outputFile = new StreamWriter(Path.Combine(folderToSaveTo, fileName)))
		{
			outputFile.WriteLine(fileText + fileFunctionText);
		}
	}
	private void generateJsonStringC(string folderToSaveTo)
	{
		//create the message string based on the requests neeeded
		string messageText = "";
		if (lionResource.Get == true)
		{
			messageText += "        [" + this.lionResource.ModuleName + "_MSG_GET_" + this.lionResource.ResourceName.ToUpper() + "_LIST_REQUEST] = " +
				"\"get" + this.capitalizedString + "ListRequest\"\n";
			messageText += "        [" + this.lionResource.ModuleName + "_MSG_GET_" + this.lionResource.ResourceName.ToUpper() + "_LIST_RESPONSE] = " +
				"\"get" + this.capitalizedString + "ListResponse\"\n";
		}
		if (lionResource.Post == true)
		{
			messageText += "        [" + this.lionResource.ModuleName + "_MSG_CREATE_" + this.lionResource.ResourceName.ToUpper() + "_REQUEST] = " +
				"\"create" + this.capitalizedString + "Request\"\n";
			messageText += "        [" + this.lionResource.ModuleName + "_MSG_CREATE_" + this.lionResource.ResourceName.ToUpper() + "_RESPONSE] = " +
				"\"create" + this.capitalizedString + "Response\"\n";
		}
		if (lionResource.Put == true)
		{
			messageText += "        [" + this.lionResource.ModuleName + "_MSG_UPDATE_" + this.lionResource.ResourceName.ToUpper() + "_REQUEST] = " +
				"\"update" + this.capitalizedString + "Request\"\n";
			messageText += "        [" + this.lionResource.ModuleName + "_MSG_UPDATE_" + this.lionResource.ResourceName.ToUpper() + "_RESPONSE] = " +
				"\"update" + this.capitalizedString + "Response\"\n";
		}
		if (lionResource.Delete == true)
		{
			messageText += "        [" + this.lionResource.ModuleName + "_MSG_DELETE_" + this.lionResource.ResourceName.ToUpper() + "_REQUEST] = " +
				"\"delete" + this.capitalizedString + "Request\"\n";
			messageText += "        [" + this.lionResource.ModuleName + "_MSG_DELETE_" + this.lionResource.ResourceName.ToUpper() + "_RESPONSE] = " +
				"\"delete" + this.capitalizedString + "Response\"\n";
		}
		if (lionResource.GetSingle == true)
		{
			messageText += "        [" + this.lionResource.ModuleName + "_MSG_GET_SINGLE_" + this.lionResource.ResourceName.ToUpper() + "_REQUEST] = " +
				"\"getSingle" + this.capitalizedString + "Request\"\n";
			messageText += "        [" + this.lionResource.ModuleName + "_MSG_GET_SINGLE_" + this.lionResource.ResourceName.ToUpper() + "_RESPONSE] = " +
				"\"getSingle" + this.capitalizedString + "Response\"\n";
		}
		messageText += "\n";

		//create the resourceKeys
		string keysText = "const _" + this.lionResource.ModuleName.ToUpper() + "_json" + this.capitalizedString + "Keys "
			+ this.lionResource.ModuleName.ToLower() + "Json" + this.capitalizedString + "Keys = {\n";
		foreach (LionDataField dataField in this.lionResource.DataFields)
		{
			keysText += "        ." + dataField.Name + " = " + "\"" + DataParser.toSnakeCase(dataField.Name) + "\",\n";
		}
		keysText += "};\n\n";


		//create the enumKeys and enumFunctions
		string enumKeys = "";
		string enumFunctions = "";
		foreach (LionDataField dataField in this.lionResource.DataFields)
		{ 
			if (dataField.DataType == DataType.ENUM)
			{
				string enumCapatalizedString = char.ToUpper(dataField.Name[0]) + dataField.Name.Substring(1);

				string enumTypeNameString = this.lionResource.ModuleName.ToUpper() + "_" + enumCapatalizedString;

				enumKeys += "static const char *_" + this.lionResource.ModuleName.ToUpper() + "JsonEnumKey_" + dataField.Name + "[] = {\n";
				enumKeys += "        [" + this.lionResource.ModuleName.ToUpper() + "_" + DataParser.toSnakeCase(dataField.Name).ToUpper() + "_INVALID]" +
					" = \"invalid\",\n";

				foreach (string enumValue in dataField.EnumValues)
				{
					enumKeys += "        [" + this.lionResource.ModuleName.ToUpper() + "_" + DataParser.toSnakeCase(dataField.Name).ToUpper() + "_" +
						DataParser.toSnakeCase(enumValue).ToUpper() + "] = \"" +
						DataParser.toSnakeCase(enumValue).ToLower() + "\",\n";
				}

				enumKeys += "};\n";
				enumKeys += "static int _" + lionResource.ModuleName.ToUpper() + "JsonEnumCount_" + dataField.Name + "= sizeof(" +
					lionResource.ModuleName.ToUpper() + "JsonEnumKey_" + dataField.Name + ") / sizeof(char*);\n\n";

				//create to string function 
				enumFunctions += "const char* _" + this.lionResource.ModuleName.ToUpper() + "_json" +
					enumCapatalizedString + "ToString(\n{\n"
					+ "    " + enumTypeNameString + " typeEnum)\n";
				enumFunctions += "    return _" + this.lionResource.ModuleName.ToUpper() + "JsonEnumKey_" + dataField.Name + "[typeEnum];\n}\n\n";

				//create json type function 
				enumFunctions = enumFunctions + "OSAL_Status _" + this.lionResource.ModuleName.ToUpper() + "_jsonGet" +
					enumFunctions + "(\n"
					+ "    json_t            *jsonString_ptr,\n"
					+ "    const char        *key_ptr,\n"
					+ "    " + enumTypeNameString + "         *dest_ptr)\n{\n";
				enumFunctions += "    int index = _jsonStringToEnumIndex(jsonString_ptr, key_ptr,\n    " +
					"_" + lionResource.ModuleName.ToLower() + "JsonEnumKey_" + enumCapatalizedString + ", " +
					"_" + lionResource.ModuleName.ToLower() + "JsonEnumCount_" + enumCapatalizedString + ");\n    " +
					"if (index < 0 {\n        return (OSAL_FAIL);\n    }\n    " + "*dest_ptr = (" + lionResource.ModuleName.ToUpper() + "_" +
					enumCapatalizedString + ") index;\n    return (OSAL_SUCESS);\n}\n\n";

				//create By string function 
				enumFunctions += enumTypeNameString
					+ " _" + this.lionResource.ModuleName.ToUpper() + "_jsonGet" + enumCapatalizedString + "ByString(\n"
					+ "    const char *value_ptr)\n{\n    "
					+ enumTypeNameString + "type;\n\n    "
					+ "if (-1 == (type = _stringToEnumIndex(value_ptr, _" + lionResource.ModuleName.ToLower() + "jsonEnumKey_" + enumCapatalizedString + ",\n        " + 
					"_" + lionResource.ModuleName.ToLower() + "jsonEnumCount_" + enumCapatalizedString + "))) {\n        " +
					"return (" + lionResource.ModuleName.ToUpper() + DataParser.toSnakeCase(dataField.Name).ToUpper() + "_INVALID);\n    " + 
					"}\n    " +
					"return (type);\n}\n\n";

			}
		}
		string fileName = "_" + this.lionResource.ModuleName.ToLower() + "_" + "json_string.c";
		//string filePath = folderToSaveTo + fileName;
		using (StreamWriter outputFile = new StreamWriter(Path.Combine(folderToSaveTo, fileName)))
		{
			outputFile.WriteLine(messageText + keysText + enumKeys + enumFunctions);
		}
	}

	private void generateServerClient(string folderToSaveTo)
	{

	}

	private void generateServerDb(string folderToSaveTo)
	{

	}

	public void Generate(string folderToSaveTo)
	{
		generateJsonStringH(folderToSaveTo);
		generateJsonStringC(folderToSaveTo);
	}
}
