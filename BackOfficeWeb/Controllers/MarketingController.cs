using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using BackOfficeWeb;

namespace BackOfficeWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // ✅ Protect with JWT
    public class POController : ControllerBase
    {
        private readonly AppDbContext _db;

        public POController(AppDbContext db)
        {
            _db = db;
        }

        // POST: Add / Update PO
        [HttpPost("Save")]
        public async Task<IActionResult> AddOrUpdatePO([FromBody] PO model)
        {
            try
            {
                var token = new { UserId = 1, UserName = "Admin", CompanyId = 1001 }; // later replace with real JWT user
                string mode = model.Mode ?? "Add";

                // ✅ Build JSON for SP
                var jsonBody = JsonConvert.SerializeObject(new
                {
                    Mode = mode,
                    model.DocEntry,
                    model.Branch,
                    model.CardCode,
                    model.CardName,
                    model.PostingDate,
                    model.DueDate,
                    model.ExchangeRate,
                    model.VATStatus,
                    model.PaymentTerm,
                    model.SaleCode,
                    model.Remark,
                    model.SubTotal,
                    model.DPMAmount,
                    model.VATAmount,
                    model.DiscountPercent,
                    model.DiscountAmount,
                    model.PaidAmount,
                    model.DocAmount,
                    model.DocStatus,
                    model.SAPCode,
                    model.SAPStatus,
                    model.APIStatus,
                    model.APIErrorMessage,
                    model.DoCur,
                    CreateBy = token.UserId,
                    UpdateBy = token.UserId,

                    PO1 = model.PODetails?.Select(d => new
                    {
                        d.DocEntry,
                        d.LineNum,
                        d.BaseType,
                        d.BaseEntry,
                        d.BaseLineNum,
                        d.ItemCode,
                        d.ItemName,
                        d.UOM,
                        d.Quantity,
                        d.Price,
                        d.DiscountPercent,
                        d.DiscountAmount,
                        d.VAT,
                        d.LineAmount,
                        d.Warehouse,
                        d.OcrCode,
                        d.OcrCode2,
                        d.OcrCode3,
                        d.OcrCode4,
                        d.Project,
                        d.LineStatus,
                        d.Remark,
                        d.IsFather,
                        d.FatherCode
                    })
                });

                var resultList = await _db.Set<SpResult>()
                    .FromSqlRaw("EXEC dbo.ControllerPO @MasterType, @TranType, @EntryPrimary, @JsonBody",
                        new SqlParameter("@MasterType", "PO"),
                        new SqlParameter("@TranType", mode),
                        new SqlParameter("@EntryPrimary", model.DocEntry ?? ""),
                        new SqlParameter("@JsonBody", jsonBody))
                    .AsNoTracking()
                    .ToListAsync();

                var result = resultList.FirstOrDefault();

                if (result != null && result.Code == 200)
                {
                    return Ok(new
                    {
                        success = true,
                        message = result.Message,
                        primaryKey = result.PrimaryKey // ✅ Return generated DocEntry
                    });
                }

                return BadRequest(new
                {
                    success = false,
                    message = result?.Message ?? "Error processing PO"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    success = false,
                    message = $"Operation failed: {ex.Message}"
                });
            }
        }
    }
}
