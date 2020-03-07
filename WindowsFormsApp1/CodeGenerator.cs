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

	private void generateJsonH(string folderToSaveTo)
	{
	}

	private void generateJsonC(string folderToSaveTo)
	{
		string encodeSingleFunction = "";
		//create encode single function
		encodeSingleFunction += "static json_t* _jsonEncode" + capitalizedString + "(\n    "
			+ fulltypeNameString + " *" + lionResource.ResourceName + "_ptr)\n{\n    char bufferStr[_JSON_UINT32_STR_SIZE];\n    "
			+ "json_t *json" + this.capitalizedString + "_ptr = json_object();\n    "
			+ "if (NULL != " + lionResource.ResourceName + "_ptr) {\n        ";
		//for each dataField encode based on type
		foreach (LionDataField dataField in this.lionResource.DataFields)
		{
			if (dataField.DataType == DataType.STRING)
			{
				encodeSingleFunction += "if (NULL != " + lionResource.ResourceName + "_ptr->" + dataField.Name + "_ptr) {\n            "
					+ "json_object_set_new(json" + lionResource.ResourceName + "_ptr, _" + lionResource.ModuleName.ToLower()
					+ "Json" + capitalizedString + "Keys." + dataField.Name + ",\n                "
					+ "json_string(" + lionResource.ResourceName + "_ptr->" + dataField.Name + "_ptr));\n        "
					+ "}\n        ";
			}
			if (dataField.DataType == DataType.BOOL)
			{
				encodeSingleFunction += "if (OSAL_TRUE == " + lionResource.ResourceName + "_ptr->" + dataField.Name + ") {\n            "
				+ "json_object_set_new(json" + lionResource.ResourceName + "_ptr, _" + lionResource.ModuleName.ToLower()
				+ "Json" + capitalizedString + "Keys." + dataField.Name + ",\n                "
				+ "json_boolean(JSON_TRUE));\n        "
				+ "}\n        ";
			}
			if (dataField.DataType == DataType.ENUM)
			{
				encodeSingleFunction += "if ("+ lionResource.ModuleName.ToUpper() +  "_" + DataParser.toSnakeCase(dataField.Name).ToUpper() + "_INVALID" 
					+ " != " + lionResource.ResourceName + "_ptr->" + dataField.Name + ") {\n            "
					+ "json_object_set_new(json" + lionResource.ResourceName + "_ptr, _" + lionResource.ModuleName.ToLower()
					+ "Json" + capitalizedString + "Keys." + dataField.Name + ",\n                "
					+ "json_string(_" + lionResource.ModuleName.ToUpper() + "_json" 
					+ (char.ToUpper(dataField.Name[0]) + dataField.Name.Substring(1)) + "ToString("
				    + lionResource.ResourceName + "_ptr->" + dataField.Name + ")));\n        "
					+ "}\n        ";
			}
			if (dataField.DataType == DataType.INT)
			{
				encodeSingleFunction += "if (0 < " + lionResource.ResourceName + "_ptr->" + dataField.Name + ") {\n            "
					+ "OSAL_snprintf(bufferStr, sizeof(bufferStr), \"%u\", " + lionResource.ResourceName + "_ptr->" + dataField.Name + ");\n            "
					+ "json_object_set_new(json" + lionResource.ResourceName + "_ptr, _" + lionResource.ModuleName.ToLower()
					+ "Json" + capitalizedString + "Keys." + dataField.Name + ",\n                "
					+ "json_string(bufferStr));\n        "
					+ "}\n        ";
			}
		}
		encodeSingleFunction += "\n    }\n\n    return json" + capitalizedString + "_ptr;\n}\n\n";

		//create the decode function
		string decodeSingleFunction = "static OSAL_Status _decode" + capitalizedString + "(\n    "
			+ "json_t        *json" + capitalizedString + "_ptr,\n    "
			+ this.fulltypeNameString + "    *" + lionResource.ResourceName + "_ptr)\n{\n    ";

		foreach (LionDataField dataField in lionResource.DataFields)
		{
			if (dataField.DataType == DataType.STRING)
			{
				decodeSingleFunction += "_" + lionResource.ModuleName.ToUpper() + "_jsonDecodeString(json" + capitalizedString + "_ptr, _"
					+ lionResource.ModuleName.ToLower() + "Json" + capitalizedString + "Keys." + dataField.Name + ", &("
					+ lionResource.ResourceName + "_ptr->" + dataField.Name + "_ptr));\n    " ;
			}
			if (dataField.DataType == DataType.BOOL)
			{
				decodeSingleFunction += "_" + lionResource.ModuleName.ToUpper() + "_jsonDecodeBoolean(json" + capitalizedString + "_ptr, _"
					+ lionResource.ModuleName.ToLower() + "Json" + capitalizedString + "Keys." + dataField.Name + ", &("
					+ lionResource.ResourceName + "_ptr->" + dataField.Name + "));\n    ";
			}
			if (dataField.DataType == DataType.ENUM)
			{
				decodeSingleFunction += "_" + lionResource.ModuleName.ToUpper() + "_jsonGet" 
					+ char.ToUpper(dataField.Name[0]) + dataField.Name.Substring(1)
					+ "(json" + capitalizedString + "_ptr, _"
					+ lionResource.ModuleName.ToLower() + "Json" + capitalizedString + "Keys." + dataField.Name + ", &("
					+ lionResource.ResourceName + "_ptr->" + dataField.Name + "));\n    ";
			}
			if (dataField.DataType == DataType.INT)
			{
				decodeSingleFunction += "_" + lionResource.ModuleName.ToUpper() + "_jsonDecodeUint32(json" + capitalizedString + "_ptr, _"
					+ lionResource.ModuleName.ToLower() + "Json" + capitalizedString + "Keys." + dataField.Name + ", &("
					+ lionResource.ResourceName + "_ptr->" + dataField.Name + "));\n    ";
			}
		}

		decodeSingleFunction += "\n    return OSAL_SUCCESS;\n}\n\n";

		//create the encode wrapper function
		string encodeWrapperFunction = "int32 _" + lionResource.ModuleName.ToUpper() + "_jsonEncode" + this.capitalizedString + "(\n    "
			+ fulltypeNameString + "        *" + lionResource.ResourceName + "_ptr,\n    "
			+ "char         *payload_ptr,\n    "
			+ "uint32        maxBufferSize)\n{\n    "
			+ "json_t* payloadJson_ptr = json_object();\n    json_object_set_new(payloadJson_ptr, _" + lionResource.ModuleName.ToLower() + "Json" + capitalizedString
			+ "Keys." + lionResource.ResourceName + ", _encode" + capitalizedString + "(" + lionResource.ResourceName + "_ptr));\n\n    "
			+ "char *dump_ptr = json_dumps(payloadJson_ptr, JSON_PRESERVE_ORDER);\n    "
			+ "int32 jsonSize = OSAL_strlen(dump_ptr) + 1; //strlen does not include the \\0 character\n    "
			+ "json_decref(payloadJson_ptr);\n\n    "
			+ "/*check if the payload can fit*/\n    "
			+ "if (jsonSize > maxBufferSize) {"
			+ "OSAL_LOG_MSG_ERR(\"JSON encoded request does not fit in the buffer. JSON size: % u, Buffer size: % u\",\n                "
			+ "jsonSize, maxBufferSize);\n        "
			+ "OSAL_memFree(dump_ptr, 0);\n        "
			+ "return -1;\n    }\n    "
			+ "OSAL_strncpy(payload_ptr, dump_ptr, jsonSize);\n    "
			+ "OSAL_memFree(dump_ptr, 0);\n    "
			+ "return jsonSize;\n}\n\n";

		//create the decode wrapper function
		string decodeWrapperFunction = fulltypeNameString + "* _" + lionResource.ModuleName.ToUpper() + "_jsonDecode" + capitalizedString + "(\n    "
			+ "const char     *buffer_ptr)\n{\n    "
			+ "json_error_t error;\n    "
			+ "json_t *json" + capitalizedString + "_ptr = json_loads(buffer_ptr, 0, &error);\n    "
			+ "if (NULL == json" + capitalizedString + "_ptr) {\n        "
			+ "OSAL_LOG_MSG_ERR(\"libjansson could not parse the JSON request body: % s\", buffer_ptr);\n        "
			+ "return (OSAL_FAIL);\n    }\n    "
			+ fulltypeNameString + " *return" + capitalizedString + "_ptr = OSAL_memCalloc(1, sizeof(" + fulltypeNameString + "), 0);\n    "
			+ "json_t *json" + capitalizedString + "Object_ptr = json_object_get(json" + capitalizedString + "_ptr, _" + lionResource.ModuleName.ToLower()
			+ "Json" + capitalizedString + "Keys." + lionResource.ResourceName + ");\n    "
			+ "_decode" + capitalizedString + "(json" + capitalizedString + "Object_ptr, return" + capitalizedString + "_ptr);\n    "
			+ "return return" + capitalizedString + "_ptr;\n}\n\n";

		//if get is set, create encodeList, decodelist, encodeList wrapper, and decodeList wrapper
		string listFunctions = "";
		if (lionResource.Get == true)
		{
			//create encode list function
			listFunctions += "static json_t* _encode" + capitalizedString + "List(\n    "
				+ fulltypeNameString + "List *" + lionResource.ResourceName + "List_ptr)\n{\n    "
				+ "char bufferStr[_JSON_UINT32_STR_SIZE];\n    "
				+ "json_t *retPayload_ptr = json_object();\n\n    "
				+ "/*Create the json array*/\n    "
				+ "json_t *" + lionResource.ResourceName + "Payload_ptr = NULL;\n    "
				+ "json_t *" + lionResource.ResourceName + "JsonArray_ptr = json_array();\n    " 
				+ "for (int i = 0; i < " + lionResource.ResourceName + "List_ptr->count; i++) {\n        "
				+ lionResource.ResourceName + "Payload_ptr = _encode" + capitalizedString + "(" + lionResource.ResourceName + "List_ptr->list_ptr[i]);\n        "
				+ "json_array_append(" + lionResource.ResourceName + "JsonArray_ptr, " + lionResource.ResourceName + "Payload_ptr);\n    }\n\n    "
				+ "/* Encode array into payload */\n    "
				+ "json_object_set_new(retPayload_ptr, _" + lionResource.ModuleName.ToLower() + "Json" + capitalizedString + "ListKeys." + lionResource.ResourceName + ",\n            "
				+ lionResource.ResourceName + "JsonArray_ptr);\n\n    "
				+ "/* Encode nextId if present */\n    "
				+ "if (" + lionResource.ResourceName + "List_ptr->nextId > 0) {\n        "
				+ "OSAL_snprintf(bufferStr, sizeof(bufferStr), \"%u\", " + lionResource.ResourceName + "List_ptr->nextId);\n        "
				+ "json_object_set_new(retPayload_ptr, _" + lionResource.ModuleName.ToLower() + "Json" + capitalizedString + "ListKeys.nextId,\n            "
				+ "json_string(bufferStr));\n    }\n\n    "
				+ "return retPayload_ptr;\n}\n\n";
		}


		string fileName = "_" + this.lionResource.ModuleName.ToLower() + "_" + "json.c";
		using (StreamWriter outputFile = new StreamWriter(Path.Combine(folderToSaveTo, fileName)))
		{
			outputFile.WriteLine(encodeSingleFunction + decodeSingleFunction + encodeWrapperFunction + decodeWrapperFunction + listFunctions);
		}
	}

	private void generateJsonStringH(string folderToSaveTo)
	{
		string fileText = "";
		string fileFunctionText = "";
		//generate the .h
		fileText = fileText + "typedef struct {\n";
		fileText = fileText + "    const char *" + lionResource.ResourceName + ";\n";
		foreach (LionDataField dataField in this.lionResource.DataFields)
		{
			fileText = fileText + "    const char *" + dataField.Name + ";\n";

			//for each enum create the three function header

			if (dataField.DataType == DataType.ENUM)
			{
				string enumCapatalizedString = char.ToUpper(dataField.Name[0]) + dataField.Name.Substring(1);

				string enumTypeNameString = this.lionResource.ModuleName.ToUpper() + "_" + enumCapatalizedString;
				//create to string function header
				fileFunctionText = fileFunctionText + "const char* _" + this.lionResource.ModuleName.ToUpper() + "_json" 
					+ enumCapatalizedString + "ToString(\n"
					+ "    " + enumTypeNameString + " typeEnum);\n\n";

				//create json type function header
				fileFunctionText = fileFunctionText + "OSAL_Status _" + this.lionResource.ModuleName.ToUpper() + "_jsonGet"
					+ enumCapatalizedString + "(\n"
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

		//if get is set, create the list definitions as well
		string listText = "";
		if (lionResource.Get == true)
		{
			listText += "typedef struct {\n";
			listText += "    const char *" + lionResource.ResourceName + ";\n";
			listText += "    const char *" + lionResource.ResourceName + "List;\n";
			listText += "    const char *nextId;\n";
			listText += "} _" + this.lionResource.ModuleName.ToUpper() + "_json" + this.capitalizedString + "ListKeys;\n\n";
			listText += "extern const _" + this.lionResource.ModuleName.ToUpper() + "_json" + this.capitalizedString + "ListKeys ";
			listText += "_" + this.lionResource.ModuleName.ToLower() + "Json" + this.capitalizedString + "ListKeys;\n\n";
		} 

		string fileName = "_" + this.lionResource.ModuleName.ToLower() + "_" + "json_string.h";
		using (StreamWriter outputFile = new StreamWriter(Path.Combine(folderToSaveTo, fileName)))
		{
			outputFile.WriteLine(fileText + fileFunctionText + listText);
		}
	}
	private void generateJsonStringC(string folderToSaveTo)
	{
		//create the message string based on the requests neeeded
		string messageText = "";
		if (lionResource.Get == true)
		{
			messageText += "        [" + this.lionResource.ModuleName + "_MSG_GET_" + this.lionResource.ResourceName.ToUpper() + "_LIST_REQUEST] = "
				+ "\"get" + this.capitalizedString + "ListRequest\"\n";
			messageText += "        [" + this.lionResource.ModuleName + "_MSG_GET_" + this.lionResource.ResourceName.ToUpper() + "_LIST_RESPONSE] = "
				+ "\"get" + this.capitalizedString + "ListResponse\"\n";
		}
		if (lionResource.Post == true)
		{
			messageText += "        [" + this.lionResource.ModuleName + "_MSG_CREATE_" + this.lionResource.ResourceName.ToUpper() + "_REQUEST] = "
				+ "\"create" + this.capitalizedString + "Request\"\n";
			messageText += "        [" + this.lionResource.ModuleName + "_MSG_CREATE_" + this.lionResource.ResourceName.ToUpper() + "_RESPONSE] = " 
				 + "\"create" + this.capitalizedString + "Response\"\n";
		}
		if (lionResource.Put == true)
		{
			messageText += "        [" + this.lionResource.ModuleName + "_MSG_UPDATE_" + this.lionResource.ResourceName.ToUpper() + "_REQUEST] = "
				+ "\"update" + this.capitalizedString + "Request\"\n";
			messageText += "        [" + this.lionResource.ModuleName + "_MSG_UPDATE_" + this.lionResource.ResourceName.ToUpper() + "_RESPONSE] = "
				+ "\"update" + this.capitalizedString + "Response\"\n";
		}
		if (lionResource.Delete == true)
		{
			messageText += "        [" + this.lionResource.ModuleName + "_MSG_DELETE_" + this.lionResource.ResourceName.ToUpper() + "_REQUEST] = "
				+  "\"delete" + this.capitalizedString + "Request\"\n";
			messageText += "        [" + this.lionResource.ModuleName + "_MSG_DELETE_" + this.lionResource.ResourceName.ToUpper() + "_RESPONSE] = "
				+ "\"delete" + this.capitalizedString + "Response\"\n";
		}
		if (lionResource.GetSingle == true)
		{
			messageText += "        [" + this.lionResource.ModuleName + "_MSG_GET_SINGLE_" + this.lionResource.ResourceName.ToUpper() + "_REQUEST] = "
				+ "\"getSingle" + this.capitalizedString + "Request\"\n";
			messageText += "        [" + this.lionResource.ModuleName + "_MSG_GET_SINGLE_" + this.lionResource.ResourceName.ToUpper() + "_RESPONSE] = " 
				+ "\"getSingle" + this.capitalizedString + "Response\"\n";
		}
		messageText += "\n";

		//create the resourceKeys
		string keysText = "const _" + this.lionResource.ModuleName.ToUpper() + "_json" + this.capitalizedString + "Keys "
			+ this.lionResource.ModuleName.ToLower() + "Json" + this.capitalizedString + "Keys = {\n";
		keysText += "        ." + lionResource.ResourceName + " = " + "\"" + DataParser.toSnakeCase(lionResource.ResourceName) + "\",\n";
		foreach (LionDataField dataField in this.lionResource.DataFields)
		{
			keysText += "        ." + dataField.Name + " = " + "\"" + DataParser.toSnakeCase(dataField.Name) + "\",\n";
		}
		keysText += "};\n\n";

		//if get is set, create the list definitions as well
		string listText = "";
		if (lionResource.Get == true)
		{
			listText += "const _" + this.lionResource.ModuleName.ToUpper() + "_json" + this.capitalizedString + "ListKeys "
			+ this.lionResource.ModuleName.ToLower() + "Json" + this.capitalizedString + "ListKeys = {\n";
			listText += "        ." + lionResource.ResourceName + " = " + "\"" + DataParser.toSnakeCase(lionResource.ResourceName) + "\",\n";
			listText += "        ." + lionResource.ResourceName + "_list = " + "\"" + DataParser.toSnakeCase(lionResource.ResourceName) + "_list\",\n";
			listText += "        .next_id = \"next_id\",\n";
			listText += "};\n\n";
		}


		//create the enumKeys and enumFunctions
		string enumKeys = "";
		string enumFunctions = "";
		foreach (LionDataField dataField in this.lionResource.DataFields)
		{ 
			if (dataField.DataType == DataType.ENUM)
			{
				string enumCapatalizedString = char.ToUpper(dataField.Name[0]) + dataField.Name.Substring(1);

				string enumTypeNameString = this.lionResource.ModuleName.ToUpper() + "_" + enumCapatalizedString;

				enumKeys += "static const char *_" + this.lionResource.ModuleName.ToLower() + "JsonEnumKey_" + enumCapatalizedString + "[] = {\n";
				enumKeys += "        [" + this.lionResource.ModuleName.ToUpper() + "_" + DataParser.toSnakeCase(dataField.Name).ToUpper() + "_INVALID]" +
					" = \"invalid\",\n";

				foreach (string enumValue in dataField.EnumValues)
				{
					enumKeys += "        [" + this.lionResource.ModuleName.ToUpper() + "_" + DataParser.toSnakeCase(dataField.Name).ToUpper() + "_" +
						DataParser.toSnakeCase(enumValue).ToUpper() + "] = \"" +
						DataParser.toSnakeCase(enumValue).ToLower() + "\",\n";
				}

				enumKeys += "};\n";
				enumKeys += "static int _" + lionResource.ModuleName.ToLower() + "JsonEnumCount_" + enumCapatalizedString + " = sizeof(_" +
					lionResource.ModuleName.ToLower() + "JsonEnumKey_" + enumCapatalizedString + ") / sizeof(char*);\n\n";

				//create to string function 
				enumFunctions += "const char* _" + this.lionResource.ModuleName.ToUpper() + "_json" +
					enumCapatalizedString + "ToString(\n"
					+ "    " + enumTypeNameString + " typeEnum)\n{\n";
				enumFunctions += "    return _" + this.lionResource.ModuleName.ToLower() + "JsonEnumKey_" + enumCapatalizedString + "[typeEnum];\n}\n\n";

				//create json type function 
				enumFunctions = enumFunctions + "OSAL_Status _" + this.lionResource.ModuleName.ToUpper() + "_jsonGet" +
					enumCapatalizedString + "(\n"
					+ "    json_t            *jsonString_ptr,\n"
					+ "    const char        *key_ptr,\n"
					+ "    " + enumTypeNameString + "         *dest_ptr)\n{\n";
				enumFunctions += "    int index = _jsonStringToEnumIndex(jsonString_ptr, key_ptr,\n    " +
					"_" + lionResource.ModuleName.ToLower() + "JsonEnumKey_" + enumCapatalizedString + ", " +
					"_" + lionResource.ModuleName.ToLower() + "JsonEnumCount_" + enumCapatalizedString + ");\n    " +
					"if (index < 0) {\n        return (OSAL_FAIL);\n    }\n    " + "*dest_ptr = (" + lionResource.ModuleName.ToUpper() + "_" +
					enumCapatalizedString + ") index;\n    return (OSAL_SUCCESS);\n}\n\n";

				//create By string function 
				enumFunctions += enumTypeNameString
					+ " _" + this.lionResource.ModuleName.ToUpper() + "_jsonGet" + enumCapatalizedString + "ByString(\n"
					+ "    const char *value_ptr)\n{\n    "
					+ enumTypeNameString + " type;\n\n    "
					+ "if (-1 == (type = _stringToEnumIndex(value_ptr, _" + lionResource.ModuleName.ToLower() + "JsonEnumKey_" + enumCapatalizedString + ",\n        " + 
					"_" + lionResource.ModuleName.ToLower() + "JsonEnumCount_" + enumCapatalizedString + "))) {\n        " +
					"return (" + lionResource.ModuleName.ToUpper() + "_" + DataParser.toSnakeCase(dataField.Name).ToUpper() + "_INVALID);\n    " + 
					"}\n    " +
					"return (type);\n}\n\n";

			}
		}

		string fileName = "_" + this.lionResource.ModuleName.ToLower() + "_" + "json_string.c";
		using (StreamWriter outputFile = new StreamWriter(Path.Combine(folderToSaveTo, fileName)))
		{
			outputFile.WriteLine(messageText + keysText + listText + enumKeys + enumFunctions);
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
		generateJsonC(folderToSaveTo);
	}
}
