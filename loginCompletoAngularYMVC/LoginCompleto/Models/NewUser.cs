using System;

namespace LoginCompleto.Models
{
    public class NewUser
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Cuil { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime Birthdate { get; set; }
        public string Telephone { get; set; }
        public int AccountState { get; set; }
        public DateTime UpAccountDate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public string ImgDNI { get; set; }


        public NewUser(
            string name,
            string lastName,
            string email,
            string password,

            DateTime birthdate,
            string telephone,
            string cuil,
            int accountState,

            DateTime upAccountDate,
            string address,
            string city,
            string postCode,

            string imgDNI
            )
        {

            Name = name;
            LastName = lastName;
            Email = email;
            Password = password;

            Birthdate = birthdate;
            Telephone = telephone;
            Cuil = cuil;
            AccountState = accountState;

            UpAccountDate = upAccountDate;
            Address = address;
            City = city;
            PostCode = postCode;

            ImgDNI = imgDNI;
        }

        public NewUser()
        {

        }

    }
}