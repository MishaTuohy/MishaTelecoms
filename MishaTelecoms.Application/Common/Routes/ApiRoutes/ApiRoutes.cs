using System;
using System.Collections.Generic;
using System.Text;

namespace MishaTelecoms.Application.Common.Routes.ApiRoutes
{
    public static class ApiRoutes
    {
        public const string Root = "api/";
        public static class CDRData
        {
            public const string Base = Root + "cdrdata";
            public const string GetById = "/id={id}";
            public const string GetByCountry = "/country={country}";
            public const string GetByCallType = "/calltype={calltype}";
            public const string GetByDateCreated = "/datecreated={datecreated}";
            public const string Update = "/update/id={Id}";
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
