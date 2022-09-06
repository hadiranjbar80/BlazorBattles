using BlazorBattles.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorBattles.Client.Services
{
    public interface IUnitService
    {
        List<Unit> Units { get; }
        List<UserUnit> MyUnits { get; set; }
        void AddUnit(int unitId);
    }
}
