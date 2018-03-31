using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Validation;

namespace Plus.Api.Helpers
{
    public static class Tutil
    {

        public static Exception entityException(DbEntityValidationException ex)
        {
            Exception raise = ex;
            foreach (var validationErrors in ex.EntityValidationErrors)
            {
                foreach (var validationError in validationErrors.ValidationErrors)
                {
                    string message = string.Format("{0}:{1}", validationErrors.Entry.Entity.ToString(), validationError.ErrorMessage);
                    // raise a new exception nesting
                    // the current instance as InnerException
                    raise = new InvalidOperationException(message, raise);
                }
            }
            return raise;
        }
    }
}
