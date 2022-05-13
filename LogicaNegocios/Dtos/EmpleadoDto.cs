using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocios.Dtos
{
    public class EmpleadoDto
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public int Salary { get; set; }
        public int NewSalary { get; set; }
        public string Gender { get; set; }
        public string Position { get; set; }
        public string StartDate { get; set; }
    }
}
