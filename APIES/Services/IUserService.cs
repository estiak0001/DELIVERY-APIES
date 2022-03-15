
using APIES.Data;
using APIES.Entities;
using APIES.Helper;
using APIES.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PXLibrary;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace APIES.Services
{
    public interface IUserService
    {
        //bool CheackValidity(string DeviceID);
        //CoreUserDevice GetByDeviceID(string deviceID);
        //bool SendEmail(string emailid);
        //CoreUserInfo GetByEmailandCode(string emailid, string ConfirmationCode);
        //bool DeviceIDExists(string DeviceID);
        //void AddUserDevice(CoreUserDevice coreUserDevice);
        //bool IsValidEmail(string emailid);
        //bool IsExistEmail(string emailid);
        Task<CoreUserInfoDto> AuthenticateAsync(string username, string password);
        //InvDefSalesConcern GetSalesConcerns(string SalesConcernId);
        //IEnumerable<AspNetUsers> GetAll();
        Task<ApplicationUser> GetByIdAsync(string id);

        //AspNetUsers Create(AspNetUsers user, string password);
        //void Update(AspNetUsers user, string password = null);
        //void Delete(int id);
        //bool Save();
        //TotalTargetDTO orderTarget(string TSO);

    }

    public class UserService : IUserService
    {
        private DeliveryDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UserService(DeliveryDbContext context, IOptions<AppSettings> appSettings, UserManager<ApplicationUser> userManager,
                              SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _appSettings = appSettings.Value;
            _userManager = userManager;
            _signInManager = signInManager;
        }


        private readonly AppSettings _appSettings;
        public async Task<CoreUserInfoDto> AuthenticateAsync(string EmployeeId, string password)
        {
            LoginViewModel login = new LoginViewModel();
            login.Username = EmployeeId;
            login.Password = password;
            login.RememberMe = false;

            if (string.IsNullOrEmpty(EmployeeId) || string.IsNullOrEmpty(password))
                return null;

            //var user = _context.AspNetUsers.SingleOrDefault(x => x.EmployeeId == EmployeeId);
            //var Role = _context.AspNetUserRoles.SingleOrDefault(x => x.UserId == user.Id);
            //var RoleName = _context.Roles.SingleOrDefault(x => x.Id == Role.RoleId);

            var user = await _userManager.FindByNameAsync(EmployeeId);
            // Get the roles for the user
            var roles = await _userManager.GetRolesAsync(user);
            var role = roles[0];

            // check if username exists
            if (user == null)
                return null;
            //var result = await _signInManager.PasswordSignInAsync(login.Username, login.Password, login.RememberMe, false);

            // check if password is correct
            //if (!result.Succeeded)
                //return null;

            // authentication successful so generate jwt token

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Sid, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, "")
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            //user.Token = tokenHandler.WriteToken(token);

            CoreUserInfoDto returnUser = new CoreUserInfoDto();
            returnUser.Id = user.Id;
            returnUser.Department = user.Department;
            returnUser.EmployeeID = user.EmployeeID;
            returnUser.Role = "";
            returnUser.Email = user.Email;
            returnUser.AppVersion = "1.0.1";
            return returnUser;
        }

        //public IEnumerable<AspNetUsers> GetAll()
        //{
        //    return _context.AspNetUsers;
        //}

        public async Task<ApplicationUser> GetByIdAsync(string id)
        {
            var user = await _userManager.FindByNameAsync(id);

            return user;
        }

       

        //public AspNetUsers Create(AspNetUsers user, string password)
        //{
        //    // validation
        //    if (string.IsNullOrWhiteSpace(password))
        //        throw new AppException("Password is required");

        //    if (_context.AspNetUsers.Any(x => x.UserName == user.UserName))
        //        throw new AppException("Username \"" + user.UserName + "\" is already taken");

        //    byte[] passwordHash, passwordSalt;
        //    CreatePasswordHash(password, out passwordHash, out passwordSalt);

        //    //user.PasswordHash = passwordHash;
        //    //user.PasswordSalt = passwordSalt;
        //    //_context.Users.Add(user);
        //    //_context.SaveChanges();

        //    return user;
        //}

        //public void Update(AspNetUsers userParam, string password = null)
        //{
        //    var user = _context.AspNetUsers.Find(userParam.Id);

        //    if (user == null)
        //        throw new AppException("User not found");

        //    // update username if it has changed
        //    if (!string.IsNullOrWhiteSpace(userParam.UserName) && userParam.UserName != user.UserName)
        //    {
        //        // throw error if the new username is already taken
        //        if (_context.AspNetUsers.Any(x => x.UserName == userParam.UserName))
        //            throw new AppException("Username " + userParam.UserName + " is already taken");

        //        user.UserName = userParam.UserName;
        //    }

        //    // update user properties if provided
        //    if (!string.IsNullOrWhiteSpace(userParam.Name))
        //        user.Name = userParam.Name;



        //    // update password if provided
        //    if (!string.IsNullOrWhiteSpace(password))
        //    {
        //        byte[] passwordHash, passwordSalt;
        //        CreatePasswordHash(password, out passwordHash, out passwordSalt);

        //        //user.PasswordHash = passwordHash;
        //        //user.PasswordSalt = passwordSalt;
        //    }

        //    _context.AspNetUsers.Update(user);
        //    _context.SaveChanges();
        //}

        //public void Delete(int id)
        //{
        //    var user = _context.AspNetUsers.Find(id);
        //    if (user != null)
        //    {
        //        _context.AspNetUsers.Remove(user);
        //        _context.SaveChanges();
        //    }
        //}

        // private helper methods

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<bool> VerifyPasswordAsync(LoginViewModel user)
        {
            var result = await _signInManager.PasswordSignInAsync(user.Username, user.Password, user.RememberMe, false);

            if(result.Succeeded)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }
            return true;
        }

        //public bool CheackValidity(string DeviceID)
        //{
        //    return _context.CoreUserDevice.Any(a => a.DeviceId == DeviceID);
        //}

        //public void updateConfCode(string emailid, string randomCode)
        //{
        //    var user = _context.CoreUserInfo.FirstOrDefault(u => u.OffEmail == emailid);
        //    user.EmailConfCode = randomCode;
        //    _context.SaveChanges();
        //}

        //public bool SendEmail(string emailid)
        //{
        //    Random generator = new Random();
        //    String randomecode = generator.Next(0, 999999).ToString("D6");
        //    bool t = false;
        //    try
        //    {
        //        var fromemail = new MailAddress("estiak.eng@gmail.com");
        //        var tomemail = new MailAddress(emailid);
        //        //var message = new MailMessage();
        //        //message.To.Add(new MailAddress(emailid));
        //        //message.From = new MailAddress("estiak.eng@gmail.com");
        //        //message.Subject = "This Message provided by Apex Husain!";
        //        //message.Body ="Your Code is - " + randomecode;
        //        //message.IsBodyHtml = false;

        //        var smtp = new SmtpClient
        //        {
        //            Host = "smtp.gmail.com",
        //            Port = 587,
        //            UseDefaultCredentials = true,
        //            DeliveryMethod = SmtpDeliveryMethod.Network,
        //            EnableSsl = true,
        //            Credentials = new NetworkCredential(fromemail.Address, "Esti@kAhmed098321")
        //        };
        //        using (var message = new MailMessage(fromemail, tomemail) { Subject = "test", Body = "Your code is - " + randomecode }) { smtp.Send(message); }

        //        updateConfCode(emailid, randomecode);
        //        t = true;
        //    }
        //    catch
        //    {
        //        t = false;
        //    }

        //    return t;
        //}

        public bool IsValidEmail(string emailid)
        {
            bool t = false;
            try
            {

                var addr = new System.Net.Mail.MailAddress(emailid);
                if (addr.Address != null)
                    t = true;
            }
            catch
            {
                t = false;
            }
            return t;
        }

        //public bool IsExistEmail(string emailid)
        //{
        //    return _context.AspNetUsers.Any(a => a.Email == emailid);
        //}

        //public CoreUserInfo GetByEmailandCode(string emailid, string ConfirmationCode)
        //{
        //    var user = _context.CoreUserInfo.FirstOrDefault(u => u.OffEmail == emailid && u.EmailConfCode == ConfirmationCode);
        //    return user;
        //}
        //public CoreUserDevice GetByDeviceID(string deviceID)
        //{
        //    var userDevice = _context.CoreUserDevice.FirstOrDefault(u => u.DeviceId == deviceID);
        //    return userDevice;
        //}
        //[Obsolete]
        //public void AddUserDevice(CoreUserDevice coreUserDevice)
        //{
        //    if (coreUserDevice.DeviceId == "")
        //    {
        //        throw new ArgumentNullException(nameof(coreUserDevice.DeviceId));
        //    }

        //    if (coreUserDevice.EmployeeId == "")
        //    {
        //        throw new ArgumentNullException(nameof(coreUserDevice.EmployeeId));
        //    }


        //    var MaxID = _context.CustomIDCoreUserDevice.FromSql("Select FORMAT(ISNULL(MAX(RIGHT(UserDeviceID,3)),0)+1,'000') as UserDeviceID from Core_UserDevice").Select(x => new CustomIDCoreUserDevice()
        //    {
        //        UserDeviceId = x.UserDeviceId
        //    }).FirstOrDefault();


        //    if (MaxID.UserDeviceId == "")
        //    {
        //        throw new ArgumentNullException(nameof(MaxID.UserDeviceId));
        //    }

        //    coreUserDevice.UserDeviceId = MaxID.UserDeviceId;
        //    coreUserDevice.Status = "Pending";
        //    _context.CoreUserDevice.Add(coreUserDevice);
        //}

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        

        //public bool DeviceIDExists(string DeviceID)
        //{
        //    if (DeviceID == "")
        //    {
        //        throw new ArgumentNullException(nameof(DeviceID));
        //    }
        //    return _context.CoreUserDevice.Any(a => a.DeviceId == DeviceID);
        //}

        //[Obsolete]
        //public TotalTargetDTO orderTarget(string TSO)
        //{
        //    DateTime now = DateTime.Now;
        //    var curr = now.ToString("yyyy-MM-dd");
        //    var curr2 = "2020-01-01";
        //    var result = _context.targetQTY.FromSqlRaw<TotalTargetDTO>("select distinct ISNull(cast(sum(trd.Quantity) AS decimal(18,2)), 0) Totaltarget from Sales_ManualSalesTargetEntry tr left join Sales_ManualSalesTargetDetails trd on tr.STID = trd.STID and trd.TSO= '" + TSO + "' where '" + TSO + "' IN (select * from SplitString(tr.TSO, ',')) and '" + curr2 + "' between tr.FromDate and tr.ToDate").FirstOrDefault();
        //    return result;
        //}
    }
}
