﻿//-----------------------------------------------------------------------
// <copyright file="PluginContentController.cs" company="(none)">
//  Copyright © 2011 John Gietzen. All rights reserved.
// </copyright>
// <author>John Gietzen</author>
//-----------------------------------------------------------------------

namespace WebGitNet
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web.Mvc;

    public class PluginContentController : Controller
    {
        public ActionResult Resource(string assemblyName, string resourceName, string contentType = "application/octet-stream")
        {
            if (Url.RouteCollection["Default"] == RouteData.Route)
            {
                return HttpNotFound();
            }

            var assembly = (from a in AppDomain.CurrentDomain.GetAssemblies()
                            where !a.IsDynamic
                            where a.GetName().Name == assemblyName
                            select a).FirstOrDefault();

            if (assembly == null)
            {
                return HttpNotFound();
            }

            var resource = assembly.GetManifestResourceStream(resourceName);
            return File(resource, contentType);
        }
    }
}
