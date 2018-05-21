using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Data;

namespace Beltretake.Models
{
    public class ToDoContextFactory : IDesignTimeDbContextFactory<ActivityContext>
{
    public ActivityContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<ActivityContext>();
          builder.UseMySql("Server=localhost;Username=root;Password=root;Database=activitiescreatorsplease;");
        return new ActivityContext(builder.Options);
    }
}
    public class ActivityContext:DbContext
    {
        public ActivityContext(DbContextOptions<ActivityContext> options):base(options){}
        public DbSet<User> _users {get;set;}
        public DbSet<Activity> _activities {get;set;}
        public DbSet<Join> _joins {get;set;}

        public void CreateUser(RegisterVM registerVM){
            List<User> users = _users.ToList();
            User user = new User(registerVM);
            this.Add(user);
            this.SaveChanges();
        }
    
        public User Login(LoginVM loginVM){
            User user= _users.Where(u=> u.email == loginVM.email).SingleOrDefault();
            if(user == null){
                return null;
            }
            else{
                if(user.password == loginVM.password){
                    System.Console.WriteLine("YEAH YOU DID IT RIGHT HERE");
                    return user;
                }
                else{
                    System.Console.WriteLine("LINE 49");
                    return null;
                }
            }
        }
    }
}