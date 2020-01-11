using System;

namespace WebAddressbookTests
{
    public class ContactData
    {
        private string middlename = "";
        private string nickname = "";
        private string title = "";
        private string company = "";
        private string homepage = "";
        private string secondary_address = "";
        private string secondary_home = "";
        private string secondary_notes = "";
        private string allPhones;
        private string allEmails;

        public ContactData(string firstname, string lastname, string address, string email, string telephone_home)
        {
            Firstname = firstname;
            Lastname = lastname;
            Address = address;
            Email = email;
            Telephone_home = telephone_home;
        }

        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string Email2 { get; set; }

        public string Email3 { get; set; }

        public string Telephone_home { get; set; }

        public string Telephone_mobile { get; set; }

        public string Telephone_work { get; set; }

        public string Middlename { get; set; }
        public string AllPhones 
        {
            get 
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else 
                {
                    return (PhoneFormating(Telephone_home) + PhoneFormating(Telephone_mobile) + PhoneFormating(Telephone_work)).Trim();
                }
            }

            set { allPhones = value; } 
        }

        public string AllEmails 
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                return (Email + Email2 + Email3).Trim();
            }
            
            set { allEmails = value; }
        }

        private string PhoneFormating(string phones)
        {
            if (phones == null || phones == "") { return ""; }

            return phones.Replace(" ", "").Replace("(", "").Replace(")", "").Replace("-", "") + "\r\n";
        }

    }
}
