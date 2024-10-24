using AutoMapper;
using Microsoft.AspNetCore.Identity;
using PropertyRental.API.Controllers;
using PropertyRental.Application.DTOs;
using PropertyRental.Domain.Entities;
using PropertyRental.Domain.Entities.User;
using PropertyRental.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyRental.Application.Services
{
    public class UserAppService : IAppService<UserDTO>
    {
        private AppDbContext _context;
        private RoleManager<Role> _roleManager;
        private UserManager<User> _userManager;
        private RoleService _roleService;
        private readonly IMapper _mapper;
        public UserAppService(AppDbContext dbContext,RoleService roleService,RoleManager<Role> roleManager, IMapper mapper, UserManager<User> userManager)
        {
            _context = dbContext;
            _mapper = mapper;
            _roleManager = roleManager;
            _userManager = userManager; 
            _roleService = roleService;
        }
        public bool Commit()
        {
            if (_context.SaveChanges() > 0)
                return true;
            else
                return false;

        }
        public User GetByUserName(string userName)
        {
            return _context.Users.FirstOrDefault(u => u.UserName == userName);

        }
        public bool Delete(int id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);
            if (user == null) return false;
            else
            {
                _context.Users.Remove(user);
                return Commit();
            }
        }

        public List<UserDTO> GetAll()
        {
            var users = _context.Users.ToList();
            List<UserDTO> result = new List<UserDTO>();
            foreach(var user in users)
            {
                result.Add(_mapper.Map<UserDTO>(user));
            }
            return result;
        }
       //public UserDTO GetByUserName(string userName)
       // {
       //     var user = _context.Users.FirstOrDefault(u => u.UserName == userName);
       //     return _mapper.Map<UserDTO>(user);

       // }
      
        public UserDTO GetById(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            return _mapper.Map<UserDTO>(user);
        }
       public async Task<bool> ChangePassword(ChangePassword model)
        {

            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user == null)
                return false;

            var result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
            if (!result.Succeeded)
                return false;
            return true;

        }
        public async Task Insert(UserDTO entity)
        {
            var role =  _roleService.GetById(entity.RoleId);
            var user = _mapper.Map<User>(entity);
                
                var res = await _userManager.CreateAsync(user, entity.Password);
            if (res.Succeeded)
            {
                var user1 = await _userManager.FindByNameAsync(entity.UserName);
                await _userManager.AddToRoleAsync(user1, role.Name);
            }
        }

        public void Update(UserDTO entity, int id)
        {
            var user = _mapper.Map<User>(entity);
            _context.Users.Update(user);
            Commit();
        }

        void IAppService<UserDTO>.Insert(UserDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
