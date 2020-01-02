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
