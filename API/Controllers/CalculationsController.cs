﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using NotTaxTim.Logic.Calculations.Commands;
using NotTaxTim.Logic.Calculations.Queries;
using System.Threading.Tasks;

namespace NotTaxTim.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CalculationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new CalculationsGetQuery());
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCalculation([FromBody] CalculationsCreateCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

    }
}
