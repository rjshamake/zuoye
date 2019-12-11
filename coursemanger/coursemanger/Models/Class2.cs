using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace coursemanger.Models
{
    public partial class classes
    {
        public string teachername
        {
            get {
                if (!teacherid.HasValue)
                {
                    return "";

                }
            coursemangerEntities db = new coursemangerEntities();
            var teacher = db.teachers.Where(t => t.id == teacherid.Value).FirstOrDefault();
            if (teacher == null) {
                return "";
            }
            return teacher.name;
            }
        }
        }
    }
