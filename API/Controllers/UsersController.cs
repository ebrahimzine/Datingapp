using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly DataContext context;

        public UsersController(DataContext context)
        {
            this.context = context;
        }



    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>>GetUsers()  {
        var Users = await context.Users.ToListAsync();
        return Users;
    }

    [HttpGet("{id}")]
    public async Task <ActionResult<AppUser>>GetUser(int id){
        var User =  await context.Users.FindAsync(id);
        return User;
    }

    }
}