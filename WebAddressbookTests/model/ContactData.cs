using System;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
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
        private string allInfo;

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

        public bool Equals(ContactData other)
        {
            if (object.ReferenceEquals(other, null))
            { return false; }
            if (object.ReferenceEquals(this, other))
            { return true; }
            if (Firstname == other.Firstname && Lastname == other.Lastname)
            {
                return true;
            }

            return false;
        }
        public override int GetHashCode()
        {
            return Firstname.GetHashCode();
        }
        public override string ToString()
        {
            return "name=" + Firstname + "\n" + "lname=" + Lastname + "\n";
        }

        public int CompareTo(ContactData other)
        {
            if (object.ReferenceEquals(other, null))
            { return 1; }
            int FirstnameCompare = Firstname.CompareTo(other.Firstname);
            int LastnameCompare = Lastname.CompareTo(other.Lastname);
            if (FirstnameCompare == 0)
            {
                return LastnameCompare;
            }
            return FirstnameCompare;
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

        public string Id { get; set; }
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

        public string AllInfo
        {
            get
            {
                if (allInfo != null)
                {
                    return allInfo;
                }
                string test = "firstnamelastnameaddressaddressaddressaddressaddressaddressH:+704003M:telephoneMobilemailmail2mail3";
                string ContactDetailInfo = "";
                
                if (!String.IsNullOrEmpty(Firstname))
                { ContactDetailInfo += Firstname; }
                
                if (!String.IsNullOrEmpty(Lastname))
                { ContactDetailInfo += Lastname; }
                
                if (!String.IsNullOrEmpty(Address))
                {
                    Address = Regex.Replace(Address, "[\\r\\n]", "");
                    ContactDetailInfo += Address; }

                if (!String.IsNullOrEmpty(Telephone_home))
                { ContactDetailInfo += "H:" + PhoneFormatinOnlyNumbers(Telephone_home); }

                if (!String.IsNullOrEmpty(Telephone_mobile))
                { ContactDetailInfo += "M:" + PhoneFormatinOnlyNumbers(Telephone_mobile); }

                if (!String.IsNullOrEmpty(Telephone_work))
                { ContactDetailInfo += "W:" + PhoneFormatinOnlyNumbers(Telephone_work); }

                if (!String.IsNullOrEmpty(Email))
                { ContactDetailInfo += Email; }

                if (!String.IsNullOrEmpty(Email2))
                { ContactDetailInfo += Email2; }

                if (!String.IsNullOrEmpty(Email3))
                { ContactDetailInfo += Email3; }

                return ContactDetailInfo.Trim();
            }

            set { allInfo = value; }
        }

        private string PhoneFormatinOnlyNumbers(string phones)
        {
            if (phones == null || phones == "") { return ""; }

            return Regex.Replace(phones, "[ ()-]", "");
        }

        private string PhoneFormating(string phones)
        {
            if (phones == null || phones == "") { return ""; }

            return Regex.Replace(phones, "[ ()-]", "") + "\r\n";
        }

    }
}
