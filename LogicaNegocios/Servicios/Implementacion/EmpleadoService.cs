using LogicaNegocios.Dtos;
using LogicaNegocios.Servicios.Interfaz;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocios.Servicios
{
    public class EmpleadoService: IEmpleadoService
    {
        StreamReader filePath = new StreamReader("C:/Users/ramon/source/repos/Master Company/AccesoDatos/Empleados/EmpleadosDb.json");
        public EmpleadoService()
        {
            
        }

        public List<Empleado> ObteneEmpleados()
        {
            List<Empleado> empleados = new List<Empleado>();
            var json = filePath.ReadToEnd();
            var array = JsonConvert.DeserializeObject<List<Empleado>>(json);
            foreach (var item in array)
            {
                empleados.Add(item);
            }

            return empleados;
        }

        public string EliminarPorDocumento(string document)
        {
            try
            {
                List<Empleado> empleados = new List<Empleado>();
                var json = filePath.ReadToEnd();
                var array = JsonConvert.DeserializeObject<List<Empleado>>(json);
                foreach (var item in array)
                {
                    empleados.Add(item);
                }
                filePath.Dispose();
                    filePath.Close();

                var empleadoBorrado = empleados.FirstOrDefault(x => x.Document == document);
                if (empleadoBorrado != null)
                {
                    var nuevaListaEmpleados = empleados.Remove(empleadoBorrado);
                    var nuevaListaEmpleadosSerializada = JsonConvert.SerializeObject(empleados);
                    File.WriteAllText("C:/Users/ramon/source/repos/Master Company/AccesoDatos/Empleados/EmpleadosDb.json", nuevaListaEmpleadosSerializada);
                    return empleadoBorrado.Document;
                } else
                {
                    return "No se ha podido eliminar el empleado";
                }
            }
            catch (Exception e)
            {

                throw new Exception($"Ha ocurrido un error inesperado {e}");
            }

        }

        public string CrearEmpleado(Empleado empleado)
        {
            try
            {
               
                    List<Empleado> empleados = new List<Empleado>();
                    var json = filePath.ReadToEnd();
                    var array = JsonConvert.DeserializeObject<List<Empleado>>(json);
                    foreach (var item in array)
                    {
                        empleados.Add(item);
                    }
                    filePath.Close();
                    var empleadoExiste = empleados.FirstOrDefault(x => x.Document == empleado.Document);
                    if (empleadoExiste != null)
                    {
                        return "El empleado con cedula " + empleadoExiste.Document + "ya existe";
                    }
                    else
                    {
                        empleados.Add(empleado);
                        var nuevaListaEmpleadosSerializada = JsonConvert.SerializeObject(empleados);
                        File.WriteAllText("C:/Users/ramon/source/repos/Master Company/AccesoDatos/Empleados/EmpleadosDb.json", nuevaListaEmpleadosSerializada);
                        return "El empleado con cedula " + empleado.Document + " Ha sido creado";
                    }
            
              
            }
            catch (Exception e)
            {

                throw new Exception($"Ha ocurrido un error inesperado {e}");
            }

        }

        public PorcentajeGeneroDto ObteneEmpleadosPorGenero()
        {
            List<Empleado> empleados = new List<Empleado>();
            var json = filePath.ReadToEnd();
            var array = JsonConvert.DeserializeObject<List<Empleado>>(json);
            foreach (var item in array)
            {
                empleados.Add(item);
            }

            var masculinos = empleados.Where(x => x.Gender == "M").Count();
            var femeninos = empleados.Where(x => x.Gender == "F").Count();

            var porcentaje = new PorcentajeGeneroDto()
            {
                Masculino = masculinos.ToString(),
                Femenino = femeninos.ToString()
            };

            return porcentaje;
        }

        public List<EmpleadoDto> ObtenerSalariosConAumento()
        {
            List<EmpleadoDto> empleados = new List<EmpleadoDto>();
            var json = filePath.ReadToEnd();
            var array = JsonConvert.DeserializeObject<List<EmpleadoDto>>(json);
            foreach (var item in array)
            {
             
                if(item.Salary >= 100000)
                {
                    item.NewSalary = (int)(item.Salary * 0.25) + item.Salary;
                }else  
                {
                    item.NewSalary = (int)(item.Salary * 0.30) + item.Salary;
                }
                empleados.Add(item);
            }
            return empleados;
        }

        public List<Empleado> ObtenerEmpleadosSinDuplicados()
        {
            List<Empleado> empleados = new List<Empleado>();
            var json = filePath.ReadToEnd();
            var array = JsonConvert.DeserializeObject<List<Empleado>>(json);
            foreach (var item in array)
            {
                empleados.Add(item);
            }

            empleados = empleados.GroupBy(e => e.Document).Select(e => e.First()).ToList();

            return empleados;
        }

        public List<Empleado> ObtenerEmpleadosPorRangoSalarial(int salario1, int salario2)
        {
            try
            {
                if(salario1 > salario2)
                {
                    throw new Exception("El primer parametro de rango no puede ser menor al segundo");
                }

                List<Empleado> empleados = new List<Empleado>();
                var json = filePath.ReadToEnd();
                var array = JsonConvert.DeserializeObject<List<Empleado>>(json);
                foreach (var item in array)
                {
                    empleados.Add(item);
                }

                empleados = empleados.Where(x => x.Salary >= salario1 && x.Salary <= salario2).ToList();

            return empleados;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
