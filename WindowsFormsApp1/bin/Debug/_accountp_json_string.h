typedef struct {
    const char *cdrCallTypeValue;
    const char *member_count;
    const char *name;

} _ACCOUNTPjsonMsgKeys;
const char* _ACCOUNTP_jsonGroupToString(
    ACCOUNTP_Group typeEnum);
OSAL_Status _ACCOUNTP_jsonGetGroupType(
    json_t            *jsonString_ptr,
    const char        *key_ptr,
    ACCOUNTP_Group         *dest_ptr);
ACCOUNTP_Group_ACCOUNTP_jsonGet ACCOUNTP_GroupByString(
    const char *value_ptr);

