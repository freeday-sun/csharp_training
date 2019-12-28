using System;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string firstname;
        private string middlename = "";
        private string lastname;
        private string nickname = "";
        private string title = "";
        private string company = "";
        private string address;
        private string telephone_home;
        private string telephone_work = "";
        private string telephone_mobile = "";
        private string telephone_fax = "";
        private string email;
        private string email2 = "";
        private string email3 = "";
        private string homepage = "";
        private string secondary_address = "";
        private string secondary_home = "";
        private string secondary_notes = "";

        public ContactData(string firstname, string lastname, string address, string email, string telephone_home)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            this.address = address;
            this.email = email;
            this.telephone_home = telephone_home;
        }

        public bool Equals(ContactData other)
        {
            if (object.ReferenceEquals(other, null))
            { return false; }
            else if (object.ReferenceEquals(this, other))
            { return true; }
            if (Firstname == other.Firstname && Lastname == other.Lastname && Address == other.Address
                && Email == other.Email && Telephone_home == other.Telephone_home)
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
            return "name=" + Firstname;
        }

        public int CompareTo(ContactData other)
        {
            if (object.ReferenceEquals(other, null))
            { return 1; }

            int result = Firstname.CompareTo(other.Firstname);
            if (result == 0)
            {
                result = Lastname.CompareTo(other.Lastname);
            }
            return result;
            /*
            int FirstnameCompare = Firstname.CompareTo(other.Firstname);
            int LastnameCompare = Lastname.CompareTo(other.Lastname);
            int AddressCompare = Address.CompareTo(other.Address);
            int EmailCompare = Email.CompareTo(other.Email);
            int Telephone_homeCompare = Telephone_home.CompareTo(other.Telephone_home);

            if (FirstnameCompare == 0 && LastnameCompare == 0 && AddressCompare == 0
                && EmailCompare == 0 && Telephone_homeCompare == 0)
            { 
                return 0; 
            
            };
            
            return 1; */
        }

        public string Firstname
        {
            get { return firstname; }
            set { firstname = value; }
        }

        public string Lastname
        {
            get { return lastname; }
            set { lastname = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Telephone_home
        {
            get { return telephone_home; }
            set { telephone_home = value; }
        }
    }
}
