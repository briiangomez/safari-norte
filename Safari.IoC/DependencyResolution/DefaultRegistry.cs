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

namespace Safari.IoC.DependencyResolution
{
    using Framework.Logging;
    using Entities;
    using Services;
    using Services.Contracts;
    using StructureMap.Configuration.DSL;
    using StructureMap.Graph;
    using Business;
    using Data;
    using UI.Process;
    using UI.Process.APIProcess;

    public class DefaultRegistry : Registry {
        #region Constructors and Destructors

        public DefaultRegistry() {
            Scan(
                scan => {
                    scan.TheCallingAssembly();

                    scan.AddAllTypesOf(typeof(IGenericService<>));
                    scan.AddAllTypesOf(typeof(IProcess<>));
                    scan.AddAllTypesOf(typeof(IApiProcess<>));
                    scan.AddAllTypesOf(typeof(IComponent<>));

                    scan.WithDefaultConventions();
					scan.With(new ControllerConvention());
                });
            For<IApiProcess<Especie>>().Use<EspecieAPIProcess>();
            For<IApiProcess<Sala>>().Use<SalaAPIProcess>();
            For<IApiProcess<TipoMovimiento>>().Use<TipoMovimientoAPIProcess>();
            For<IApiProcess<TipoServicio>>().Use<TipoServicioAPIProcess>();
            For<IApiProcess<Cliente>>().Use<ClienteAPIProcess>();
            For<IApiProcess<Paciente>>().Use<PacienteAPIProcess>();
            For<IApiProcess<Medico>>().Use<MedicoAPIProcess>();
            For<IApiProcess<Movimiento>>().Use<MovimientoAPIProcess>();
            For<IApiProcess<Cita>>().Use<CitaAPIProcess>();


            For<IGenericService<Especie>>().Use<EspecieService>();
            For<IGenericService<Sala>>().Use<SalaService>();
            For<IGenericService<TipoMovimiento>>().Use<TipoMovimientoService>();
            For<IGenericService<Cliente>>().Use<ClienteService>();

            For<IComponent<Especie>>().Use<EspecieComponent>();
            For<IComponent<Sala>>().Use<SalaComponent>();
            For<IComponent<TipoMovimiento>>().Use<TipoMovimientoComponent>();
            For<IComponent<Cliente>>().Use<ClienteComponent>();

            For<IRepository<Especie>>().Use<EspecieDAC>();
            For<IRepository<TipoMovimiento>>().Use<TipoMovimientoDAC>();
            For<IRepository<Sala>>().Use<SalaDAC>();
            For<IRepository<Cliente>>().Use<ClienteDAC>();
            For<ILoggingService>().Use<LoggingService>();
        }

        #endregion
    }
}