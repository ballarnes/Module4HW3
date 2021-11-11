using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4HW3
{
    public class Starter
    {
        public void Run()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.SaveChanges();
            }
        }
    }
}
