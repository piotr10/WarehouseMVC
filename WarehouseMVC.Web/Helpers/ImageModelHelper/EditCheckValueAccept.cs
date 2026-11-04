using System;
using Microsoft.AspNetCore.Hosting;
using WarehouseMVC.Application.ViewModel.Image;
using WarehouseMVC.Domain.Model;
using WarehouseMVC.Infrastructure;

namespace WarehouseMVC.Web.Helpers.ImageModelHelper
{
    public class EditCheckValueAccept
    {
        private readonly Context _context;
        public EditCheckValueAccept(Context context)
        {
            _context = context;
        }

        public int CheckAccept(NewImageModelVm imageModel)
        {
            //Accept for View "Accept"
            if (imageModel.AcceptHiredRecruitment == AcceptHiredRecruitment.Accept
                && imageModel.AcceptHiredControlling == AcceptHiredControlling.Accept
                && imageModel.AcceptHiredCfo == AcceptHiredCfo.Accept)
            {
                imageModel.IsHired = "Accept";
            }

            //Denied for View "Denied"
            else if (imageModel.AcceptHiredRecruitment == AcceptHiredRecruitment.Denied
                     && imageModel.AcceptHiredControlling == AcceptHiredControlling.Denied
                     && imageModel.AcceptHiredCfo == AcceptHiredCfo.Denied)
            {
                imageModel.IsHired = "Denied";
            }
            else
            {
                imageModel.IsHired = "Default ";
            }

            //Akcept when 3 person give Accept
            if (imageModel.FinallyHiredPayroll == true
                && imageModel.AddHoc == true)
            {
                if (imageModel.AcceptHiredRecruitment == AcceptHiredRecruitment.Accept &&
                    imageModel.AcceptHiredControlling == AcceptHiredControlling.Accept &&
                    imageModel.AcceptHiredCfo == AcceptHiredCfo.Accept)
                {
                    return 1;
                }
                else
                {
                    return 2;
                }
            }

            //Denied when 3 person give Denied
            if (imageModel.FinallyHiredPayrollFalse == true
                && imageModel.AddHoc == true)
            {
                if (imageModel.AcceptHiredRecruitment == AcceptHiredRecruitment.Denied &&
                    imageModel.AcceptHiredControlling == AcceptHiredControlling.Denied &&
                    imageModel.AcceptHiredCfo == AcceptHiredCfo.Denied)
                {
                    return 3;
                }
                else
                {
                    return 4;
                }
            }

            return 0;
        }

        public void CheckData(NewImageModelVm imageModel)
        {
            DateTime dateTime = DateTime.Now;

            //Check empty data for date time recruitment
            if (imageModel.AcceptDateTimeRecruitment == null)
            {
                if (imageModel.AcceptHiredRecruitment == AcceptHiredRecruitment.Accept)
                {
                    imageModel.AcceptDateTimeRecruitment = dateTime.ToString("dd/MM/yyyy HH:mm:ss");
                }
                else if (imageModel.AcceptHiredRecruitment == AcceptHiredRecruitment.Denied)
                {
                    imageModel.AcceptDateTimeRecruitment = dateTime.ToString("dd/MM/yyyy HH:mm:ss");
                }
            }
            else
            {
                imageModel.AcceptDateTimeRecruitment = imageModel.AcceptDateTimeRecruitment;
            }

            //Check empty data for date time controlling
            if (imageModel.AcceptDateTimeControlling == null)
            {
                if (imageModel.AcceptHiredControlling == AcceptHiredControlling.Accept)
                {
                    imageModel.AcceptDateTimeControlling = dateTime.ToString("dd/MM/yyyy HH:mm:ss");
                }
                else if (imageModel.AcceptHiredControlling == AcceptHiredControlling.Denied)
                {
                    imageModel.AcceptDateTimeControlling = dateTime.ToString("dd/MM/yyyy HH:mm:ss");
                }
            }
            else
            {
                imageModel.AcceptDateTimeControlling = imageModel.AcceptDateTimeControlling;
            }

            //Check empty data for date time cfo
            if (imageModel.AcceptDateTimeCfo == null)
            {
                if (imageModel.AcceptHiredCfo == AcceptHiredCfo.Accept)
                {
                    imageModel.AcceptDateTimeCfo = dateTime.ToString("dd/MM/yyyy HH:mm:ss");
                }
                else if (imageModel.AcceptHiredCfo == AcceptHiredCfo.Denied)
                {
                    imageModel.AcceptDateTimeCfo = dateTime.ToString("dd/MM/yyyy HH:mm:ss");
                }
            }
            else
            {
                imageModel.AcceptDateTimeCfo = imageModel.AcceptDateTimeCfo;
            }
        }
    }
}