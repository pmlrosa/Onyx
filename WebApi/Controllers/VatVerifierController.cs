using Models.Enums;
using Microsoft.AspNetCore.Mvc;
using WebApi.Interfaces;
using System.Net.Mime;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class VatVerifierController : ControllerBase
    {
        public IVatVerifier VatVerifierService { get; }

        public VatVerifierController(IVatVerifier vatVerifierService)
        {
            VatVerifierService = vatVerifierService;
        }


        /// <summary>
        /// Verifies the given VAT ID for the given country using the EU VIES web service.
        /// </summary>
        /// <param name="countryCode">Country code to verify</param>
        /// <param name="vatId">Vat number to verify</param>
        /// <returns>Verification status</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<VerificationStatus>> VerifyVat([FromQuery]string countryCode,
            [FromQuery] string vatId)
        {
            return Ok(await VatVerifierService.VerifyVat(countryCode, vatId));
    }
    }
}
