using RecetasSimulacro.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSimulacro.Servicios
{
    abstract class AbstractFactoryService
    {
        public abstract IServicio crearServicio();
    }
}
