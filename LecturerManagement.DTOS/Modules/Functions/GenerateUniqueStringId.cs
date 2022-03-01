using System;

namespace LecturerManagement.DTOS.Modules.Functions
{
    public static class GenerateUniqueStringId
    {
        public static string GenrateNewStringId(string prefix, int textFormatPrefix, int numberFormatPrefix)
        {
            var newCId = "";

            string selectedIdPrefix = prefix.Substring(0, textFormatPrefix);
            int curCId = Convert.ToInt32(prefix.Substring(2, textFormatPrefix));
            if (prefix == selectedIdPrefix)
            {
                newCId = selectedIdPrefix + (curCId + 1).ToString().PadLeft(numberFormatPrefix);
            }
            else
            {
                newCId = selectedIdPrefix + (curCId + 1).ToString().PadLeft(numberFormatPrefix, '0');
            }
            return newCId;
        }
        public static string FreeUniqueStringId()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}

