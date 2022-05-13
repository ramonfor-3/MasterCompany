using LogicaNegocios.Dtos;
using LogicaNegocios.Servicios.Interfaz;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Master_Company.Controllers
{
    public class EmpleadosController : ControllerBase
    {
        private readonly IEmpleadoService _empleadoService;
        public EmpleadosController(IEmpleadoService empleadoService)
        {
            _empleadoService = empleadoService;
        }

        [HttpGet("ObtenerEmpleados")]
        public List<Empleado> Get()
        {
            var empleados = _empleadoService.ObteneEmpleados();
            return empleados;

        }

        [HttpGet("ObtenerEmpleadosPorRangoSalarial")]
        public List<Empleado> ObtenerPorSalario([FromQuery] int salarioDesde, [FromQuery] int SalarioHasta )
        {
            var empleados = _empleadoService.ObtenerEmpleadosPorRangoSalarial(salarioDesde, SalarioHasta);
            return empleados;

        }

        [HttpGet("ObtenerEmpleadosSinDuplicados")]
        public List<Empleado> GetSinDuplicados()
        {
            var empleados = _empleadoService.ObtenerEmpleadosSinDuplicados();
            return empleados;

        }

        [HttpGet("ObtenerEmpleadosNuevosSalarios")]
        public List<EmpleadoDto> GetAllEmpleadosPorSalario()
        {
            var empleados = _empleadoService.ObtenerSalariosConAumento();
            return empleados;

        }


        [HttpGet("ObtenerEmpleadosPorGenero")]
        public PorcentajeGeneroDto GetAllEmpleadosPorGenero()
        {
            var empleados = _empleadoService.ObteneEmpleadosPorGenero();
            return empleados;

        }

        [HttpDelete("EliminarEmpleado")]
        public string EliminarPorDocumento([FromQuery] string documento)
        {
            var empleado = _empleadoService.EliminarPorDocumento(documento);
            return empleado;
        }

        [HttpPost("crearEmpleado")]
        public string CrearEmpleado([FromBody] Empleado empleado)
        {
            var empleadoCreado = _empleadoService.CrearEmpleado(empleado);
            return empleadoCreado;
        }
        
    }
}
