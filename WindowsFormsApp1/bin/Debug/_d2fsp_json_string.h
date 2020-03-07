typedef struct {
    const char *cdrCallDirection;
    const char *memberCount;
    const char *groupName;
} _D2FSP_jsonGroupKeys;

extern const _D2FSP_jsonGroupKeys _d2fspJsonGroupKeys;

const char* _D2FSP_jsonCdrCallDirectionToString(
    D2FSP_CdrCallDirection typeEnum);

OSAL_Status _D2FSP_jsonGetCdrCallDirection(
    json_t            *jsonString_ptr,
    const char        *key_ptr,
    D2FSP_CdrCallDirection         *dest_ptr);

D2FSP_CdrCallDirection _D2FSP_jsonGetCdrCallDirectionByString(
    const char *value_ptr);


