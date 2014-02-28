using ToDo.Models;
using ToDo.Models.Input;
using ToDo.Models.Output;
using ToDo.Managers;

namespace ToDo.Controllers
{
    public class DutyController
    {
        //private readonly IRavenManager<Duty> _ravenDutyManager;
        //private readonly IRavenManager<Project> _ravenProjectManager;

        //public DutyController(IRavenManager<Duty> ravenDutyManager, IRavenManager<Project> ravenProjectManager)
        //{
        //    _ravenDutyManager = ravenDutyManager;
        //    _ravenProjectManager = ravenProjectManager;
        //}

        //public ListJsonResponse<Duty> get_Duties()
        //{
        //    return new ListJsonResponse<Duty>
        //    {
        //        Items = _ravenDutyManager.LoadAll()
        //    };
        //}

        //public ItemJsonResponse<Duty> post_Duty_New(SaveJsonInput model)
        //{
        //    var duty = _ravenDutyManager.Save(new Duty(model.Name, model.Description), null);

        //    return new ItemJsonResponse<Duty>
        //    {
        //        Item = duty
        //    };
        //}

        //public ItemJsonResponse<Duty> post_Duty_Update(UpdateDutyJsonInput model)
        //{
        //    var duty = new Duty
        //    {
        //        Name = model.Name,
        //        Description = model.Description,
        //        Id = model.Id,
        //        Status = Duty.StateFromString(model.Status)
        //    };

        //    _ravenDutyManager.Save(duty, duty.Id);

        //    return new ItemJsonResponse<Duty>
        //    {
        //        Item = duty
        //    };
        //}

        //public IdJsonOutput post_Duty_Remove(IdJsonInput model)
        //{
        //    var id = _ravenDutyManager.Remove(model.Id);

        //    return new IdJsonOutput
        //    {
        //        Id = id
        //    };
        //}
    }
}
