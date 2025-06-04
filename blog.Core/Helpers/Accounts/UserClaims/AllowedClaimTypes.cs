namespace blog.Core.Helpers.Accounts.Claims
{
    public static class AllowedClaimTypes
    {
        // Common custom claims
        public const string Permission = "Permission";
        public const string Department = "Department";
        public const string Role = "role"; // standard lowercase "role"
        public const string Location = "Location";
        public const string AccessLevel = "AccessLevel";

        // Standard JWT and .NET claim types (mostly from System.Security.Claims.ClaimTypes or JWT)
        public const string Name = "name";
        public const string GivenName = "given_name";
        public const string FamilyName = "family_name";
        public const string Email = "email";
        public const string EmailVerified = "email_verified";
        public const string PhoneNumber = "phone_number";
        public const string PhoneNumberVerified = "phone_number_verified";
        public const string DateOfBirth = "birthdate";
        public const string Gender = "gender";
        public const string Locale = "locale";
        public const string Profile = "profile";
        public const string Website = "website";
        public const string StreetAddress = "street_address";
        public const string PostalCode = "postal_code";
        public const string Country = "country";
        public const string City = "city";
        public const string StateOrProvince = "state";

        // System.Security.Claims.ClaimTypes URIs (common in .NET Identity)
        public const string NameIdentifier = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier";
        public const string AuthenticationMethod = "http://schemas.microsoft.com/ws/2008/06/identity/authenticationmethod";
        public const string AuthenticationInstant = "http://schemas.microsoft.com/ws/2008/06/identity/authenticationinstant";
        public const string AuthorizationDecision = "http://schemas.microsoft.com/ws/2008/06/identity/authorizationdecision";
        public const string CountryOfResidence = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/country";
        public const string Date = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/dateofbirth";
        public const string Dns = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/dns";
        public const string DenyOnlySid = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/denyonlysid";
        public const string DenyOnlyPrimaryGroupSid = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/denyonlyprimarygroupsid";
        public const string DenyOnlyGroupSid = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/denyonlygroupsid";
        public const string Expiration = "http://schemas.microsoft.com/ws/2008/06/identity/claims/expiration";
        public const string GroupSid = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/groupsid";
        public const string Hash = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/hash";
        public const string HomePhone = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/homephone";
        public const string IsPersistent = "http://schemas.microsoft.com/ws/2008/06/identity/isPersistent";
        public const string MobilePhone = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/mobilephone";
        public const string OtherPhone = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/otherphone";
        public const string PrimaryGroupSid = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/primarygroupsid";
        public const string PrimarySid = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/primarysid";
        public const string Sid = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid";
        public const string Spn = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/spn";
        public const string System = "http://schemas.microsoft.com/ws/2008/06/identity/claims/system";
        public const string Thumbprint = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/thumbprint";
        public const string Upn = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/upn";
        public const string Uri = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/uri";
        public const string UserData = "http://schemas.microsoft.com/ws/2008/06/identity/claims/userdata";
        public const string WindowsAccountName = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/windowsaccountname";
    }
}
