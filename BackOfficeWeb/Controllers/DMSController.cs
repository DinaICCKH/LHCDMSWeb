using BackOfficeWeb;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace BackOfficeWeb.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DMSController : ControllerBase
    {
        private readonly AppDbContext _db;

        public DMSController(AppDbContext db)
        {
            _db = db;
        }


        public static class PasswordHasher
        {
            public static string HashPassword(string password)
            {
                using var sha = System.Security.Cryptography.SHA256.Create();
                var bytes = System.Text.Encoding.UTF8.GetBytes(password);
                var hash = sha.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequest model)
        {
            try
            {
                // Hash the password first
                var hashedPassword = PasswordHasher.HashPassword(model.Password);

                // Build JSON for SP
                var jsonBody = JsonConvert.SerializeObject(new
                {
                    model.UserCode,
                    PasswordHash = hashedPassword,
                    model.DeviceID
                });

                // Call SP
                var resultList = await _db.LoginResults
                    .FromSqlRaw("EXEC dbo.Get_Login @JsonBody",
                        new SqlParameter("@JsonBody", jsonBody))
                    .AsNoTracking()
                    .ToListAsync();

                var result = resultList.FirstOrDefault();

                if (result == null)
                    return BadRequest(new { success = false, message = "Login failed." });

                if (result.Code != 200)
                {
                    // Login failed
                    return Unauthorized(new { success = false, message = result.Message });
                }

                // Login success
                return Ok(new
                {
                    success = true,
                    message = result.Message,
                    data = new
                    {
                        result.CodeUser,
                        result.Name,
                        result.Email,
                        result.CompanyName,
                        result.DeviceID,
                        result.IsWebUser,
                        result.Manager,
                        result.PrinterMac,
                        result.PrinterName,
                        result.Profile,
                        result.SlpCode,
                        result.Status,
                        result.UserType
                    }
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetItems([FromBody] LoginRequest model)
        {
            try
            {
                // Hash password
                var hashedPassword = PasswordHasher.HashPassword(model.Password);

                // Build JSON body
                var jsonBody = JsonConvert.SerializeObject(new
                {
                    model.UserCode,
                    PasswordHash = hashedPassword,
                    model.DeviceID
                });

                // Call Stored Procedure
                var resultList = await _db.ItemLoginResults
                    .FromSqlRaw("EXEC dbo.Get_Item_By_Login @JsonBody",
                        new SqlParameter("@JsonBody", jsonBody))
                    .AsNoTracking()
                    .ToListAsync();

                if (resultList == null || resultList.Count == 0)
                    return BadRequest(new { success = false, message = "No data returned." });

                var first = resultList.FirstOrDefault();

                if (first.Code != 200)
                {
                    return Unauthorized(new
                    {
                        success = false,
                        message = first.Message
                    });
                }

                return Ok(new
                {
                    success = true,
                    message = first.Message,
                    total = resultList.Count,
                    data = resultList
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    success = false,
                    message = ex.Message
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetCustomer([FromBody] LoginRequest model)
        {
            try
            {
                var hashedPassword = PasswordHasher.HashPassword(model.Password);

                var jsonBody = JsonConvert.SerializeObject(new
                {
                    model.UserCode,
                    PasswordHash = hashedPassword,
                    model.DeviceID
                });

                var resultList = await _db.CustomerResults
                    .FromSqlRaw("EXEC dbo.Get_Customer @JsonBody",
                        new SqlParameter("@JsonBody", jsonBody))
                    .AsNoTracking()
                    .ToListAsync();

                var result = resultList.FirstOrDefault();

                if (result == null)
                    return BadRequest(new { success = false, message = "No data returned." });

                if (result.Code != 200)
                {
                    return Unauthorized(new
                    {
                        success = false,
                        message = result.Message
                    });
                }

                return Ok(new
                {
                    success = true,
                    message = result.Message,
                    total = resultList.Count,
                    data = resultList
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    success = false,
                    message = ex.Message
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetWhs([FromBody] LoginRequest model)
        {
            try
            {
                var hashedPassword = PasswordHasher.HashPassword(model.Password);

                var jsonBody = JsonConvert.SerializeObject(new
                {
                    model.UserCode,
                    PasswordHash = hashedPassword,
                    model.DeviceID
                });

                var resultList = await _db.WhsResults
                    .FromSqlRaw("EXEC dbo.Get_Whs @JsonBody",
                        new SqlParameter("@JsonBody", jsonBody))
                    .AsNoTracking()
                    .ToListAsync();

                var first = resultList.FirstOrDefault();

                if (first == null)
                    return BadRequest(new { success = false, message = "No data returned." });

                if (first.Code != 200)
                {
                    return Unauthorized(new
                    {
                        success = false,
                        message = first.Message
                    });
                }

                return Ok(new
                {
                    success = true,
                    message = first.Message,
                    total = resultList.Count,
                    data = resultList
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    success = false,
                    message = ex.Message
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetUoM([FromBody] LoginRequest model)
        {
            try
            {
                var hashedPassword = PasswordHasher.HashPassword(model.Password);

                var jsonBody = JsonConvert.SerializeObject(new
                {
                    model.UserCode,
                    PasswordHash = hashedPassword,
                    model.DeviceID
                });

                var resultList = await _db.UoMResults
                    .FromSqlRaw("EXEC dbo.Get_UoM @JsonBody",
                        new SqlParameter("@JsonBody", jsonBody))
                    .AsNoTracking()
                    .ToListAsync();

                var first = resultList.FirstOrDefault();

                if (first == null)
                    return BadRequest(new { success = false, message = "No data returned." });

                if (first.Code != 200)
                {
                    return Unauthorized(new
                    {
                        success = false,
                        message = first.Message
                    });
                }

                return Ok(new
                {
                    success = true,
                    message = first.Message,
                    total = resultList.Count,
                    data = resultList
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    success = false,
                    message = ex.Message
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetUoMGroup([FromBody] LoginRequest model)
        {
            try
            {
                var hashedPassword = PasswordHasher.HashPassword(model.Password);

                var jsonBody = JsonConvert.SerializeObject(new
                {
                    model.UserCode,
                    PasswordHash = hashedPassword,
                    model.DeviceID
                });

                var resultList = await _db.UoMGroupResults
                    .FromSqlRaw("EXEC dbo.Get_UoMGroup @JsonBody",
                        new SqlParameter("@JsonBody", jsonBody))
                    .AsNoTracking()
                    .ToListAsync();

                var first = resultList.FirstOrDefault();

                if (first == null)
                    return BadRequest(new { success = false, message = "No data returned." });

                if (first.Code != 200)
                {
                    return Unauthorized(new
                    {
                        success = false,
                        message = first.Message
                    });
                }

                return Ok(new
                {
                    success = true,
                    message = first.Message,
                    total = resultList.Count,
                    data = resultList
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    success = false,
                    message = ex.Message
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetPriceList([FromBody] LoginRequest model)
        {
            try
            {
                var hashedPassword = PasswordHasher.HashPassword(model.Password);

                var jsonBody = JsonConvert.SerializeObject(new
                {
                    model.UserCode,
                    PasswordHash = hashedPassword,
                    model.DeviceID
                });

                var resultList = await _db.PriceListResults
                    .FromSqlRaw("EXEC dbo.Get_PriceList @JsonBody",
                        new SqlParameter("@JsonBody", jsonBody))
                    .AsNoTracking()
                    .ToListAsync();

                var first = resultList.FirstOrDefault();

                if (first == null)
                    return BadRequest(new { success = false, message = "No data returned." });

                if (first.Code != 200)
                {
                    return Unauthorized(new
                    {
                        success = false,
                        message = first.Message
                    });
                }

                return Ok(new
                {
                    success = true,
                    message = first.Message,
                    total = resultList.Count,
                    data = resultList
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    success = false,
                    message = ex.Message
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetItemPricing([FromBody] LoginRequest model)
        {
            try
            {
                var hashedPassword = PasswordHasher.HashPassword(model.Password);

                var jsonBody = JsonConvert.SerializeObject(new
                {
                    model.UserCode,
                    PasswordHash = hashedPassword,
                    model.DeviceID
                });

                var resultList = await _db.ItemPricingResults
                    .FromSqlRaw("EXEC dbo.Get_ItemPricing @JsonBody",
                        new SqlParameter("@JsonBody", jsonBody))
                    .AsNoTracking()
                    .ToListAsync();

                var first = resultList.FirstOrDefault();

                if (first == null)
                    return BadRequest(new { success = false, message = "No data returned." });

                if (first.Code != 200)
                {
                    return Unauthorized(new
                    {
                        success = false,
                        message = first.Message
                    });
                }

                return Ok(new
                {
                    success = true,
                    message = first.Message,
                    total = resultList.Count,
                    data = resultList
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    success = false,
                    message = ex.Message
                });
            }
        }
    }
}
