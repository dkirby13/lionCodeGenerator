static json_t* _jsonEncodeGroup(
    D2FSP_Group *Group_ptr)
{
    char bufferStr[_JSON_UINT32_STR_SIZE];
    json_t *jsonGroup_ptr = json_object();
    if (NULL != Group_ptr) {
        if (D2FSP_CDR_CALL_DIRECTION_INVALID != Group_ptr->cdrCallDirection) {
            json_object_set_new(jsonGroup_ptr, _d2fspJsonGroupKeys.cdrCallDirection,
            json_string(_D2FSP_jsonCdrCallDirectionToString(Group_ptr->cdrCallDirection)));
        }
        ;if (0 < Group_ptr->memberCount) {
            OSAL_snprintf(bufferStr, sizeof(bufferStr), "%u", Group_ptr->memberCount);
        json_object_set_new(jsonGroup_ptr, _d2fspJsonGroupKeys.memberCount,
            json_string(bufferStr));
        }
        ;if (NULL != Group_ptr->groupName_ptr) {
            json_object_set_new(jsonGroup_ptr, _d2fspJsonGroupKeys.groupName,
            json_string(Group_ptr->groupName_ptr));
        }
        ;    }

    return jsonGroup_ptr;
}


