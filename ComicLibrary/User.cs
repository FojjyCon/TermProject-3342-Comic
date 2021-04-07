using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicLibrary
{
    class User
    {
        private String username;
        private String password;
        private String homeAddress;
        private String billingAddress;
        private String phoneNumber;
        private String avatar;
        private String emailAddress;
        private String securityEmail;
        private int banStatus;
        private String type;
        private int money;
        private String question1;
        private String answer1;
        private String question2;
        private String answer2;
        private String question3;
        private String answer3;

        public String Username { get { return username; } set { username = value; } }
        public String Password { get { return password; } set { password = value; } }
        public String HomeAddress { get { return homeAddress; } set { homeAddress = value; } }
        public String BillingAddress { get { return billingAddress; } set { billingAddress = value; } }
        public String PhoneNumber { get { return phoneNumber; } set { phoneNumber = value; } }
        public String Avatar { get { return avatar; } set { avatar = value; } }
        public String EmailAddress { get { return emailAddress; } set { emailAddress = value; } }
        public String SecurityEmail { get { return securityEmail; } set { securityEmail = value; } }
        public int BanStatus { get { return banStatus; } set { banStatus = value; } }
        public String Type { get { return type; } set { type = value; } }
        public int Money { get { return money; } set { money = value; } }
        public String Question1 { get { return question1; } set { question1 = value; } }
        public String Answer1 { get { return answer1; } set { answer1 = value; } }
        public String Question2 { get { return question2; } set { question2 = value; } }
        public String Answer2 { get { return answer2; } set { answer2 = value; } }
        public String Question3 { get { return question3; } set { question3 = value; } }
        public String Answer3 { get { return answer3; } set { answer3 = value; } }
    }
}
