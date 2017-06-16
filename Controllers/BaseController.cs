using Draper.Logger;
using EasyFunFinder.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Principal;

namespace EasyFunFinderWebAPI.Controllers
{
    public class BaseController : Controller
    {
        private Log _logger;

        protected Log Logger { get { return _logger; } }
        public EasyFunFinderContext DC { get; private set; }

        public BaseController(EasyFunFinderContext dc)
        {
            DC = dc;
            _logger = new Log("EasyFunFinder.WebAPI", WindowsIdentity.GetCurrent().Name);
        }

        public int[] ToIntArray(string commaDelimitedString)
        {
            string[] parts = commaDelimitedString.Split(',');
            int len = parts.Length;
            int[] values = new int[len];
            for (int i = 0; i < len; ++i)
            {
                values[i] = Convert.ToInt32(parts[i]);
            }
            return values;
        }
    }
}