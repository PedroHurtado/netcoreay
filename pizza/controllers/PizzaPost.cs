using Application;
using Domain;
namespace Controller{
    class PizzaPost{
        private readonly IAddPizza _service;
        public PizzaPost(IAddPizza service){
            _service = service;
        }
        public Pizza Request(CommandCreatePizza command){
            return _service.Add(command);
        }
    }
}