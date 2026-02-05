using System;
using System.Data;
using ContactsDataAccessLayer;

namespace ContactsBusinessLayer
{
    public class clsContact
    {
        // mode type will control flow in the Save method
        public enum enMode { eAddNew = 0, eUpdate = 1};
        public enMode Mode = enMode.eAddNew;

        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ImagePath { get; set; }
        public int CountryID { get; set; }

        // this is for a new contact (new object creation), will fill with initial values:
        public clsContact()
        {
            this.ID = -1;  // cuz new contact added to DB will be given new autonumbered ID.
            this.FirstName = "";
            this.LastName = "";
            this.Email = "";
            this.Phone = "";
            this.Address = "";
            this.DateOfBirth = DateTime.Now;
            this.CountryID = -1;
            this.ImagePath = "";
            this.Mode = enMode.eAddNew;
        }

        // private constructor to prevent any object creation, cuz if we create a new object here, then which ID to give? IDs are coming auto numbered from database.
        // another reason is to prevent any empty object creation, but using it inside the class here via find method.
        // so once this constructor is used, it is used to return an object of existent contact for update mode.
        private clsContact(int ID, string FirstName, string LastName, string Email, string Phone, string Address, DateTime DateOfBirth, int CountryID, string ImagePath)
        {
            this.ID = ID;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
            this.Phone = Phone;
            this.Address = Address;
            this.DateOfBirth = DateOfBirth;
            this.CountryID = CountryID;
            this.ImagePath = ImagePath;
            this.Mode = enMode.eUpdate;
        }




        public static clsContact find(int ID)
        {
            string FirstName = "",  LastName = "",  Email = "",  Phone = "",  Address = "",  ImagePath = "";
            DateTime DateOfBirth = DateTime.Now;
            int CountryID = -1;

            if (clsContactDataAccess.getContactInfoByID(ID, ref FirstName, ref LastName, ref Email, ref Phone, ref Address, ref DateOfBirth, ref CountryID, ref ImagePath))
            {
                 return new clsContact(ID, FirstName, LastName, Email, Phone, Address, DateOfBirth, CountryID, ImagePath);
            }
            else
                return null;
        }

        private bool _AddNewContact()
        {
            // this will let dataLayer add contact to DB then return the ID given by DB
            this.ID = clsContactDataAccess.AddNewContact(this.FirstName, this.LastName, this.Email, this.Phone, this.Address, this.DateOfBirth, this.CountryID, this.ImagePath);

            return (this.ID != -1);
        }

        private bool _UpdateContact()
        {
            return clsContactDataAccess.UpdateContact(this.ID, this.FirstName, this.LastName, this.Email, this.Phone, this.Address, this.DateOfBirth, this.CountryID, this.ImagePath);
        }

        public static bool DeleteContact(int ID)
        {
            return clsContactDataAccess.DeleteContact(ID);
        }

        // this will run in two situations: in adding new contact, and in updating a contact; thats why we have the modes
        public bool Save()
        {

            switch(Mode)
            {
                case enMode.eAddNew:
                    if (_AddNewContact())
                    {
                        Mode = enMode.eUpdate;
                        return true;
                    }
                    else
                        return false;

                case enMode.eUpdate:
                    return _UpdateContact();
                
                default: 
                    return false;
            }


        }



        public static DataTable GetAllContacts()
        {
            return clsContactDataAccess.GetAllContacts();
        }

        public static bool DoesExist(int ID)
        {
            return clsContactDataAccess.DoesExist(ID);
        }

    }
}
