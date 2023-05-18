using S3Project.Entities;
using S3Project.Models;
using System.Globalization;

namespace S3Project.Mappers
{
    public class VisitorInfoMapper
    {
        public Visitor_Info MapModeltoEntity(VisitorInfoViewModel model)
        {
            Visitor_Info visitorinfo = new Visitor_Info();
            visitorinfo.Name = model.Name;
            visitorinfo.email = model.email;
            visitorinfo.company_name = model.company_name;
            visitorinfo.designation = model.designation;
            visitorinfo.mobile = model.mobile;
            visitorinfo.license_plate = model.license_plate;
            visitorinfo.nric_fin = model.nric_fin;
            visitorinfo.issh_notice = model.issh_notice;
            visitorinfo.isclose_contact = model.isclose_contact;
            visitorinfo.isfever = model.isfever;
            return visitorinfo;
        }

        public List<VisitorInfoListViewModel> MapEntityToListViewModel(List<Visitor_Info> list)
        {
            List<VisitorInfoListViewModel> vmlist = new List<VisitorInfoListViewModel>();
            foreach (var res in list)
            {
                VisitorInfoListViewModel vm = new VisitorInfoListViewModel();
                vm.id = res.id;
                vm.Name = res.Name;
                vm.email = res.email;
                vm.company_name = res.company_name;
                vm.designation = res.designation;
                vm.mobile = res.mobile;
                vm.license_plate = res.license_plate;
                vm.nric_fin = res.nric_fin;
                if (res.issh_notice)
                {
                    vm.issh_notice = "Yes";
                }
                else { vm.issh_notice = "No"; }
                if (res.isclose_contact)
                {
                    vm.isclose_contact = "Yes";
                }
                else
                {
                    vm.isclose_contact = "No";
                }
                if (res.isfever)
                {
                    vm.isfever = "Yes";
                }
                else
                {
                    vm.isfever = "No";
                }
                vmlist.Add(vm);
            }
            return vmlist;
        }
    }
}
