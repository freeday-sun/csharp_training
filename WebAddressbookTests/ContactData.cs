using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    class ContactData
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

        public ContactData(string firstname, string lastname, string address, string email)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            this.address = address;
            this.email = email;
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
    }
}
