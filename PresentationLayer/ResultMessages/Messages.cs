namespace PresentationLayer.ResultMessages
{
    public static class Messages
    {
        public static class Report
        {
            public static string Add(string reportTitle)
            {
                return $"{reportTitle} başlıklı haber başarıyla eklendi.";
            }
            public static string Update(string reportTitle)
            {
                return $"{reportTitle} başlıklı haber başarıyla güncellendi.";
            }
            public static string Delete(string reportTitle)
            {
                return $"{reportTitle} başlıklı haber başarıyla silindi.";
            }
            public static string UndoDelete(string reportTitle)
            {
                return $"{reportTitle} başlıklı haber başarıyla geri alındı.";
            }
        }
    }
}
