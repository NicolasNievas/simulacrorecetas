using RecetasSimulacro.Servicios.Impletaciones;
using RecetasSimulacro.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSimulacro.Servicios
{
    class ServicioFactoryImp : AbstractFactoryService
    {
        public override IServicio crearServicio()
        {
            return new ServicioReceta();
        }
    }
}
