﻿using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Redis;

namespace Sora.API.Controllers.api.v1.users
{
    [Route("/")]
    [ApiController]
    [AllowAnonymous]
    public class PerformanceBoard : Controller
    {
        private readonly RedisCache _redis;

        public PerformanceBoard(RedisCache redis)
        {
            _redis = redis;
        }

        [AllowAnonymous]
        [DisableCors]
        [HttpGet("/api/v1/users/{userId:int}/performance_board/{mode:int}")]
        public ActionResult Get(int userId, int mode) =>
            Ok(Encoding.Default.GetString(_redis.Get($"sora:performance:{userId}_{mode}")));
    }
}