namespace MishaTelecoms.Application.Common.Routes.ApiRoutes
{
    public static class ApiRoutes
    {
        public const string Root = "api/";
        public static class CDRData
        {
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

            // POST REQUESTS
            public const string UpdateAll = Base + "/all";
            public const string UpdateCallingNumber = Base + "/callingnumber";
            public const string UpdateCalledNumber = Base + "/callednumber";
            public const string UpdateCountry = Base + "/country";
            public const string UpdateCallType = Base + "/calltype";
            public const string UpdateDuration = Base + "/duration";
            public const string UpdateCost = Base + "/cost";
            public const string Delete = Base + "/id={Id}";
        }

        public static class Identity
        {
            public const string Base = Root + "identity";
            public const string Login = Base + "login";
            public const string Register = Base + "register";
        }

        public static class User
        {
            public const string Base = Root + "user";
            public const string Login = Base + "login";
            public const string Register = Base + "register";
        }
    }
}
