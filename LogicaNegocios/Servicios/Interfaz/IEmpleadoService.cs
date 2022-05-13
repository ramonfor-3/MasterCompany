using LogicaNegocios.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocios.Servicios.Interfaz
{
    public interface IEmpleadoService
    {
        List<Empleado> ObteneEmpleados();
        List<Empleado> ObtenerEmpleadosPorRangoSalarial(int salario1, int salario2);
        List<EmpleadoDto> ObtenerSalariosConAumento();
        List<Empleado> ObtenerEmpleadosSinDuplicados();
        PorcentajeGeneroDto ObteneEmpleadosPorGenero();
        string EliminarPorDocumento(string document);
        string CrearEmpleado(Empleado empleado);
    }
}
