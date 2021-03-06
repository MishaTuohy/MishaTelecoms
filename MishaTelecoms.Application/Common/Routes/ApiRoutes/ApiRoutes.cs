namespace MishaTelecoms.Application.Common.Routes.ApiRoutes
{
    public static class ApiRoutes
    {
        public const string Root = "api/";
        public static class CDRData
        {
            // BASE
            public const string Base = Root + "cdrdata";

            // GET REQUESTS
            public const string GetById = Base + "/id={id}";
            public const string GetByCallingNumber = Base + "/callingnumber={callingnumber}";
            public const string GetByCalledNumber = Base + "/callednumber={callednumber}";
            public const string GetByCountry = Base + "/country={country}";
            public const string GetByCallType = Base + "/calltype={calltype}";
            public const string GetByDateCreated = Base + "/datecreated={datecreated}";
            public const string GetByDuration = Base + "/duration={duration}";
            public const string GetByCost = Base + "/cost={cost}";

            // UPDATE REQUESTS
            public const string UpdateAll = Base + "/all";
            public const string UpdateCallingNumber = Base + "/callingnumber";
            public const string UpdateCalledNumber = Base + "/callednumber";
            public const string UpdateCountry = Base + "/country";
            public const string UpdateCallType = Base + "/calltype";
            public const string UpdateDuration = Base + "/duration";
            public const string UpdateCost = Base + "/cost";

            // DELETE REQUESTS
            public const string Delete = Base + "/id={Id}";
        }

        public static class User
        {
            // BASE
            public const string Base = Root + "user";

            // GET REQUESTS
            public const string GetById = Base + "/id={id}";
            public const string GetByUserName = Base + "/username={username}";
            public const string GetByEmail = Base + "/email={email}";
            public const string GetByPhoneNumber = Base + "/phonenumber={phonenumber}";

            // UPDATE REQUESTS
            public const string UpdateAll = Base + "/all";
            public const string UpdateUserName = Base + "/UserName";
            public const string UpdateNormalizedUserName = Base + "/NormalizedUserName";
            public const string UpdateEmail = Base + "/Email";
            public const string UpdateNormalizedEmail = Base + "/NormalizedEmail";
            public const string UpdateEmailConfirmed = Base + "/EmailConfirmed";
            public const string UpdatePhoneNumber = Base + "/PhoneNumber";
            public const string UpdatePhoneNumberConfirmed = Base + "/PhoneNumberConfirmed";
            public const string UpdatePasswordHash = Base + "/PasswordHash";
            public const string UpdateTwoFactorEnabled = Base + "/TwoFactorEnabled";

            // DELETE REQUESTS
            public const string Delete = Base + "/id={Id}";
        }

        public static class Identity
        {
            public const string Base = Root + "identity";
            public const string Login = Base + "login";
            public const string Register = Base + "register";
        }
    }
}
