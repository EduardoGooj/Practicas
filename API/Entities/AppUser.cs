using Microsoft.AspNetCore.SignalR;

namespace API.Entities;
public class AppUser
{
    public int id {get;set;}= 0;
    public required string UserName {get;set;} 
}