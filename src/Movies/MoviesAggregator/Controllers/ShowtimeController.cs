﻿using Microsoft.AspNetCore.Mvc;
using Movies.Aggregator.Domain;
using MoviesAggregator.Models;
using Domain = Movies.Aggregator.Domain.Models;

namespace MoviesAggregator.Controllers;

[Route("[controller]")]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
[ProducesResponseType(StatusCodes.Status500InternalServerError)]
public class ShowtimeController : Controller
{
    private readonly ILogger<ShowtimeController> _logger;
    private readonly IShowtimeService _showtimeService;

    public ShowtimeController(ILogger<ShowtimeController> logger,
                              IShowtimeService showtimeService)
    {
        _logger = logger;
        _showtimeService = showtimeService;
    }


    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Post([FromBody] CreateShowTime payload)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _showtimeService.Create(new Domain.CreateShowTime()
            {
                ImdbId = payload.ImdbId,
                AuditoriumId = payload.AuditoriumId,
                SessionDate = payload.SessionDate
            });

            return StatusCode(StatusCodes.Status201Created, response);
        }
        catch (ArgumentNullException e)
        {
            _logger.LogError($"{nameof(Post)}", e);

            return StatusCode(StatusCodes.Status400BadRequest, e.Message);
        }
        catch (Exception e)
        {
            _logger.LogError($"{nameof(Post)}", e);

            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }
}