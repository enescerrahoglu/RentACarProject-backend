using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constant
{
    public static class Messages
    {
        public static string AddMessage = "Data Added";
        public static string CarCharacterError = "Car name must be minimum 2 character";
        public static string DeleteMessage = "Data Deleted";
        public static string UpdateMessage = "Data Updated";
        public static string CarPriceError = "Car Price must be higher than 0";
        public static string CantRentMessage = "Not Available For Rent";
        public static string RentMessage = "Car Rented";

        public static string CantAddMessage = "Data can't Added!";
        public static string EmailError = "It is not an Email adress";
        public static string ColorNameExists = "Color Name Exists";
        public static string NumberOfPictureError = "The Number of Images Exceeded for this car !!!";
        public static string InvalidFileType = "Invalid File Type";
        public static string UserNotFound = "User doesn't exist !!!";

        public static string PasswordError = "Password is wrong !!!";

        public static string SuccessfulLogin = "Successful Login";
        public static string UserExistError = "User already exist!!!";
        public static string UserRegistered = "The user has been successfully registered in the system";
        public static string AccessTokenCreated = "Access Token has been created";
        public static string AuthorizationDenied = "You have no authorization !!!";
        public static string BrandNameExistError = "The Brand Name you entered is found !!!";

        //Validation function messages
        public static string Multiple_Add_Message(string text) => $@"Multiple {text}s  Added";
        public static string Add_Message(string text) => $@" {text}  Added";
        public static string Update_Message(string text) => $@"Updated the {text}";
        public static string Delete_Message(string text) => $@"Deleted the {text}";




        public static string Added = "Ekleme işlemi gerçekleşti";
        public static string Deleted = "Silme işlemi gerçekleşti";
        public static string Updated = "Güncelleme işlemi gerçekleşti";
        public static string Rented = "Kiralama gerçekleşti";
        public static string RentOff = "Sözleşme iptal edildi";
        public static string RentUpdate = "Sözleşme güncellendi";
        public static string RentList = "Sözleşmeler Listelendi";
        public static string RentGet = "Sözleşme Getirildi";
        public static string UsersListed = "Kullanıcılar Listelendi";
        public static string UserListed = "Kullanıcı Listelendi";
        public static string CustomersListed = "Müşteriler Listelendi";
        public static string CustomerListed = "Müşteri Listelendi";
        public static string ReturnDateNull = "Araba mevcut değil";


        public static string CantDeleted = "Silme başarısız";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string ProductNameAlreadyExists = "Ürün ismi zaten mevcut";

        public static string ColorsListed = "Renkler listelendi";
        public static string CantAdded = "Ekleme başarısız";
        public static string CarsListed = "Arabalar listelendi";
        public static string ColorAddInvalid = "Var olan Renk eklenemez";
        public static string BrandAddInvalid = "Var olan Marka eklenemez";
        public static string ImagesAdded = "Görüntü Eklendi";
        public static string ImagesCantAdded = "Ekleme başarısız";
        public static string TransactionTested = "Transaction test edildi";
    }
}

