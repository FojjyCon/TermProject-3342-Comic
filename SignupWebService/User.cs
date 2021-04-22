using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignupWebService
{
    public class User
    {
        public String Username { get; set; }
        public String Password { get; set; }
        public String HomeAddress { get; set; }
        public String BillingAddress { get; set; }
        public String PhoneNumber { get; set; }
        public String Avatar { get; set; }
        public String EmailAddress { get; set; }
        public String SecurityEmail { get; set; }
        public String Type { get; set; }
        public String Money { get; set; }
        public String Answer1 { get; set; }
        public String Answer2 { get; set; }
        public String Answer3 { get; set; }
        public String BanStatus { get; set; }
        public String Verified { get; set; }

        public User()
        {

        }

        public User(String username, String password, String avatar, String email, String securityEmail, String homeAddress, String billingAddress, String phoneNumber,
            String money, String type, String answer1, String answer2, 
            String answer3, String banStatus, String verified)
        {
            this.Username = username;
            this.Password = password;
            this.HomeAddress = homeAddress;
            this.BillingAddress = billingAddress;
            this.PhoneNumber = phoneNumber;
            this.Avatar = avatar;
            this.EmailAddress = email;
            this.SecurityEmail = securityEmail;
            this.Type = type;
            this.Money = money;
            this.Answer1 = answer1;
            this.Answer2 = answer2;
            this.Answer3 = answer3;
            this.BanStatus = banStatus;
            this.Verified = verified;
        }
    }
}
