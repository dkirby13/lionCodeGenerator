        [D2FSP_MSG_GET_GROUP_LIST_REQUEST] = "getGroupListRequest"
        [D2FSP_MSG_GET_GROUP_LIST_RESPONSE] = "getGroupListResponse"
        [D2FSP_MSG_CREATE_GROUP_REQUEST] = "createGroupRequest"
        [D2FSP_MSG_CREATE_GROUP_RESPONSE] = "createGroupResponse"
        [D2FSP_MSG_GET_SINGLE_GROUP_REQUEST] = "getSingleGroupRequest"
        [D2FSP_MSG_GET_SINGLE_GROUP_RESPONSE] = "getSingleGroupResponse"

const _D2FSP_jsonGroupKeys d2fspJsonGroupKeys = {
        .cdrCallDirection = "cdr_call_direction",
        .memberCount = "member_count",
        .groupName = "group_name",
};

static const char *_d2fspJsonEnumKey_CdrCallDirection[] = {
        [D2FSP_CDR_CALL_DIRECTION_INVALID] = "invalid",
        [D2FSP_CDR_CALL_DIRECTION_INBOUND] = "inbound",
        [D2FSP_CDR_CALL_DIRECTION_OUTBOUND] = "outbound",
        [D2FSP_CDR_CALL_DIRECTION_INTERNAL] = "internal",
};
static int _d2fspJsonEnumCount_CdrCallDirection = sizeof(_d2fspJsonEnumKey_CdrCallDirection) / sizeof(char*);

const char* _D2FSP_jsonCdrCallDirectionToString(
    D2FSP_CdrCallDirection typeEnum)
{
    return _d2fspJsonEnumKey_CdrCallDirection[typeEnum];
}

OSAL_Status _D2FSP_jsonGetCdrCallDirection(
    json_t            *jsonString_ptr,
    const char        *key_ptr,
    D2FSP_CdrCallDirection         *dest_ptr)
{
    int index = _jsonStringToEnumIndex(jsonString_ptr, key_ptr,
    _d2fspJsonEnumKey_CdrCallDirection, _d2fspJsonEnumCount_CdrCallDirection);
    if (index < 0) {
        return (OSAL_FAIL);
    }
    *dest_ptr = (D2FSP_CdrCallDirection) index;
    return (OSAL_SUCCESS);
}

D2FSP_CdrCallDirection _D2FSP_jsonGetCdrCallDirectionByString(
    const char *value_ptr)
{
    D2FSP_CdrCallDirection type;

    if (-1 == (type = _stringToEnumIndex(value_ptr, _d2fspJsonEnumKey_CdrCallDirection,
        _d2fspJsonEnumCount_CdrCallDirection))) {
        return (D2FSP_CDR_CALL_DIRECTION_INVALID);
    }
    return (type);
}


