using Models.Enums;

namespace WebApi.Interfaces
{
    public interface IVatVerifier
    {
        /// <summary>
        /// Verifies the given VAT ID for the given country using the EU VIES web service.
        /// </summary>
        /// <param name="countryCode">Country code to verify</param>
        /// <param name="vatId">Vat number to verify</param>
        /// <returns>Verification status</returns>
        public Task<VerificationStatus> VerifyVat(string countryCode, string vatId);
    }
}
