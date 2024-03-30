﻿namespace PresentationLayer.ResultMessages
{
    // Toastr bildirimlerinin mesajlari bu class'ta yapilandiriliyor.
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

        public static class Contact
        {
            public static string Add(string contactTitle)
            {
                return $"{contactTitle} konulu mesaj başarıyla gönderildi.";
            }
            public static string Delete(string contactTitle)
            {
                return $"{contactTitle} konulu mesaj başarıyla silindi.";
            }
            public static string UndoDelete(string contactTitle)
            {
                return $"{contactTitle} konulu mesaj başarıyla geri alındı.";
            }
        }

        public static class User
        {
            public static string Add(string userName)
            {
                return $"{userName} kullanıcısı başarıyla eklendi.";
            }
            public static string Update(string userName)
            {
                return $"{userName} kullanıcısı başarıyla güncellendi.";
            }
            public static string Delete(string userName)
            {
                return $"{userName} kullanıcısı başarıyla silindi.";
            }
        }

        public static class Role
        {
            public static string Add(string roleName)
            {
                return $"{roleName} rolü başarıyla eklendi.";
            }
            public static string Update(string roleName)
            {
                return $"{roleName} rolü başarıyla güncellendi.";
            }
            public static string Delete(string roleName)
            {
                return $"{roleName} rolü başarıyla silindi.";
            }
        }

        public static class Announcement
        {
            public static string Add(string announcementTitle)
            {
                return $"{announcementTitle} başlıklı duyuru başarıyla eklendi.";
            }
            public static string Update(string announcementTitle)
            {
                return $"{announcementTitle} başlıklı duyuru başarıyla güncellendi.";
            }
            public static string Delete(string announcementTitle)
            {
                return $"{announcementTitle} başlıklı duyuru başarıyla silindi.";
            }
            public static string UndoDelete(string announcementTitle)
            {
                return $"{announcementTitle} başlıklı duyuru başarıyla geri alındı.";
            }
        }

        public static class LessonDocument
        {
            public static string Add(string lessonDocumentTitle)
            {
                return $"{lessonDocumentTitle} başlıklı materyal başarıyla eklendi.";
            }
            public static string Update(string lessonDocumentTitle)
            {
                return $"{lessonDocumentTitle} başlıklı materyal başarıyla güncellendi.";
            }
            public static string Delete(string lessonDocumentTitle)
            {
                return $"{lessonDocumentTitle} başlıklı materyal başarıyla silindi.";
            }
            public static string UndoDelete(string lessonDocumentTitle)
            {
                return $"{lessonDocumentTitle} başlıklı materyal başarıyla geri alındı.";
            }
        }

        public static class LessonVideo
        {
            public static string Add(string lessonVideoTitle)
            {
                return $"{lessonVideoTitle} başlıklı ders videosu başarıyla eklendi.";
            }
            public static string Update(string lessonVideoTitle)
            {
                return $"{lessonVideoTitle} başlıklı ders videosu başarıyla güncellendi.";
            }
            public static string Delete(string lessonVideoTitle)
            {
                return $"{lessonVideoTitle} başlıklı ders videosu başarıyla silindi.";
            }
            public static string UndoDelete(string lessonVideoTitle)
            {
                return $"{lessonVideoTitle} başlıklı ders videosu başarıyla geri alındı.";
            }
        }
    }
}
