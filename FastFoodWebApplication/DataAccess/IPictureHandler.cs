using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodWebApplication.DataAccess
{
    interface IPictureHandler
    {
        void SavePictureInFile(byte[] pictureBinary, string fileName);
    }
}
