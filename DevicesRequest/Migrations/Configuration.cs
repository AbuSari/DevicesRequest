namespace DevicesRequest.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DevicesRequest.Models.DevicesRequestDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DevicesRequest.Models.DevicesRequestDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var stauts = context.RequestStatus.Count();
            if (stauts == 0)
            {
                context.RequestStatus.AddOrUpdate(x => x.RequestStatusId,
               new Models.RequestStatu() { NameEn = "Need your Director Approval", NameAr = "تحتاج موافقة مديرك المباشر", StatusCode = "NDA",Color = "badge bg-warning", CreatedDate = DateTime.Now, Active = true },
               new Models.RequestStatu() { NameEn = "Need IT Approval", NameAr = "تحتاج موافقة مدير تقنية المعلومات", StatusCode = "NITA", Color = "badge bg-warning", CreatedDate = DateTime.Now, Active = true },
               new Models.RequestStatu() { NameEn = "Need Teckenical Report", NameAr = "يحتاج تقرير فني", StatusCode = "NTR", Color = "badge bg-warning", CreatedDate = DateTime.Now, Active = true },
               new Models.RequestStatu() { NameEn = "Approval By your Director", NameAr = "تم قبول طلبك من مديرك المباشر", StatusCode = "ABD", Color = "", CreatedDate = DateTime.Now, Active = true },
               new Models.RequestStatu() { NameEn = "Reject By your Director", NameAr = "تم رفض طلبك من مديرك المباشر", StatusCode = "RBD", Color = "badge bg-important", CreatedDate = DateTime.Now, Active = true },
               new Models.RequestStatu() { NameEn = "Approval By IT Department", NameAr = "تم قبول طلبك من قبل تقنية المعلومات", StatusCode = "AIT", Color = "badge bg-info", CreatedDate = DateTime.Now, Active = true },
               new Models.RequestStatu() { NameEn = "Reject By IT Department", NameAr = "تم رفض طلبك من قبل تقنية المعلومات", StatusCode = "RIT", Color = "badge bg-important", CreatedDate = DateTime.Now, Active = true },
               new Models.RequestStatu() { NameEn = "Your Order with IT Supervisor", NameAr = "طلبك لدى مسؤول الطلبات", StatusCode = "ITS", Color = "", CreatedDate = DateTime.Now, Active = true },
               new Models.RequestStatu() { NameEn = "Your order can be received from the Warehouse", NameAr = "يمكنك استلام طلبك من المستودعات", StatusCode = "RWH", Color = "badge bg-info", CreatedDate = DateTime.Now, Active = true },
               new Models.RequestStatu() { NameEn = "Device was Dileverd", NameAr = "تم صرف الجهاز", StatusCode = "DONE", Color = "badge bg-success", CreatedDate = DateTime.Now, Active = true },
               new Models.RequestStatu() { NameEn = "Request was Canceled", NameAr = "تم إلغاء الطلب", StatusCode = "CANCEL", Color = "badge bg-inverse", CreatedDate = DateTime.Now, Active = true },
               new Models.RequestStatu() { NameEn = "Request is Pending", NameAr = "الطلب معلق", StatusCode = "PEND", Color = "badge", CreatedDate = DateTime.Now, Active = true }
               );
            }

            var Building = context.Buildings.Count();
            if (Building == 0)
            {
                context.Buildings.AddOrUpdate(x => x.BuildingId,
                   new Models.Building() { NameEn = "East Building", NameAr = "المبنى الشرقي", CreatedBy = "System", CreatedDate = DateTime.Now, Active = true },
                   new Models.Building() { NameEn = "West Building", NameAr = "المبنى الغربي", CreatedBy = "System", CreatedDate = DateTime.Now, Active = true },
                   new Models.Building() { NameEn = "Administrative building", NameAr = "المبنى الإداري", CreatedBy = "System", CreatedDate = DateTime.Now, Active = true });
            }

            var Level = context.Levels.Count();
            if (Level == 0)
            {
                context.Levels.AddOrUpdate(x => x.LevelId,
               new Models.Level() { NameEn = "Level One", NameAr = "المستوى الأول", CreatedBy = "System", CreatedDate = DateTime.Now, Active = true },
               new Models.Level() { NameEn = "Level Two", NameAr = "المستوى الثاني", CreatedBy = "System", CreatedDate = DateTime.Now, Active = true },
               new Models.Level() { NameEn = "Level Three", NameAr = "المستوى الثالث", CreatedBy = "System", CreatedDate = DateTime.Now, Active = true },
               new Models.Level() { NameEn = "Level Four", NameAr = "المستوى الرابع", CreatedBy = "System", CreatedDate = DateTime.Now, Active = true }
               );
            }

            var Position = context.Positions.Count();
            if (Position == 0)
            {
                context.Positions.AddOrUpdate(x => x.PositionId,
               new Models.Position() { NameEn = "Academic Staff", NameAr = "عضو هيئة تدريس", CreatedBy = "System", CreatedDate = DateTime.Now, Active = true },
               new Models.Position() { NameEn = "Director", NameAr = "مدير", CreatedBy = "System", CreatedDate = DateTime.Now, Active = true },
               new Models.Position() { NameEn = "Head of nursing", NameAr = "رئيس تمريض", CreatedBy = "System", CreatedDate = DateTime.Now, Active = true },
               new Models.Position() { NameEn = "Health Employee", NameAr = "موظف صحي", CreatedBy = "System", CreatedDate = DateTime.Now, Active = true },
               new Models.Position() { NameEn = "Administrative Employee", NameAr = "موظف إدري", CreatedBy = "System", CreatedDate = DateTime.Now, Active = true },
               new Models.Position() { NameEn = "Secratery", NameAr = "سكرتارية", CreatedBy = "System", CreatedDate = DateTime.Now, Active = true }
                );
            }

            var Department = context.Departments.Count();
            if (Department == 0)
            {
                context.Departments.AddOrUpdate(x => x.DepartmentId,
               new Models.Department() { NameEn = "Emergency Department", NameAr = "قسم الطوارئ", CreatedBy = "System", CreatedDate = DateTime.Now, Active = true },
               new Models.Department() { NameEn = "Department of Internal Medicine", NameAr = "قسم الباطنية", CreatedBy = "System", CreatedDate = DateTime.Now, Active = true },
               new Models.Department() { NameEn = "Orthopedic Department", NameAr = "قسم العظام", CreatedBy = "System", CreatedDate = DateTime.Now, Active = true },
               new Models.Department() { NameEn = "x_ray Department", NameAr = "قسم الأشعة", CreatedBy = "System", CreatedDate = DateTime.Now, Active = true },
               new Models.Department() { NameEn = "IT Department", NameAr = "قسم تقنية المعلومات", CreatedBy = "System", CreatedDate = DateTime.Now, Active = true }

                );
            }

            var Item = context.Items.Count();
            if (Item == 0)
            {
                context.Items.AddOrUpdate(x => x.ItemId,
               new Models.Item() { NameEn = "Computer", NameAr = "حاسب آلي", CreatedBy = "System", CreatedDate = DateTime.Now, Active = true, },
               new Models.Item() { NameEn = "Color Printer", NameAr = "طابعة ملون", CreatedBy = "System", CreatedDate = DateTime.Now, Active = true, },
               new Models.Item() { NameEn = "Black Printer", NameAr = "طابعة عادية", CreatedBy = "System", CreatedDate = DateTime.Now, Active = true, },
               new Models.Item() { NameEn = "Scanner", NameAr = "ماسح ضوئي", CreatedBy = "System", CreatedDate = DateTime.Now, Active = true, }
                );
            }

            var Type = context.TypeOfRequests.Count();
            if (Type == 0)
            {
                context.TypeOfRequests.AddOrUpdate(x => x.TypeOfRequestId,
               new Models.TypeOfRequest() { NameEn = "New Item", NameAr = "جهاز جديد", CreatedBy = "System", CreatedDate = DateTime.Now, Active = true, },
               new Models.TypeOfRequest() { NameEn = "Replace Item", NameAr = "استبدال جهاز", CreatedBy = "System", CreatedDate = DateTime.Now, Active = true, }
                );
            }

            var Role = context.Roles.Count();
            if (Role == 0)
            {
                context.Roles.AddOrUpdate(x => x.RoleId,
               new Models.Role() { NameEn = "Admin", NameAr = "", CreatedBy = "System", CreatedDate = DateTime.Now, Active = true, },
               new Models.Role() { NameEn = "IT Manager", NameAr = "مدير قسم تقنيةالمعلومات", CreatedBy = "System", CreatedDate = DateTime.Now, Active = true, },
               new Models.Role() { NameEn = "Supervisor", NameAr = "مشرف", CreatedBy = "System", CreatedDate = DateTime.Now, Active = true, },
               new Models.Role() { NameEn = "Warehouse Admin", NameAr = "مسؤول المستودع", CreatedBy = "System", CreatedDate = DateTime.Now, Active = true, },
               new Models.Role() { NameEn = "Technician", NameAr = "فني", CreatedBy = "System", CreatedDate = DateTime.Now, Active = true, },
               new Models.Role() { NameEn = "End User", NameAr = "مستخدم", CreatedBy = "System", CreatedDate = DateTime.Now, Active = true, }
                );
            }
        }
    }
}
