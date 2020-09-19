using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RundownEdu.Interfaces
{
    interface IConvertToModel<T>
    {
        T ConvertToModel();
        T ConvertToModel(T model);
    }

    interface IConvertToModel<T, U>
    {
        T ConvertToModel(U context);
        T ConvertToModel(U context, T model);
    }

}
