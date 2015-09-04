using System;
using SGBF.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SGBF.Controllers
{
    public abstract class ApplicationController
    {
        protected Entities db()
        {
            return new Entities();
        }
    }
}