using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPatterns.AbstractFactory.Interfaces;

public interface IMealPlanService
{
    public Task SendMealPlanToSubscriber(string customerEmail);
}
