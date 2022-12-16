using CoralApplication.Database;
using CoralApplication.Dto;
using CoralApplication.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CoralApplication.Controllers;

[ApiController]
public class UsersController : ControllerBase
{
    public string UserCollection = "users";

    [HttpGet]
    [Route("/useradmin")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<UserModel>> GetUsers()
    {
        var collection = CoralDatabase.Connect<UserModel>(UserCollection);
        var results = await collection.FindAsync(_ => true);
        return Ok(results.ToList());
    }

    [HttpGet]
    [Route("/useradmin/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<UserModel>> GetUserById(string id)
    {
        var collection = CoralDatabase.Connect<UserModel>(UserCollection);
        var results = await collection.FindAsync(dbEntry => dbEntry.Id == id);
        return Ok(results.ToList());
    }

    [HttpPost]
    [Route("/useradmin")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<UserResponseDto>> SignUpUser(UserRequestDto userRequestDto)
    {
        var collection = CoralDatabase.Connect<UserModel>(UserCollection);
        var request = new UserModel(
            userRequestDto.FirstName,
            userRequestDto.LastName,
            userRequestDto.Email,
            userRequestDto.Username
        );

        await collection.InsertOneAsync(request);

        var response = new UserResponseDto
        {
            Date = DateTime.Now,
            Message = $"{userRequestDto.FirstName} has sucessfully been added to the User Database",
            UserDetails = request
        };

        return Ok(response);
    }
}