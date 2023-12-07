using Models.Enums;
using Logging.Interfaces;
using WebApi.EUViesService;
using WebApi.Interfaces;

namespace WebApi.Services
{
    public class VatVerifierService : IVatVerifier
    {
        public ILoggerFacade LoggerFacade { get; }

        public VatVerifierService(ILoggerFacade loggerFacade)
        {
            LoggerFacade = loggerFacade;
        }

        /// <summary>
        /// Verifies the given VAT ID for the given country using the EU VIES web service.
        /// </summary>
        /// <param name="countryCode">Country code to verify</param>
        /// <param name="vatId">Vat number to verify</param>
        /// <returns>Verification status</returns>
        public async Task<VerificationStatus> VerifyVat(string countryCode, string vatId)
        {
            //Only validation done here to ensure that no api request is made with empty values
            //The remaining validations are done by the api itself. So if they change the rules we
            //don't to change our code
            if (string.IsNullOrEmpty(countryCode) || string.IsNullOrEmpty(vatId))
            {
                return VerificationStatus.Invalid;
            }

            VerificationStatus vatStatus;
            try
            {
                checkVatRequest request = new checkVatRequest(countryCode, vatId);
                checkVatPortTypeClient webClient = new checkVatPortTypeClient();
                checkVatResponse response = await webClient.checkVatAsync(request);
                vatStatus = response.valid ? VerificationStatus.Valid : VerificationStatus.Invalid;
            }
            catch (Exception e)
            {
                string msg = $"Failed to verify for vat number: {vatId} and country " +
                    $"code: {countryCode} {Environment.NewLine} {e.Message}";
                LoggerFacade.LogMessage(msg);                
                return VerificationStatus.Unavailable;
            }

            return vatStatus;
        }
    }
}
