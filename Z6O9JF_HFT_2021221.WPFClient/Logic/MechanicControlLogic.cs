using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z6O9JF_HFT_2021221.Models;

namespace Z6O9JF_HFT_2021221.WPFClient.Logic
{
    public class MechanicControlLogic : IMechanicControlLogic
    {
        RestCollection<Mechanic> mechanics;
        public MechanicControlLogic()
        {
            
        }
        public void Setup(RestCollection<Mechanic> mechanic) { this.mechanics = mechanic; }
        public void Add(Mechanic mechanic)
        {
            Mechanic newMechanic = new Mechanic()
            {
                Name = mechanic.Name,
                ServiceId = mechanic.ServiceId
            };
            mechanics.Add(newMechanic);
        }
        public void Edit(Mechanic mechanic)
        {
            mechanics.Update(mechanic);
        }
        public void Remove(Mechanic mechanic)
        {
            mechanics.Delete(mechanic.MechanicId);
        }
    }
}
