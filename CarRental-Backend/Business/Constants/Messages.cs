using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string BrandAdded = "Yeni Marka Eklendi";

        public static string BrandNameError = "! Marka ismi en az 3 karakterden oluşmalıdır";

        public static string RentalAdded = "Kiralama işlemi başarılı";

        public static string RentalReturnDateError = "! Kiralama işlemi başarısız, araç henüz teslim edilmedi";
        public static string CarImageLimitExceeded = "Fotoğraf limiti aşıldı";
        public static string UserNotFound = "Kullanıcı bulunamadı";

        public static string PasswordError = "Yanlış şifre";

        public static string SuccessfulLogin = "Başarılı Giriş";

        public static string UserAlreadyExists = "Kullanıcı mevcut";

        public static string UserRegistered = "Kullanıcı kaydı oluşturuldu";

        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";

        public static string AccessTokenError = "Access token oluşturulamadı";

        public static string AuthorizationDenied = "Authorization Denied";
    }
}
