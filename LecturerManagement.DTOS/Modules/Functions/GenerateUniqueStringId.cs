using System;

namespace LecturerManagement.DTOS.Modules.Functions
{
    public static class GenerateUniqueStringId
    {
        public static string GenrateNewStringId(string prefix)
        {
            string newCId = string.Empty;
            ////string prefix = "CV" + "01";
            string selectedIdPrefix = prefix.Substring(0, 2);
            int curCId = Convert.ToInt32(prefix.Substring(2, 2));
            if (prefix == selectedIdPrefix)
            {
                newCId = selectedIdPrefix + (curCId + 1).ToString().PadLeft(2);
            }
            else
            {
                newCId = selectedIdPrefix + (curCId + 1).ToString().PadLeft(2, '0');
            }
            return newCId;
        }
    }
}
