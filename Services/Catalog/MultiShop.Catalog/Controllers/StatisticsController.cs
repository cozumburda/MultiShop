﻿using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Services.StatisticServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticService _statisticService;

        public StatisticsController(IStatisticService statisticService)
        {
            _statisticService = statisticService;
        }
        [HttpGet("GetBrandCount")]
        public async Task<IActionResult> GetBrandCount()
        {
            var value = await _statisticService.GetBrandCount();
            return Ok(value);
        }
        [HttpGet("GetCategoryCount")]
        public async Task<IActionResult> GetCategoryCount()
        {
            var value = await _statisticService.GetCategoryCount();
            return Ok(value);
        }
        [HttpGet("GetProductCount")]
        public async Task<IActionResult> GetProductCount()
        {
            var value = await _statisticService.GetProductCount();
            return Ok(value);
        }

        [HttpGet("GetProductAvgPrice")]
        public async Task<IActionResult> GetProductAvgPrice()
        {
            var value = await _statisticService.GetProductAvgPrice();
            return Ok(value);
        }
        [HttpGet("GetMaxProductPrice")]
        public async Task<IActionResult> GetMaxProductPrice()
        {
            var value = await _statisticService.GetMaxProductPrice();
            return Ok(value);
        }
        [HttpGet("GetMinProductPrice")]
        public async Task<IActionResult> GetMinProductPrice()
        {
            var value = await _statisticService.GetMinProductPrice();
            return Ok(value);
        }
    }
}
