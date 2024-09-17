namespace API.Entities;
using API.Data;


public class AppUser
{
    public int Id {get;set;}= 0;
    public required string UserName {get;set;} 

    public required byte[] passwordHash {get;set;}

    public required byte[] passwordSalt {get;set;}
}