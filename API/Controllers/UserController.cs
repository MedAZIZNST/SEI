using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Reflection;
using Solution.Service;
using Solution.Entities;
using Microsoft.AspNetCore.Authorization;
using Solution.ViewModel;
using API.Helpers;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using AutoMapper;

namespace API.Controllers
{
   // [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {

        private readonly IMapper _mapper;
        IUserService _service;
        public UserController(IUserService service, IMapper mapper)
        {
            _mapper = mapper;
            _service = service;
        }
        [HttpPost]
        public IActionResult AddUser([FromBody] UserDto model)
        {
            IActionResult response = BadRequest(new { message = "email has already been taken" });
            var _user = _service.GetByEmail(model.email);
            if (_user == null)
            {
               var _newUser = _mapper.Map<User>(model);
                _newUser.Created_at = DateTime.Now;
                _newUser.Pwd = model.pwd.HashSHA256();
                _service.AddUser(_newUser);
                response = Ok(_newUser.WithoutPassword());
            }
            return response;
        }
        [HttpPut("{id}")]
        public IActionResult PutUsers(int id, [FromBody] User u)
        {
            var user = _service.GetById(id);
            if (id == u.Id)
            {
                if ( u.Pwd != user.Pwd && u.Pwd!= null) 
                {
                    user.Pwd = u.Pwd.HashSHA256();
                }
                user.UserName = u.UserName;
                user.Email = u.Email;
                user.cin = u.cin;
                user.BirthDate = u.BirthDate;
                user.address = u.address;
                user.grade = u.grade;
                user.PhoneNumber = u.PhoneNumber;
                user.UsersInRoles = u.UsersInRoles;
                _service.UpdateUser(user);
                return Ok(user);

            }
            else
            {
                return BadRequest();

            }
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] LoginDto model)
        {
            IActionResult response = BadRequest(new { message = "Username or password is incorrect" });
            var user = _service.GetByEmail(model.email);
            if (user != null) {
                response = BadRequest(new { message = "password is incorrect" });

                if(user.Pwd == model.pwd.HashSHA256())
                {
                    var _userRoles = _mapper.Map<ICollection<RoleVm>>(user.UsersInRoles);
                    var user_vm = _mapper.Map<UserVm>(user);
                    user_vm.Roles = _userRoles;
                    // authentication successful so generate jwt token
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes("MySecretKeyForJWTTokenEncryption");
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                          new Claim(ClaimTypes.Name, user.Id.ToString()),
                          new Claim(ClaimTypes.Email, user.Email.ToString()),
                        }),
                        Expires = DateTime.Now.AddDays(2),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    var Token = tokenHandler.WriteToken(token);
                    user.LastActivityDate = DateTime.Now;
                    _service.UpdateUser(user);
                    response = Ok(new {token = Token, expires = tokenDescriptor.Expires , currentUser = user_vm });
                }
            }
            return response;
        }

        [HttpGet]
        [Route("{UserId}")]
        public IActionResult GetById(int UserId)
        {
            return Ok(_service.GetById(UserId).WithoutPassword());
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.GetUsers());
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var userToDelete = _service.GetById(id);
            if (userToDelete == null)
                return NotFound();

            _service.DeleteUser(userToDelete);
            return NoContent();
        }


        //DeleteRole
        //[HttpDelete("{id}")]
        //[Route("Roles")]
        //public IActionResult DeleteRole(int id)
        //{
        //    var roleToDelete = _service.GetById(id);
        //    if (roleToDelete == null)
        //        return NotFound();

        //    _service.DeleteRole(roleToDelete);
        //    return NoContent();
        //}

        [HttpGet]
        [Route("Roles")]
        public IActionResult GetAllRoles()
        {
            return Ok(_service.GetRoles());
        }


        [HttpPost]
        [Route("Roles")]
        public IActionResult Addrole([FromBody] Role model)
        {
            IActionResult response = BadRequest(new { message = "already ex" });
            var _user = _service.GetRoles().Any(x=>x.RoleName == model.RoleName);
            if (!_user)
            {
                _service.AddRole(model);
                response = Ok();
            }
            return response;
        }

        

    }
}
