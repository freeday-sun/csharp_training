using System;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {

        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        public ContactData(string firstname, string lastname, string address, string email, string telephone_home)
        {
            Firstname = firstname;
            Lastname = lastname;
            Address = address;
            Email = email;
            Telephone_home = telephone_home;
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
        { get; set; }

        public string Lastname
        { get; set; }
        public string Address
        { get; set; }
        public string Email
        { get; set; }
        public string Telephone_home
        { get; set; }
        public string Id
        { get; set; }
    }
}
