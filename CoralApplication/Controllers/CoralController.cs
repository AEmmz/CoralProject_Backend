using CoralApplication.Database;
using CoralApplication.Dto;
using CoralApplication.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace CoralApplication.Controllers;

[ApiController]
public class CoralController : ControllerBase
{
    public string CoralCollection = "coral";

    [HttpGet]
    [Route("/coral")]
    public async Task<ActionResult<CoralModel>> GetAllCoral()
    {
        var collection = CoralDatabase.Connect<CoralModel>(CoralCollection);
        var results = await collection.FindAsync(_ => true);
        return Ok(results.ToList());
    }

    [HttpGet]
    [Route("/coral/{id}")]
    public async Task<ActionResult<CoralModel>> GetCoralById(string id)
    {
        var collection = CoralDatabase.Connect<CoralModel>(CoralCollection);
        var results = await collection.FindAsync(dbEntry => dbEntry.Id == id);
        return Ok(results.ToList());
    }


    [HttpPost]
    [Route("/coral")]
    public async Task<ActionResult<CoralResponseDto>> PostNewCoral(CoralRequestDto coralRequestDto)
    {
        var collection = CoralDatabase.Connect<CoralModel>(CoralCollection);

        var request = new CoralModel
        (
            coralRequestDto.Name,
            coralRequestDto.Price,
            coralRequestDto.PrimaryColor,
            coralRequestDto.SecondaryColor,
            coralRequestDto.Vendor,
            coralRequestDto.Website
        );

        await collection.InsertOneAsync(request);

        var response = new CoralResponseDto
        {
            Coral = request,
            Date = DateTime.Now,
            Message = $"{coralRequestDto.Name} successfully added to the Coral Database"
        };
        return Ok(response);
    }


    [HttpDelete]
    [Route("/coral")]
    public void DeleteCoral([FromBody] CoralDeleteDto coralDeleteDto)
    {
        var collection = CoralDatabase.Connect<CoralModel>(CoralCollection);
        foreach (var id in coralDeleteDto.Id) collection.DeleteOne(item => item.Id == id);
    }
}