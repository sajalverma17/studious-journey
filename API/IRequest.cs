using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API
{
    interface IRequest<TIn,TOut> 
    {       
        Task<TOut> MakeRequest(TIn request);
    }
}
