namespace ManagementTask.Message
{
    public interface ErrorMsg
    {
        public static string NOT_FOUND_THIS_ACCOUNT = "لا يوجد حساب على نفس المعلومات ";
        public static string ACCOUNT_IS_NOT_ACTIVE = "الحساب غير فعال  ";
        public static string ENTER_CURECT_DATA = "المعلومات المدخلة غير مطابقة للمعاير  ";
        public static string NOT_COMPLETE_OPERATION = "لم تتم العملية في نجاح  ";
        public static string ENTER_DATA_NOT_FOUND = "لا توجد اي بيانات   ";
        public static string DUBLECATE_ACCOUNT  = "الحساب موجود بالفعل   ";
        public static string ERROR = "حدث خطا غير متوقع   ";
        public static string NOT_FOUNT_ANY_USER_HAVE_SAME_ID = "لا يوجد مستخدم له نفس المعرف المدرج   ";
        public static string NOT_FOUNT_ANY_TASK_HAVE_SAME_ID = "لا يوجد اي مهمة له نفس المعرف المدرج   ";

    }
}
