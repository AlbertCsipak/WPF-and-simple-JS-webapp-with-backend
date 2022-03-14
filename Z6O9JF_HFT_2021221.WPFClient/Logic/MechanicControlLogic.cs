using Microsoft.Toolkit.Mvvm.Messaging;
using Z6O9JF_HFT_2021221.Models;

namespace Z6O9JF_HFT_2021221.WPFClient.Logic
{
    public class MechanicControlLogic : IMechanicControlLogic
    {
        RestCollection<Mechanic> mechanics;
        IMessenger messenger;
        public MechanicControlLogic(IMessenger messenger)
        {
            this.messenger = messenger;
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
            messenger.Send("msg", "BasicChannel");
        }
        public void Edit(Mechanic mechanic)
        {
            mechanics.Update(mechanic);
            messenger.Send("msg", "BasicChannel");
        }
        public void Remove(Mechanic mechanic)
        {
            mechanics.Delete(mechanic.MechanicId);
            messenger.Send("msg", "BasicChannel");
        }
    }
}
