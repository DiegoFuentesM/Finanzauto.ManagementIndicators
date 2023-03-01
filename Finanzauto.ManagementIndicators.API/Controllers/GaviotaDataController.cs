using Finanzauto.ManagementIndicators.API.Models;
using Finanzauto.ManagementIndicators.API.Persistence;
using Finanzauto.ManagementIndicators.API.Vms;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Finanzauto.ManagementIndicators.API.Controllers
{
    [ApiController]
    [Route("api/v1/gaviotaData")]
#if !DEBUG
    [Authorize]
#endif
    public class GaviotaDataController : ControllerBase
    {
        private readonly GaviotaDataDbContext _db;

        public GaviotaDataController(GaviotaDataDbContext db)
        {
            _db = db;
        }

        [HttpPost(Name = "InsertGaviotaData")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<int>> InsertGaviotaData([FromBody] InsertGaviotaDataVM data)
        {
            if (data == null)
                return BadRequest();
            try
            {
                var gaviotaData = new GaviotaData
                {
                    RequestId = data.RequestId,
                    PhaseId = data.PhaseId,
                    Phase = data.Phase,
                    Analyst = data.Analyst,
                    StartDate = data.StartDate,
                    StartHour = data.StartHour,
                    EndDate = data.EndDate,
                    EndHour = data.EndHour,
                    CreatedAt = DateTime.Now
                };

                var registry = await _db.AddAsync(gaviotaData);
                _db.SaveChanges();
                return Ok($"Data from request: {gaviotaData.RequestId}, recorded successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
