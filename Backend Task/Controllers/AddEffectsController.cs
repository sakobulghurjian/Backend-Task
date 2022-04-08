using Backend_Task.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddEffectsController : ControllerBase
    {
        private List<Effect> effects;
        public AddEffectsController()
        {
            Effect e1 = new Effect(1, "Resize_To");
            Effect e2 = new Effect(2, "Add_Blur");
            Effect e3 = new Effect(3, "Convert_To");
            effects = new List<Effect>()
            {
                e1, e2, e3
            };
        }

        public List<Effect> Get()
        {
            return effects;
        }

        public void AddEffect(Effect effect)
        {
            effects.Add(effect);
        }

        public void DeleteEffect(int Id)
        {
            var ef = effects.FirstOrDefault(e => e.Id == Id);
            if (ef != null)
            {
                effects.Remove(ef);
            }
        }
        [HttpPost]
        [Route("Test")]
        public string AddEffectToImage(string ImageURl,List<EffectAPI> values)
        {
            string results="";
            foreach (var item in values)
            {
                if (Check(item.Id))
                {
                    string res = ApplyEffect(item.Id, item.Value, ImageURl);
                    results += res +"___";
                }
                else
                {
                    results += "Error the effect id is wrong___";
                }
            }

            return results;
        }

        private bool Check(int Id)
        {
            if (Id > effects.Count || Id < 0)
                return false;
            
            return true;
        }

        private string ApplyEffect(int Id, string value, string image)
        {
            if (Id == 1)
            {
                try
                {
                    int v = int.Parse(value);
                    // Resize_To function
                    return "Resized";
                }
                catch (Exception)
                {
                    return "Error you have to put number";
                }
            }
            if (Id == 2)
            {
                try
                {
                    int v = int.Parse(value);
                    // Add_Blur function
                    return "Blur added";
                }
                catch (Exception)
                {
                    return "Error you have to put number";
                }
            }
            if (Id == 3)
            {
                // Convert_To function
                return "success";
            }
            return "Error";
        }

    }
}
