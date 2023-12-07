namespace Models.Enums
{
    public enum VerificationStatus
    {
        Valid,
        Invalid,
        // Unable to get status (e.g. service unavailable)
        Unavailable
    }
}