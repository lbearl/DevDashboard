// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultRegistry.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using Microsoft.AspNet.Identity;
using StatusBoard.Core.IExternalServices;
using StatusBoard.Core.Models.Identity;
using StatusBoard.Infrastructure.DbContext;
using StatusBoard.Infrastructure.ExternalServices;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;

namespace StatusBoard.Infrastructure.DependencyResolution {
    public class DefaultRegistry : Registry {
        #region Constructors and Destructors

        public DefaultRegistry()
        {

            For<IUnitOfWork>().Use<UnitOfWork>().Ctor<string>().Is("default");
            //for making migrations work
            For<ApplicationDbContext>().Use<ApplicationDbContext>().Ctor<string>().Is("default");
            For<IUserStore<ApplicationUser, Guid>>().Use<UserStore>();
            For<IPingService>().Use<HttpPingService>();
            Scan(
                scan => {
                    scan.TheCallingAssembly();
                    scan.AssemblyContainingType<IUnitOfWork>();
                    scan.WithDefaultConventions();
					scan.With(new ControllerConvention());
                });
        }

        #endregion
    }
}