namespace MishaTelecoms.Application.Common.Routes.ApiRoutes
{
    public static class ApiRoutes
    {
        public const string Root = "api/";
        public static class CDRData
        {
            public const string Base = Root + "cdrdata";
            // GET REQUESTS
            public const string GetById = "/id={id}";
            public const string GetByCallingNumber = "/callingnumber={callingnumber}";
            public const string GetByCalledNumber = "/callednumber={callednumber}";
            public const string GetByCountry = "/country={country}";
            public const string GetByCallType = "/calltype={calltype}";
            public const string GetByDateCreated = "/datecreated={datecreated}";
            public const string GetByDuration = "/duration={duration}";
            public const string GetByCost = "/cost={cost}";

            // POST REQUESTS
            public const string UpdateAll = "/update/all";
            public const string UpdateCallingNumber = "/update/callingnumber";
            public const string UpdateCalledNumber = "/update/callednumber";
            public const string UpdateCountry = "/update/country";
            public const string UpdateCallType = "/update/calltype";
            public const string UpdateDuration = "/update/duration";
            public const string UpdateCost = "/update/cost";
            public const string Delete = "/delete/id={Id}";
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
